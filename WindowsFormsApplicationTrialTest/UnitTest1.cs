using LXXCommon;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;

namespace WindowsFormsApplicationTrialTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            InvokePattern ip;
            ValuePattern vp;

            var p = Process.GetProcessesByName("SmartApplication").FirstOrDefault();
            var formMenu = AutomationElement.FromHandle(p.MainWindowHandle);

            var btnUserSetting = formMenu.FindFirst(TreeScope.Descendants, new AndCondition(
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button),
                new PropertyCondition(AutomationElement.NameProperty, "User Setting")));
            ip = btnUserSetting.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            ip.Invoke();

            var txtBD = AutomationElement.FocusedElement;
            var formUserSetting = GetWindow(txtBD);

            Automation.AddAutomationEventHandler(
                TextPattern.TextChangedEvent,
                formUserSetting,
                TreeScope.Descendants,
                new AutomationEventHandler(HandleTextChange));
            //Automation.AddAutomationFocusChangedEventHandler(new AutomationFocusChangedEventHandler(HandleTextChange));

            vp = txtBD.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            vp.SetValue("何じゃら日本語");

            var txtTelNo = formUserSetting.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "txtTelNo"));
            vp = txtTelNo.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            vp.SetValue("何じゃら日本語");

            var txtTitle = formUserSetting.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "txtTitle"));
            vp = txtTitle.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            vp.SetValue("何じゃら日本語");

            var txtName = formUserSetting.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "txtName"));
            vp = txtName.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            vp.SetValue("何じゃら日本語");

            var errTitle = formUserSetting.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "errTitle"));

            var txtCompany = formUserSetting.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document));
            //var tp = txtCompany.GetCurrentPattern(TextPattern.Pattern) as TextPattern;
            //var a1 = tp.DocumentRange.GetAttributeValue(TextPattern.BackgroundColorAttribute).ToString();
            //var a2 = tp.DocumentRange.GetAttributeValue(TextPattern.FontNameAttribute).ToString();
            //var a3 = tp.DocumentRange.GetAttributeValue(TextPattern.ForegroundColorAttribute).ToString();
            txtCompany.SetFocus();
            SendKeys.SendWait("何じゃら日本語");

            var btnSave = formUserSetting.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "btnSave"));
            var btnCancel = formUserSetting.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "btnCancel"));
            btnCancel.SetFocus();

            Assert.AreEqual(btnSave.Current.IsEnabled, false);
            Assert.AreEqual(btnCancel.Current.IsEnabled, true);
        }

        [TestMethod]
        public void TestMethod2()
        {
            InvokePattern ip;
            ValuePattern vp;
            ScrollPattern scp;
            SelectionItemPattern sp;
            TextPattern tp;
            TogglePattern tgp;

            var p = Process.GetProcessesByName("SmartApplication").FirstOrDefault();
            var formMenu = AutomationElement.FromHandle(p.MainWindowHandle);

            var btnApplication = formMenu.FindFirst(TreeScope.Descendants, new AndCondition(
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button),
                new PropertyCondition(AutomationElement.AutomationIdProperty, "btnApplication")));
            ip = btnApplication.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            ip.Invoke();

            var tabGI = AutomationElement.FocusedElement;
            var form = GetWindow(tabGI);

            var tabs = form.FindAll(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TabItem));
            var tabIO = tabs[2];
            sp = tabIO.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
            sp.Select();

            var radCreditOtherCurrency = form.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "radCreditOtherCurrency"));
            sp = radCreditOtherCurrency.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
            sp.Select();

            var txtCreditOtherCurrency = form.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "txtCreditOtherCurrency"));
            vp = txtCreditOtherCurrency.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            vp.SetValue("CNC");

            var combDebitMainCurrency = form.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "combDebitMainCurrency"));
            var item = combDebitMainCurrency.FindFirst(TreeScope.Descendants, new AndCondition(
                new PropertyCondition(AutomationElement.NameProperty, "JPY"),
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem)));
            sp = item.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
            sp.Select();

            var chkInstructions1 = form.FindFirst(TreeScope.Descendants, 
                new PropertyCondition(AutomationElement.AutomationIdProperty, "chkInstructions1"));
            tgp = chkInstructions1.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
            tgp.Toggle();

            var txtInstructions1 = form.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "txtInstructions1"));
            vp = txtInstructions1.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            vp.SetValue("テスト禁止文字だよ！");

            var tabPage3 = form.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "tabPage3"));
            scp = tabPage3.GetCurrentPattern(ScrollPattern.Pattern) as ScrollPattern;

            scp.ScrollVertical(ScrollAmount.LargeDecrement);
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            var bmp = ScreenCapturer.CaptureForegroundWindow();
            bmp.Save(Path.Combine(desktopPath, "001.bmp"));

            Thread.Sleep(1000);
            scp.ScrollVertical(ScrollAmount.LargeIncrement);
            bmp = ScreenCapturer.CaptureForegroundWindow();
            bmp.Save(Path.Combine(desktopPath, "002.bmp"));

            Thread.Sleep(1000);
            scp.ScrollVertical(ScrollAmount.LargeIncrement);
            bmp = ScreenCapturer.CaptureForegroundWindow();
            bmp.Save(Path.Combine(desktopPath, "003.bmp"));

            var btnPrint = form.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPrint"));
            Assert.AreEqual(btnPrint.Current.IsEnabled, false);
        }

        [TestMethod]
        public void TestMethod3()
        {
            AutomationElement e;
            InvokePattern ip;
            ValuePattern vp;
            SelectionItemPattern sp;
            //TextPattern tp;
            TogglePattern tgp;

            var p = Process.GetProcessesByName("SmartApplication").FirstOrDefault();
            var formMenu = AutomationElement.FromHandle(p.MainWindowHandle);

            e = formMenu.FindFirst(TreeScope.Descendants, new AndCondition(
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button),
                new PropertyCondition(AutomationElement.AutomationIdProperty, "btnApplication")));
            ip = e.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            ip.Invoke();

            e = AutomationElement.FocusedElement;
            var form = GetWindow(e);

            var tabs = form.FindAll(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TabItem));
            e = tabs[2];
            sp = e.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
            sp.Select();

            e = form.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "radCreditOtherCurrency"));
            sp = e.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
            sp.Select();

            e = form.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "txtCreditOtherCurrency"));
            vp = e.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            vp.SetValue("CNC");

            e = form.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "combDebitMainCurrency"));
            var item = e.FindFirst(TreeScope.Descendants, new AndCondition(
                new PropertyCondition(AutomationElement.NameProperty, "JPY"),
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem)));
            sp = item.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
            sp.Select();

            e = form.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "chkInstructions1"));
            tgp = e.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
            tgp.Toggle();

            e = form.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "txtInstructions1"));
            vp = e.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            vp.SetValue("Go go power range!");

            e = form.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPrint"));
            ip = e.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            ip.Invoke();

            e = AutomationElement.FocusedElement;
            ip = e.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            ip.Invoke();

            var formAgree = GetWindow(AutomationElement.FocusedElement);
            e = formAgree.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "chkAgree"));
            tgp = e.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
            tgp.Toggle();

            e = formAgree.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPrint"));
            ip = e.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            ip.Invoke();

            e = AutomationElement.FocusedElement;
            vp = e.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            vp.SetValue(DateTime.Now.ToString("yyyyMMdd-HHmmss"));

            var dialog = GetWindow(e);
            e = dialog.FindFirst(TreeScope.Descendants, new AndCondition(
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button),
                new PropertyCondition(AutomationElement.NameProperty, "保存(S)")));
            ip = e.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            ip.Invoke();

            //Assert.AreEqual(btnPrint.Current.IsEnabled, false);
        }


        private static AutomationElement GetWindow(AutomationElement element)
        {
            var walker = TreeWalker.ControlViewWalker;
            var elementParent = walker.GetParent(element);

            while (elementParent.Current.ControlType != ControlType.Window)
            {
                element = elementParent;
                elementParent = walker.GetParent(element);
            }

            return elementParent;
        }

        private void HandleTextChange(object sender, AutomationEventArgs e)
        {
            Debug.WriteLine((sender as AutomationElement).Current.AutomationId);
        }
    }
}
