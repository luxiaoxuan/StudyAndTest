﻿using OpenQA.Selenium;
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
            txt.SendKeys("坂本ですが");
            var a = wd.FindElementById("isearch");
            a.Click();
            //var btn = wd.FindElementById("srchbtn");
            //btn.Click();

            Thread.Sleep(3000);

            a = wd.FindElementByClassName("pls");
            a.Click();

            txt = wd.FindElementById("f0dimp1");
            txt.SendKeys("1920");
            txt = wd.FindElementById("f0dimp2");
            txt.SendKeys("1080");

            var div = wd.FindElementByCssSelector("div.sb.cf");
            var btn = div.FindElements(By.TagName("input")).First(e => e.GetAttribute("type") == "submit");
            btn.Click();

            Thread.Sleep(3000);
            
            wd.Quit();
        }
    }
}
