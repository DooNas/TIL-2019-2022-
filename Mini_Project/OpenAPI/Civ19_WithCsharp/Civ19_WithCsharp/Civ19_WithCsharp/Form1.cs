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
            StreamWriter writer;
            writer = File.CreateText("Civ19.xml");
            writer.Write(results);
            writer.Close();
        }
        public static String XmltoJson(string results)
        {
            XmlDocument XmFile = new XmlDocument();
            XmFile.LoadXml(results);
            JsonConvert.SerializeXmlNode(XmFile);
            string jsonStr = JsonConvert.SerializeXmlNode(XmFile, Newtonsoft.Json.Formatting.None, true);
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
            //xml에서 어떻게 해야 현제 확진자 수를 추출할 수 있을까?
            JObject response = JObject.Parse(XmltoJson(results));
            IList<User> searchRes = response["item"].Select(r => JsonConvert.DeserializeObject<User>(r.ToString())).ToList();
            String re = null;
            foreach (User user in searchRes)
            {
                re += user.createDt + "\n";
                re += user.deathCnt + "\n";
                re += user.decideCnt + "\n";
                re += user.examCnt + "\n";
            }
            richTextBox1.Text = re;
        }
    }
}
