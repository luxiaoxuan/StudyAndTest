using LXXCommon;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;

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
    }
}
