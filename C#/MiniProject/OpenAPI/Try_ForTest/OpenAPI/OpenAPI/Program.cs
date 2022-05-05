// C# 샘플 코드
using System;
using System.Net;
using System.Net.Http;
using System.IO;

namespace OpenAPI
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            string url = "http://apis.data.go.kr/1360000/FmlandWthrInfoService/getDayStatistics"; // URL
            url += "?ServiceKey=" + "pu2DgRxDwebnztGeR60Mrd76BTdm86ihmY475McUIs1t81pQvpnEEcGGKShoff7dd%2F%2Ft8AvxjpFGC%2FZrI8GZqw%3D%3D"; // Service Key
            url += "&pageNo=1";
            url += "&numOfRows=10";
            url += "&dataType=XML";
            url += "&ST_YMD=20201201";
            url += "&ED_YMD=20201201";
            url += "&AREA_ID=4122000000";
            url += "&PA_CROP_SPE_ID=PA130201";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            string results = string.Empty;
            HttpWebResponse response;
            using (response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                results = reader.ReadToEnd();
            }

            Console.WriteLine(results);
        }
    }
}