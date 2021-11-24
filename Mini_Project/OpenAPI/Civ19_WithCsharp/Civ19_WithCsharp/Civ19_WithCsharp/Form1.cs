using System;
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

namespace Civ19_WithCsharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static HttpClient client = new HttpClient();
        static string results = string.Empty;
        static void OpenApiGetFile()
        {
            string url = "http://openapi.data.go.kr/openapi/service/rest/Covid19/getCovid19InfStateJson"; // URL
            url += "?ServiceKey=" + ApiKey.Getkey(); // Service Key
            //url += "&pageNo=1";
            //url += "&numOfRows=10";
            url += "&startCreateDt=20211124";
            //url += "&endCreateDt=20211124";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            results = string.Empty;
            HttpWebResponse response;
            using (response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                results = reader.ReadToEnd();
            }

            //xml 파일처리
            /*
            StreamWriter writer;
            writer = File.CreateText("Civ19.xml");
            writer.Write(results);
            writer.Close();
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
			OpenApiGetFile();
            richTextBox1.Text = results;
            /*
            XmlDocument XmFile = new XmlDocument();

            XmFile.LoadXml(results);
            XmlNodeList Xmllist =  XmFile.GetElementsByTagName("items");
            foreach (XmlNode XmlNode in Xmllist)
            {
                richTextBox1.Text = XmlNode["item"]["DECIDE_CNT"].InnerText;
            }
            */
        }
    }
}
