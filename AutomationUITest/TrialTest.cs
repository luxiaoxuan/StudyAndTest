using LXXCommon;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Automation;

namespace AutomationUITest
{
    [TestClass]
    public class TrialTest
    {
        [TestMethod]
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
        public void TestGettingColor2()
        {
            var p = Process.GetProcessesByName("WindowsFormsApplicationTrial").First();
            var form = AutomationElement.FromHandle(p.MainWindowHandle);
            var txt = form.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
            var tp = txt.GetCurrentPattern(TextPattern.Pattern) as TextPattern;
            var value = tp.DocumentRange.GetAttributeValue(TextPattern.BackgroundColorAttribute);
            var value2 = DisplayUtility.GetBackgroundColor((IntPtr)txt.Current.NativeWindowHandle);
            var value3 = DisplayUtility.GetBackgroundColor((IntPtr)form.Current.NativeWindowHandle);
            var value4 = DisplayUtility.GetTextForeColor((IntPtr)txt.Current.NativeWindowHandle);

            DisplayUtility.SetTextForeColor(txt.Current.NativeWindowHandle, Color.Red);

            Trace.WriteLine(value.ToString());
        }
    }
}
