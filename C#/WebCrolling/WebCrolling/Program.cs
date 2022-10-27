using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ChromeDriverPrototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
            ChromeDriver chromeDriver = new ChromeDriver(chromeDriverService);
            chromeDriver.Navigate().GoToUrl("http://auth.pubg.game.daum.net/starter/pubg/start.daum");
        }
    }
}