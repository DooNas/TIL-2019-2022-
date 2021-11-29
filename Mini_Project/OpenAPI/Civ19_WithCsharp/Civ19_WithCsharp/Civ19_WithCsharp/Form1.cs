using System;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace Civ19_WithCsharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += Button1_Click;
        }
        DataTable dt;
        Chart chart;

        private void Datatable(String[] createDt, int[] decideCnt)
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("날짜", typeof(string)));
            dt.Columns.Add(new DataColumn("확진자수", typeof(int)));
            for (int index = 0; index < 7; index++)
            {
                String D_day = createDt[index + 1];
                String TodaydecideCnt = (decideCnt[index + 1] - decideCnt[index]).ToString();
                if (D_day == null)  //if 더이상 출력할 요소가 없다면 종료.
                {
                    return;
                }
                dt.Rows.Add(D_day, TodaydecideCnt);
                dataGridView1.DataSource = dt;
            }
        }

        private void CoivChart(DataTable dt)
        {
            chart = this.chart1;
            chart.Series.Clear();
            Series[] series = new Series[dt.Rows.Count];
            int index = 0;
            foreach (DataRow dr in dt.Rows)
            {
                series[index] = new Series(dr["날짜"].ToString());
                series[index].ChartType = SeriesChartType.Column;
                series[index].Points.AddXY("확진자수", int.Parse(dr["확진자수"].ToString()));
                chart.Series.Add(series[index]);
                index += 1;
            }

        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            dataGridView1.Refresh();

            OpenApi openApi = new OpenApi();
            String results = await openApi.OpenApiGetData(ApiKey.Getkey());
            openApi.DataToXml(results); //Make Civ19.xml

            try
            {
                String[] createDt = new string[9];
                openApi.XmlParsing_String(createDt, 5, 5, "createDt");

                int[] decideCnt = new int[9];
                openApi.XmlParsing_Int(decideCnt, "decideCnt");

                Datatable(createDt, decideCnt);

                if (!string.IsNullOrEmpty(createDt[1]))
                {
                    CoivChart(dt);
                }

            }
            catch (ArgumentException ex) { MessageBox.Show("XML 문제 발생\r\n" + ex); }
            catch(NullReferenceException ex) { MessageBox.Show("OpenApi호출문제 발생\r\n" + ex); }
        }
    }
}
