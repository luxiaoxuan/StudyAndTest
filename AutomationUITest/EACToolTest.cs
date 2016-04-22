﻿using LXXCommon;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;

namespace AutomationUITest
{
    [TestClass]
    public class EACToolTest
    {
        private Process _smartApplicationProcess;


        [TestInitialize]
        public void StartSmartApplication()
        {
            try
            {
                foreach (var p in Process.GetProcessesByName("SmartApplication"))
                {
                    p.Kill();

                }
            }
            catch { }

            Trace.WriteLine("screen dpi:" + DisplayUtility.GetScalingFactor());

            var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\SmartApplication");
            var path = Path.Combine(key.GetValue("installDir").ToString(), "SmartApplication.exe");

            this._smartApplicationProcess = Process.Start(path);
            while (this._smartApplicationProcess.MainWindowHandle == IntPtr.Zero)
            {
                Thread.Sleep(500);
            }
        }

        [TestCleanup]
        public void CloseSmartApplication()
        {
            try
            {
                foreach (var p in Process.GetProcessesByName("SmartApplication"))
                {
                    p.Kill();

                }
            }
            catch { }
        }


        [TestMethod]
        public void InputUserSetting()
        {
            System.Windows.Rect rect;
            InvokePattern ip;
            ValuePattern vp;

            var formMenu = AutomationElement.FromHandle(this._smartApplicationProcess.MainWindowHandle);

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
            Clipboard.SetText("これがクリップボードからの内容だよ！");
            #region テキストボックスのコンテキストメニューを開く
            #region 方法Ⅰ：テキストボックスにフォーカスを入れて「Shift」+「F10」キーを押す
            //txtName.SetFocus();
            //SendKeys.SendWait("+{F10}");
            //Thread.Sleep(500);
            #endregion
            #region 方法Ⅰ：マウスをテキストボックスに移動して右クリックする
            rect = txtName.Current.BoundingRectangle;
            Mouse.MoveTo(new Point(
                (int)((rect.Left + rect.Right) / 2),
                (int)((rect.Top + rect.Bottom) / 2)));
            Mouse.RightClick();
            Thread.Sleep(500);
            #endregion
            #endregion

            var contextMenu = AutomationElement.RootElement.FindFirst(TreeScope.Children,
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Menu));
            var contextMenuItems = contextMenu.FindAll(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.MenuItem));
            foreach (AutomationElement r in contextMenuItems)
            {
                try
                {
                    if (r.Current.Name == "貼り付け(P)")
                    {
                        rect = r.Current.BoundingRectangle;
                        Mouse.MoveTo(new Point(
                            (int)((rect.Left + rect.Right) / 2),
                            (int)((rect.Top + rect.Bottom) / 2)));
                        Thread.Sleep(500);
                        Mouse.LeftClick();

                        break;
                    }
                }
                catch (Exception e)
                {
                    Trace.WriteLine("rai:" + e.StackTrace);
                }
            }

            var txtCompany = formUserSetting.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document));
            txtCompany.SetFocus();
            SendKeys.SendWait("何じゃら日本語");

            #region 色取得試し
            rect = txtTitle.Current.BoundingRectangle;
            var point = new Point(
                (int)((rect.Left + rect.Right) / 2),
                (int)((rect.Top + rect.Bottom) / 2));
            Thread.Sleep(500);
            var color = DisplayUtility.GetScreenPixelColor(IntPtr.Zero, point);
            Trace.WriteLine("Color:" + color.Name);
            #endregion

            var btnSave = formUserSetting.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "btnSave"));
            var btnCancel = formUserSetting.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "btnCancel"));
            btnCancel.SetFocus();

            Assert.AreEqual(btnSave.Current.IsEnabled, false);
            Assert.AreEqual(btnCancel.Current.IsEnabled, true);

            Thread.Sleep(2000);
        }

        [TestMethod]
        public void TakeScreenShots()
        {
            InvokePattern ip;
            ValuePattern vp;
            ScrollPattern scp;
            SelectionItemPattern sp;
            TogglePattern tgp;

            var formMenu = AutomationElement.FromHandle(this._smartApplicationProcess.MainWindowHandle);

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

            var timeStamp = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "ApplicationTest");

            Thread.Sleep(1000);
            scp.ScrollVertical(ScrollAmount.LargeDecrement);
            Thread.Sleep(1000);
            var bmp = DisplayUtility.CaptureForegroundWindow();
            bmp.Save(Path.Combine(path, timeStamp + "_001.bmp"));

            Thread.Sleep(1000);
            scp.ScrollVertical(ScrollAmount.LargeIncrement);
            Thread.Sleep(1000);
            bmp = DisplayUtility.CaptureForegroundWindow();
            bmp.Save(Path.Combine(path, timeStamp + "_002.bmp"));

            Thread.Sleep(1000);
            scp.ScrollVertical(ScrollAmount.LargeIncrement);
            Thread.Sleep(1000);
            bmp = DisplayUtility.CaptureForegroundWindow();
            bmp.Save(Path.Combine(path, timeStamp + "_003.bmp"));

            var btnPrint = form.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPrint"));
            Assert.AreEqual(btnPrint.Current.IsEnabled, false);
        }

        [TestMethod]
        public void PrintPDF()
        {
            AutomationElement e;
            InvokePattern ip;
            ValuePattern vp;
            SelectionItemPattern sp;
            TogglePattern tgp;

            var formMenu = AutomationElement.FromHandle(this._smartApplicationProcess.MainWindowHandle);

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

            Thread.Sleep(2000);
            e = AutomationElement.FocusedElement;
            ip = e.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            ip.Invoke();

            Thread.Sleep(2000);
            var formAgree = GetWindow(AutomationElement.FocusedElement);
            e = formAgree.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "chkAgree"));
            tgp = e.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
            tgp.Toggle();

            e = formAgree.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "btnPrint"));
            ip = e.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            ip.Invoke();

            Thread.Sleep(2000);
            e = AutomationElement.FocusedElement;
            var dialog = GetWindow(e);
            vp = e.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            // way 1
            //vp.SetValue(@"C:\Users\u851299\Desktop\ApplicationTest\" + DateTime.Now.ToString("yyyyMMdd-HHmmss"));

            // way 2
            vp.SetValue(DateTime.Now.ToString("yyyyMMdd-HHmmss"));
            var bar = dialog.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ClassNameProperty, "ReBarWindow32"));
            e = bar.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "前の場所"));
            ip = e.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            ip.Invoke();
            SendKeys.SendWait(@"C:\Users\u851299\Desktop\ApplicationTest\");
            SendKeys.SendWait("{enter}");
            //Thread.Sleep(3000);

            e = dialog.FindFirst(TreeScope.Descendants, new AndCondition(
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button),
                new PropertyCondition(AutomationElement.NameProperty, "保存(S)")));
            ip = e.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            ip.Invoke();

            Thread.Sleep(2000);
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



        #region ドラフト

        Func<int, int, int> Add;

        private void Rai(Func<int, int, int> add)
        {
            this.Add = add;
        }

        private void Cnc(string id)
        {
            this.Rai((a, b) => { return a / 2 + b / 2; });

            this.GetData(string.Format("SELECT NAME FROM TABLE WHERE ID = '{0}'", id),
                name => MessageBox.Show("Name is '" + name + "' for id<" + id + ">!"));

            this.GetNameAsync("001",
                name => MessageBox.Show("Name is '" + name + "' for id<" + id + ">!"));
            MessageBox.Show("Ahahaha");
        }

        private void GetData(string sql, Action<string> callback)
        {
            var result = "";//execute "sql" and return "result"

            callback(result);
        }

        private Task<string> GetName(string sql)
        {
            return Task.Run<string>(() =>
            {
                Thread.Sleep(5000);
                var flg = sql.Contains("Rai");
                return "Rai<" + flg + ">";
            });
        }

        private async void GetNameAsync(string id, Action<string> callback)
        {
            var name = await this.GetName(string.Format("SELECT NAME FROM TABLE WHERE ID = '{0}'", id));

            callback(name);
        }

        #endregion
    }
}
