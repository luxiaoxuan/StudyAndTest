using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;

namespace LXXCommon
{
    public class DisplayUtility
    {
        [DllImport("gdi32.dll")]
        private static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("gdi32.dll")]
        private static extern int GetPixel(IntPtr hdc, Point p);


        public static Bitmap CaptureForegroundWindow()
        {
            //int dpiX;

            var window = GetForegroundWindow();

            //var rect = new RECT();
            //GetWindowRect(window, ref rect);
            //var width = rect.Right - rect.Left;
            //var height = rect.Bottom - rect.Top;
            //var x = rect.Left;
            //var y = rect.Top;

            var ae = AutomationElement.FromHandle(window);
            var rect = ae.Current.BoundingRectangle;
            var width = rect.Right - rect.Left;
            var height = rect.Bottom - rect.Top;
            var x = rect.Left;
            var y = rect.Top;

            //using (var mc = new ManagementClass("Win32_DesktopMonitor"))
            //{
            //    foreach (ManagementObject each in mc.GetInstances())
            //    {
            //        dpiX = int.Parse((each.Properties["PixelsPerXLogicalInch"].Value.ToString()));

            //        break;
            //    }
            //}
            return CaptureScreen((int)x, (int)y, (int)width, (int)height);
        }

        public static Bitmap CaptureScreen()
        {
            Size screenSize = Screen.PrimaryScreen.Bounds.Size;
            return CaptureScreen(0, 0, screenSize.Width, screenSize.Height);
        }

        public static Color GetScreenPixelColor(IntPtr hwnd, Point p)
        {
            using (var graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                var color = GetPixel(graphics.GetHdc(), p);
                var r = (byte)color;
                var g = (byte)(color >> 8);
                var b = (byte)(color >> 16);

#if DEBUG
                System.Diagnostics.Trace.WriteLine("Color:" + color);
                System.Diagnostics.Trace.WriteLine("R:" + r);
                System.Diagnostics.Trace.WriteLine("G:" + g);
                System.Diagnostics.Trace.WriteLine("B:" + b);
#endif

                return Color.FromArgb(r, g, b);
            }
        }

        public static double GetScalingFactor()
        {
            double logicalScreenHeight;
            double physicalScreenHeight;
            using (var g = Graphics.FromHwnd(IntPtr.Zero))
            {
                var desktop = g.GetHdc();
                logicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.VERTRES);
                physicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);
            }

            return physicalScreenHeight / logicalScreenHeight;
        }


        private static Bitmap CaptureScreen(int x, int y, int width, int height)
        {
            var bmp = new Bitmap(width, height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(new Point(x, y), new Point(0, 0), bmp.Size);
            }
            return bmp;
        }
    }
}
