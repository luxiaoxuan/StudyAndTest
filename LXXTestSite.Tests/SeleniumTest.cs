using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace LXXTestSite.Tests
{
    [TestClass]
    public class SeleniumTest
    {
        IWebDriver _webDriver;

        IWebDriver WebDriver
        {
            get
            {
                if (this._webDriver == null)
                {
                    this._webDriver = new InternetExplorerDriver(new InternetExplorerOptions
                    {
                        IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                    });
                }
                return this._webDriver;
            }
            set
            {
                this._webDriver = value;
            }
        }


        [TestCleanup]
        public void QuitWebDriver()
        {
            if (this._webDriver != null)
            {
                this._webDriver.Quit();
            }
        }

        [TestMethod]
        public void SearchAnimePicsFromYahoo()
        {
            this._webDriver.Navigate().GoToUrl("http://www.yahoo.co.jp");

            this._webDriver.FindElement(By.Id("srchtxt")).SendKeys("坂本ですが");
            this._webDriver.FindElement(By.Id("isearch")).Click();

            Thread.Sleep(3000);

            this._webDriver.FindElement(By.ClassName("pls")).Click();

            new Actions(this._webDriver)
                .SendKeys(this._webDriver.FindElement(By.Id("f0dimp1")), "1920")
                .SendKeys(this._webDriver.FindElement(By.Id("f0dimp2")), "1080")
                .Click(this._webDriver.FindElement(By.CssSelector("div.sb.cf"))
                    .FindElements(By.TagName("input"))
                    .First(e => e.GetAttribute("type") == "submit"))
                .Perform();

            Thread.Sleep(3000);
            this._webDriver.Quit();
        }

        [TestMethod]
        public void InputForm()
        {
            this.WebDriver = new ChromeDriver();

            this.InputForm(@"..\..\TestData\input-self-info_001.json");
        }

        public void InputForm(string inputFilePath)
        {
            var jsonString = File.ReadAllText(inputFilePath);
            var data = JsonConvert.DeserializeObject<ResumeInfo>(jsonString);

            var fDriver = new EventFiringWebDriver(this.WebDriver);
            fDriver.ElementValueChanged += delegate (object o, WebElementEventArgs e)
            {
                Trace.WriteLine(e.Element.TagName + "'s value has been changed to ':" + e.Element.GetAttribute("value") + "'.");
            };

            PageFactory.InitElements<ResumeInputPage>(fDriver).InputResume(data);

            Thread.Sleep(1000);
            foreach (var w in fDriver.WindowHandles)
            {
                if (w != fDriver.CurrentWindowHandle)
                {
                    fDriver.SwitchTo().Window(w);
                    break;
                }
            }

            var timeStamp = DateTime.Now.ToString("yyyyMMdd-HHmmss");

            var ss = fDriver.GetScreenshot();
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), @"WebTest");
            var imgPath = Path.Combine(path, string.Format(@"screenshot_{0}.png", timeStamp));
            ss.SaveAsFile(imgPath, ImageFormat.Png);

            var sb = new StringBuilder();
            var tbl = fDriver.FindElement(By.TagName("table"));
            sb.AppendLine("ページの<table>要素の情報：");
            sb.AppendLine();
            sb.Append("高さ： ").AppendLine(tbl.GetCssValue("height"));
            sb.Append("広さ： ").AppendLine(tbl.GetCssValue("width"));
            sb.Append("行数： ").AppendLine(tbl.FindElements(By.TagName("tr")).Count.ToString());
            sb.Append("フォント： ").AppendLine(tbl.GetCssValue("font-family"));
            sb.Append("2行目4列目セルの値： ").AppendLine(tbl.FindElements(By.TagName("tr")).ToArray()[1].FindElements(By.TagName("td")).ToArray()[3].Text);
            File.AppendAllText(Path.Combine(path, string.Format(@"result_{0}.txt", timeStamp)), sb.ToString());

            Assert.Equals("aaa", tbl);

            fDriver.Quit();
        }
    }
}
