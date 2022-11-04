using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;

namespace Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private async void WebLogin()
        {
            await Task.Delay(1500);
            webBrowser1.Document.GetElementById("id_email_2").SetAttribute("value", "robertking99@naver.com");
            webBrowser1.Document.GetElementById("id_password_3").SetAttribute("value", "lp0928");

            await Task.Delay(1500);
            HtmlElementCollection loginButton = webBrowser1.Document.GetElementsByTagName("button");
            foreach (HtmlElement seachLogin in loginButton)
            {
                if (seachLogin.InnerText == "로그인")
                {
                    seachLogin.InvokeMember("click");
                }
            }

        }
    }
}