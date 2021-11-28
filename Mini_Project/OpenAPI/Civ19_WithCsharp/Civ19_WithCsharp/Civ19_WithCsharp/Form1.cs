using System;
using Civ19_WithCsharp;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
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


        private void Datatable(String[] createDt, int[] decideCnt)
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("DATE", typeof(string)));
            dt.Columns.Add(new DataColumn("DECIDECNT", typeof(int)));
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

        private void CoivChart(String[] createDt, int[] decideCnt)
        {
            chart1.Series.Clear();
            Series series = new Series("확진자");
            series.ChartType = SeriesChartType.Bubble;
            series.Points.DataBindXY(createDt, decideCnt);
            chart1.Series.Add(series);
            
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
                    CoivChart(createDt, decideCnt);
                }

            }
            catch (ArgumentException ex) { MessageBox.Show("XML 문제 발생\r\n" + ex); }
            catch(NullReferenceException ex) { MessageBox.Show("OpenApi호출문제 발생\r\n" + ex); }
        }
    }
}
