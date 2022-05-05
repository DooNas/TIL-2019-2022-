// C# 샘플 코드
using System;
using System.Net;
using System.Net.Http;
using System.IO;
using Civ19_WithCsharp_Test;

namespace ConsoleApp1
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            string url = "http://openapi.data.go.kr/openapi/service/rest/Covid19/getCovid19InfStateJson"; // URL
            url += "?ServiceKey=" + ApiKey.Getkey(); // Service Key
            url += "&pageNo=1";
            url += "&numOfRows=10";
            url += "&startCreateDt=20200310";
            url += "&endCreateDt=20200315";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            string results = string.Empty;
            HttpWebResponse response;
            using (response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                results = reader.ReadToEnd();
            }
            StreamWriter writer;
            writer = File.CreateText(@"D:\Project_ForCoding\TIL\Mini_Project\OpenAPI\Civ19_WithCsharp_Test\Civ19_WithCsharp_Test\Civ19_WithCsharp_Test\Civ19.xml");
            writer.Write(results);
            writer.Close();
        }
    }
}