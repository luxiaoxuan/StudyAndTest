using LXXCommon;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;

namespace AutomationUITest
{
    [TestClass]
    public class TrialTest
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("gdi32.dll")]
        private static extern int SetBkColor(int hdc, int crColor);

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);


        [TestMethod]
        [TestCategory("Color")]
        public void TestGettingColor()
        {
            var x = 1000d;
            var y = 540d;
            var dpi = DisplayUtility.GetScalingFactor();
            var point1 = new Point((int)x, (int)y);
            var point2 = new Point((int)(x / dpi), (int)(y / dpi));

            //Microsoft.Test.Input.Mouse.MoveTo(point2);
            Mouse.MoveTo(point1);
            Thread.Sleep(5000);
            var color = DisplayUtility.GetScreenPixelColor(IntPtr.Zero, point1);
            Trace.WriteLine(color.Name);
        }

        [TestMethod]
        //[TestProperty("", "")]
        [TestCategory("Color")]
        public void TestGettingColor2()
        {
            var p = Process.GetProcessesByName("WindowsFormsApplicationTrial").First();
            var form = AutomationElement.FromHandle(p.MainWindowHandle);
            var txt = form.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
            var btn = form.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.AutomationIdProperty, "btnHaku"));
            //var tp = txt.GetCurrentPattern(TextPattern.Pattern) as TextPattern;
            //var value = tp.DocumentRange.GetAttributeValue(TextPattern.BackgroundColorAttribute);
            //var value2 = DisplayUtility.GetBackgroundColor((IntPtr)txt.Current.NativeWindowHandle);
            //var value3 = DisplayUtility.GetBackgroundColor((IntPtr)form.Current.NativeWindowHandle);
            //var value4 = DisplayUtility.GetTextForeColor((IntPtr)txt.Current.NativeWindowHandle);

            //var result = DisplayUtility.SetTextForeColor((IntPtr)txt.Current.NativeWindowHandle, Color.Red);

            //Trace.WriteLine(value.ToString());

            //IntPtr text = Marshal.StringToCoTaskMemUni("mang liu gede.");
            //Message.Create((IntPtr)txt.Current.NativeWindowHandle, (int)WindowsMessage.WM_SETTEXT, IntPtr.Zero, text);
            //Marshal.FreeCoTaskMem(text);

            IntPtr text = Marshal.StringToCoTaskMemUni("mang liu gede.");
            Trace.WriteLine(SendMessage((IntPtr)txt.Current.NativeWindowHandle, (int)WindowsMessage.WM_SETTEXT, IntPtr.Zero, text));
            Marshal.FreeCoTaskMem(text);

            SetForegroundWindow(p.MainWindowHandle);

            using (var g = Graphics.FromHwnd(p.MainWindowHandle))
            {
                g.FillRegion(Brushes.LightYellow, g.Clip);
                g.DrawString("maru", new Font(FontFamily.GenericSerif, 12), Brushes.Red, new PointF(30, 30));
            }

            btn.SetFocus();
            Thread.Sleep(500);
            DisplayUtility.CaptureControl(btn).Save(@"C:\Users\u851299\Desktop\bbb.bmp");
        }

        [TestMethod]
        public void TestCompareBitmap()
        {
            var bmp1 = new Bitmap(@"C:\Users\u851299\Desktop\ApplicationTest\ControlScreenShot_20160426-160032\errBD.png");
            var bmp2 = new Bitmap(@"C:\Users\u851299\Desktop\ApplicationTest\ControlScreenShot_20160426-160032\errTelNo.png");

            var result = ImageUtility.CompareBitmap(bmp1, bmp2);
            Trace.WriteLine("Result:" + result);
            Assert.IsTrue(result);
        }
    }
}
