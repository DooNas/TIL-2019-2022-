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
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100);
            richTextBox1.Clear();

            OpenApi_GetXml openApi_GetXml = new OpenApi_GetXml();
            String results = await openApi_GetXml.OpenApiGetFile(20211120, ApiKey.Getkey());
            //await는 void, Task, Task<변수형>만 가능하다.
            //Task<변수형>경우 자리를 예약하고 해당 자리에 예약한 손님이 앉기 전까지는 다음으로 진행하지 않는다는 의미를 갖는다.


            StreamWriter writer;
            writer = File.CreateText("Civ19.xml");
            writer.Write(results);
            writer.Close();
            //xml에서 어떻게 해야 현제 확진자 수를 추출할 수 있을까?
            ////Xml에서 파싱을 해보자.
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load("Civ19.xml");

                XmlNodeList xnList = xml.SelectNodes("/response/body/items/item"); //접근할 노드
                String[] creaeDt = new string[7];
                int[] decideCnt = {1,1,1,1,1,1,1};
                int i = 0;
                foreach (XmlNode xn in xnList)
                {
                    creaeDt[i] = xn["createDt"].InnerText; //작성 날짜 불러오기
                    decideCnt[i] = int.Parse(xn["decideCnt"].InnerText); //확진자 불러오기
                    i++;
                }

                for(int index = 0; index < 6; index++)
                {
                    String TodaydecideCnt = (decideCnt[index] - decideCnt[index + 1]).ToString();
                    String Today = creaeDt[index+1];
                    if (Today == null)
                    {
                        return;
                    }
                    richTextBox1.AppendText("날짜 : " + Today.Substring(0,10) + "\t확진자 수  : " + TodaydecideCnt + "명\n\n");
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
