using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            var wd = new ChromeDriver();
            var navi = wd.Navigate();
            navi.GoToUrl("http://www.yahoo.co.jp");
            var txt = wd.FindElementById("srchtxt");
            txt.SendKeys("bilibili 中国");
            var btn = wd.FindElementById("srchbtn");
            btn.Click();

            Thread.Sleep(5000);
            
            wd.Close();
        }
    }
}
