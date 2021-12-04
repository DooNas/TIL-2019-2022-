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
            CheckData();
            //Controll to TopPanel
            this.ControlBox = false;
            this.Text = string.Empty;
            Top_Bar.MouseDown += panelTop_MouseDown;
            Top_Bar.MouseMove += panelTop_MouseMove;
            lb_Title.MouseUp += panelTop_MouseUp;
            lb_Title.MouseDown += panelTop_MouseDown;
            lb_Title.MouseMove += panelTop_MouseMove;
            BtnClose.Click += Btn_Close;
            BtnMinmon.Click += Btn_Minmon;
            ////////////////////////
            tb_Term.Value = 7;
            lb_StartDate.Text = DateTime.Now.AddDays(-7).ToShortDateString();
            lb_EndDate.Text = DateTime.Now.AddDays(-1).ToShortDateString();
            tb_Term.Scroll += Tb_Term_Scroll;
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
        private void Datatable(String[] createDt, int[] decideCnt, int length)
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("날짜", typeof(string)));
            dt.Columns.Add(new DataColumn("확진자", typeof(int)));
            for (int index = 0; index < length; index++)
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
        private void CoivChart(DataTable dt)//Art Chart
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


        int length = 7;
        private void Tb_Term_Scroll(object sender, EventArgs e)
        {
            OpenApi openApi = new OpenApi();
            tb_Term.Value = length;
            if(length < 10) lb_date.Text = " " + length.ToString() + "일";
            else lb_date.Text = length.ToString() + "일";
            lb_StartDate.Text = DateTime.Now.AddDays(-length).ToShortDateString();
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            CheckData(true);
        }

        private async void CheckData(bool Message = false)
        {
            Thread.Sleep(100);
            OpenApi openApi = new OpenApi();
            String results = await openApi.OpenApiGetData(ApiKey.Getkey(), length);
            openApi.DataToXml(results); //Make Civ19.xml

            try
            {
                String[] createDt = new string[length + 1];
                openApi.XmlParsing_StringArray(createDt, length, 5, 5, "createDt");

                int[] decideCnt = new int[length + 1];
                openApi.XmlParsing_IntArray(decideCnt, length, "decideCnt");

                String d = string.Empty;
                foreach(String i in createDt)
                {
                    d += i + ", ";
                }
                d += "\n";
                foreach(int i in decideCnt)
                {
                    d += i.ToString() + ", ";
                }
                MessageBox.Show(d);
                /*
                if (Message)
                {
                    string message = lb_StartDate.Text + " ~ " + lb_EndDate.Text + "\n불러왔습니다.";
                    MessageBox.Show(message);
                }
                */
                Datatable(createDt, decideCnt, length);
                CoivChart(dt);
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
