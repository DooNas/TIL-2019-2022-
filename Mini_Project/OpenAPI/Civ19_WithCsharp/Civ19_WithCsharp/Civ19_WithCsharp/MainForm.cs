using System;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace Civ19_WithCsharp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = string.Empty;

            //Controll to TopPanel
            Top_Bar.MouseUp += panelTop_MouseUp;
            Top_Bar.MouseDown += panelTop_MouseDown;
            Top_Bar.MouseMove += panelTop_MouseMove;
            lb_Title.MouseUp += panelTop_MouseUp;
            lb_Title.MouseDown += panelTop_MouseDown;
            lb_Title.MouseMove += panelTop_MouseMove;
            BtnClose.Click += Btn_Close;
            BtnMinmon.Click += Btn_Minmon;

            Btn_Search.Click += Btn_Search_Click;
        }

        //////////////Controll to TopPanel/////////////////
        bool isMove;
        int MouseX, MouseY;
        private void panelTop_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            MouseX = e.X;
            MouseY = e.Y;
        }
        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove == true)
            {
                this.SetDesktopLocation(MousePosition.X - MouseX, MousePosition.Y - MouseY);
            }
        }
        private void Btn_Close(object sender, EventArgs e)
        {
            File.Delete("Civ19.xml");
            this.Close();
        }

        private void Btn_Minmon(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //////////////////////////////////////////////////

        DataTable dt;
        private void Datatable(String[] createDt, int[] decideCnt)
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("날짜", typeof(string)));
            dt.Columns.Add(new DataColumn("확진자", typeof(int)));
            for (int index = 0; index < 7; index++)
            {
                String D_day = createDt[index+1];
                String TodaydecideCnt = (decideCnt[index + 1] - decideCnt[index]).ToString();
                if (D_day == null)  //if 더이상 출력할 요소가 없다면 종료.
                {
                    return;
                }
                dt.Rows.Add(D_day, TodaydecideCnt);
            }
        }

        Chart chart;
        private void CoivChart(DataTable dt)
        {
            chart = this.Week_chart;
            chart.Series.Clear();
            var series = chart.Series.Add("확진자");
            series.XValueMember = "날짜";
            series.YValueMembers = "확진자";
            chart.DataSource = dt;
            series.Color = System.Drawing.Color.FromArgb(
                                                            ((int)(((byte)(240)))), 
                                                            ((int)(((byte)(084)))), 
                                                            ((int)(((byte)(084))))
                                                            );
            chart.DataBind();
            chart.Visible = true;

        }

        private void ChoiceWhen_Click(object sender, EventArgs e)
        {

        }

        private async void Btn_Search_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            OpenApi openApi = new OpenApi();
            String results = await openApi.OpenApiGetData(ApiKey.Getkey());
            openApi.DataToXml(results); //Make Civ19.xml

            try
            {
                String[] createDt = new string[8];
                openApi.XmlParsing_String(createDt, 5, 5, "createDt");

                int[] decideCnt = new int[8];
                openApi.XmlParsing_Int(decideCnt, "decideCnt");

                string mess = string.Empty;
                foreach (string dt in createDt)
                {
                    mess += dt + ", ";
                }
                mess += "\n";
                foreach(int i in decideCnt)
                {
                    mess += i.ToString() + ", ";
                }
                MessageBox.Show(mess);


                Datatable(createDt, decideCnt);

                if (!string.IsNullOrEmpty(createDt[1]))
                {
                    CoivChart(dt);
                }

            }
            catch (ArgumentException ex) { MessageBox.Show("XML 문제 발생\r\n" + ex); }
            catch (NullReferenceException ex) { MessageBox.Show("OpenApi호출문제 발생\r\n" + ex); }
        }
    }
}
