using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Events;
using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;

namespace LXXTestSite.Tests
{
    [TestClass]
    public class SeleniumTest
    {
        [TestMethod]
        public void SearchAnimePicsFromYahoo()
        {
            var chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("http://www.yahoo.co.jp");

            chrome.FindElementById("srchtxt").SendKeys("坂本ですが");
            chrome.FindElementById("isearch").Click();

            Thread.Sleep(3000);

            chrome.FindElementByClassName("pls").Click();

            new Actions(chrome)
                .SendKeys(chrome.FindElementById("f0dimp1"), "1920")
                .SendKeys(chrome.FindElementById("f0dimp2"), "1080")
                .Click(chrome.FindElementByCssSelector("div.sb.cf")
                    .FindElements(By.TagName("input"))
                    .First(e => e.GetAttribute("type") == "submit"))
                .Perform();

            Thread.Sleep(3000);
            chrome.Quit();
        }

        [TestMethod]
        public void InputFormByIE()
        {
            var inputFilePath = @"..\..\TestData\input-self-info_001.json";
            var jsonString = File.ReadAllText(inputFilePath);
            var data = JsonConvert.DeserializeObject<ResumeInfo>(jsonString);

            var driver = new InternetExplorerDriver(new InternetExplorerOptions
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
            });
            //var driver = new ChromeDriver();
            //var driver = new InternetExplorerDriver();
            var fDriver = new EventFiringWebDriver(driver);
            fDriver.ElementValueChanged += delegate (object o, WebElementEventArgs e)
            {
                Trace.WriteLine(e.Element.TagName + "'s value has been changed to ':" + e.Element.GetAttribute("value") + "'.");
            };

            fDriver.Navigate().GoToUrl("http://localhost:49459/Selenium/ResumeInput.html");

            var inputWindow = fDriver.CurrentWindowHandle;
            Trace.WriteLine("current window:" + inputWindow);

            fDriver.FindElement(By.Id("txtName")).SendKeys(data.Name);
            fDriver.FindElements(By.Name("rdSex")).First(e => e.GetAttribute("value") == data.Sex).Click();
            if (data.IsMarried)
            {
                fDriver.FindElement(By.Id("lblMarried")).Click();
            }
            fDriver.FindElement(By.Id("ddlRegion"))
                .FindElements(By.XPath(@"//option"))
                .First(e => e.Text == data.Hometown).Click();
            fDriver.FindElement(By.Id("txtMail")).SendKeys(data.MailAddress);
            fDriver.FindElement(By.Id("txtSelfIntro")).SendKeys(data.SelfIntro);
            fDriver.FindElement(By.Id("btnSubmit")).Click();
            fDriver.SwitchTo().Alert().Accept();

            foreach (var w in fDriver.WindowHandles)
            {
                if (w != inputWindow)
                {
                    fDriver.SwitchTo().Window(w);
                    break;
                }
            }
            Trace.WriteLine("current window:" + fDriver.CurrentWindowHandle);

            var ss = fDriver.GetScreenshot();
            var imgPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                string.Format(@"evidence_{0}.png", DateTime.Now.ToString("yyyyMMdd-HHmmss")));
            ss.SaveAsFile(imgPath, ImageFormat.Png);

            fDriver.Quit();
        }
    }
}
