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

namespace Civ19_WithCsharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Datatable();
            button1.Click += Button1_Click;
        }
        DataTable dt;


        private void Datatable()
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("DATE", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("DECIDECNT", typeof(int)));
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            richTextBox1.Clear();

            OpenApi openApi = new OpenApi();
            String results = await openApi.OpenApiGetData(ApiKey.Getkey());
            openApi.DataToXml(results); //Make Civ19.xml

            try
            {
                String[] createDt = new string[9];
                openApi.XmlParsing_String(createDt, "createDt");

                int[] decideCnt = new int[9];
                openApi.XmlParsing_Int(decideCnt, "decideCnt");
                //createDt = {'오늘날짜', '오늘날짜 - 1', '오늘날짜 - 2', '오늘날짜 - 3', '오늘날짜 - 4', '오늘날짜 - 7', '오늘날짜 - 8'}
                //decideCnt = {'오늘확진자', '오늘확진자 - 1', '오늘확진자 - 2', '오늘확진자 - 3', '오늘확진자 - 4', '오늘확진자 - 7', '오늘확진자 - 8'}
                for (int index = 0; index < 6; index++)
                {
                    String TodaydecideCnt = (decideCnt[index] - decideCnt[index + 1]).ToString();
                    String Today = createDt[index+1];
                    if (Today == null)  //if 더이상 출력할 요소가 없다면 종료.
                    {
                        return;
                    }
                    richTextBox1.AppendText("날짜 : " + Today + "\t확진자 수  : " + TodaydecideCnt + "명\n\n");
                }

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("XML 문제 발생\r\n" + ex);
            }catch(NullReferenceException ex)
            {
                MessageBox.Show("OpenApi호출문제 발생\r\n" + ex);
            }

        }
    }
}
