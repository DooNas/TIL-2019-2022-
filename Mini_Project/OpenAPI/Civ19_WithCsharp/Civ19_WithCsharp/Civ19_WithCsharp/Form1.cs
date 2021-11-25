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

namespace Civ19_WithCsharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            OpenApi_GetXml.OpenApiGetFile();
            //xml에서 어떻게 해야 현제 확진자 수를 추출할 수 있을까?
            ////Xml에서 파싱을 해보자.
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load("Civ19.xml");

                XmlNodeList xnList = xml.SelectNodes("/response/body/items/item"); //접근할 노드
                foreach (XmlNode xn in xnList)
                {
                    string part1 = xn["createDt"].InnerText; //작성 날짜 불러오기
                    string part2 = xn["decideCnt"].InnerText; //확진자 불러오기
                    richTextBox1.AppendText("작성 날짜 : "+ part1 + " \t 확진자 수 : " + part2 + "명\n\n");
                }
                
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("XML 문제 발생\r\n" + ex);
            }

        }
    }
}
