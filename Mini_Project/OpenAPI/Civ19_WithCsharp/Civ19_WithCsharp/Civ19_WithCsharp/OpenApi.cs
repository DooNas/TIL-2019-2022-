using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Civ19_WithCsharp
{
    public class OpenApi
    {
        static HttpClient client = new HttpClient();
        
        public String date7before() //금일 기준 7일전 날짜
        {
            String date = DateTime.Now.AddDays(-8).ToShortDateString();
            date = String.Join("",date.Split('-'));
            return date;
        }

        //await는 void, Task, Task<변수형>만 가능하다.
        //Task<변수형>경우 자리를 예약하고 해당 자리에 예약한 손님이 앉기 전까지는 다음으로 진행하지 않는다는 의미를 갖는다.
        public async Task<String> OpenApiGetData(String key)
        {
            //데이터 호출(Xml)
            string url = "http://openapi.data.go.kr/openapi/service/rest/Covid19/getCovid19InfStateJson"; // URL
            url += "?ServiceKey=" + key; // Service Key
            url += "&numOfRows=7";
            url += "&startCreateDt=" + date7before();
            //url += "&endCreateDt=20211124";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            String results = string.Empty;
            HttpWebResponse response ;
            using(response =request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                results = reader.ReadToEnd();
            }
            return results;
        }
        public void DataToXml(String results)//Make Civ19.xml
        {
            StreamWriter writer;
            writer = File.CreateText("Civ19.xml");
            writer.Write(results);
            writer.Close();
        }

        public void XmlParsing_String(String[] array, int Start, int End, String node)
        {
            //xml에서 어떻게 해야 현제 확진자 수를 추출할 수 있을까?
            XmlDocument xml = new XmlDocument();
            xml.Load("Civ19.xml");

            XmlNodeList xnList = xml.SelectNodes("/response/body/items/item"); //접근할 노드
            int i = 0;
            foreach (XmlNode xn in xnList)
            {
                array[i] = xn[node].InnerText.Substring(Start, End); //작성 날짜 불러오기
                i++;
            }
        }

        public void XmlParsing_Int(int[] array, String node)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("Civ19.xml");

            XmlNodeList xnList = xml.SelectNodes("/response/body/items/item"); //접근할 노드
            int i = 0;
            foreach (XmlNode xn in xnList)
            {
                array[i] = int.Parse(xn[node].InnerText); //작성 날짜 불러오기
                i++;
            }
        }
    }
}
