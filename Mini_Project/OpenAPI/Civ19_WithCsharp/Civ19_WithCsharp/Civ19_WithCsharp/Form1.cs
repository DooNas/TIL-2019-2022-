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
        static String OpenApiGetFile()
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
            XmlDocument XmFile = new XmlDocument();
            XmFile.LoadXml(results);
            JsonConvert.SerializeXmlNode(XmFile);
            string jsonStr = JsonConvert.SerializeXmlNode(XmFile, Newtonsoft.Json.Formatting.None, true);

            //Json 파일처리
            StreamWriter writer;
            writer = File.CreateText("Civ19.Json");
            writer.Write(results);
            writer.Close();

            return jsonStr;
        }
        public class User
        {
            public string createDt { get; set; }
            public string deathCnt { get; set; }
            public string decideCnt { get; set; }
            public string examCnt { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenApiGetFile();
            //xml에서 어떻게 해야 현제 확진자 수를 추출할 수 있을까?\
            try
            {
                JObject json = JObject.Parse(results);
                var jsonKey = json[1]["body"]["items"]["item"];
                foreach (var j1 in jsonKey)
                {
                    foreach (var j2 in j1)
                    {
                        richTextBox1.Text = "사망자 수 : " + j2["deathCnt"].ToString();
                        richTextBox1.Text = "확진자 수 : " + j2["decideCnt"].ToString();
                    }
                }
            }
            catch(JsonReaderException js)
            {
                MessageBox.Show(js.Message);
            }

        }
    }
}
