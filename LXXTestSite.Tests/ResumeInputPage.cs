using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LXXTestSite.Tests
{
    public class ResumeInputPage
    {
        private IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "txtName")]
        private IWebElement TxtName { get; set; }

        [FindsByAll]
        [FindsBy(How = How.Name, Using = "rdSex")]
        private IList<IWebElement> RdSex { get; set; }

        [FindsBy(How = How.Id, Using = "lblMarried")]
        private IWebElement LblMarried { get; set; }

        [FindsBy(How = How.Id, Using = "ddlRegion")]
        private IWebElement DDLRegion { get; set; }

        [FindsBy(How = How.Id, Using = "txtMail")]
        private IWebElement TxtMail { get; set; }

        [FindsBy(How = How.Id, Using = "txtSelfIntro")]
        private IWebElement TxtSelfIntro { get; set; }

        [FindsBy(How = How.Id, Using = "btnSubmit")]
        private IWebElement BtnSubmit { get; set; }


        public ResumeInputPage(IWebDriver driver)
        {
            this._driver = driver;
            this._driver.Navigate().GoToUrl("http://localhost:49459/Selenium/ResumeInput.html");
        }


        public void InputResume(ResumeInfo data)
        {
            this.TxtName.SendKeys(data.Name);
            this.RdSex.First(e => e.GetAttribute("value") == data.Sex).Click();
            if (data.IsMarried)
            {
                this.LblMarried.Click();
            }
            this.DDLRegion.FindElements(By.XPath(@"//option"))
                .First(e => e.Text == data.Hometown).Click();
            this.TxtMail.SendKeys(data.MailAddress);
            this.TxtSelfIntro.SendKeys(data.SelfIntro);
            this.BtnSubmit.Click();

            this._driver.SwitchTo().Alert().Accept();
        }
    }
}
