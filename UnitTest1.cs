using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using Xunit;
using DevToolsSessionDomains = OpenQA.Selenium.DevTools.V102.DevToolsSessionDomains;
using Network = OpenQA.Selenium.DevTools.V102.Network;

namespace LearningSelenium;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
         var driver = new ChromeDriver();

            // ChromeOptions chromeOptions = new ChromeOptions();
            // chromeOptions.AddArguments("--headless");

            IDevTools devTools = driver as IDevTools;       

            var session = devTools.GetDevToolsSession();   

            var devToolsSession = session.GetVersionSpecificDomains<DevToolsSessionDomains>();

            devToolsSession.Network.Enable(new Network.EnableCommandSettings());

            devToolsSession.Network.SetBlockedURLs(new Network.SetBlockedURLsCommandSettings()
            {
                Urls = new string[] { "*://*/*.css", "*://*/*.jpg", "*://*/*.png" }
            });

            // ** start added by me



            // end

            driver.Url = "https://rahulshettyacademy.com/angularAppdemo/";

            driver.FindElement(By.XPath("//a[contains(@href,'library')]")).Click();
    }
}