using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LXXCommon
{
    public class ScreenCapturer
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }


        public static Bitmap CaptureForegroundWindow()
        {
            var window = GetForegroundWindow();
            var rect = new RECT();
            GetWindowRect(window, ref rect);
            var width = rect.Right - rect.Left;
            var height = rect.Bottom - rect.Top;
            var x = rect.Left;
            var y = rect.Top;

            //using (var mc = new ManagementClass("Win32_DesktopMonitor"))
            //{
            //    foreach (ManagementObject each in mc.GetInstances())
            //    {
            //        var dpiX = float.Parse((each.Properties["PixelsPerXLogicalInch"].Value.ToString()));
            //        var dpiY = float.Parse((each.Properties["PixelsPerYLogicalInch"].Value.ToString()));

            //        x = (int)(dpiX / 96f * x);
            //        y = (int)(dpiY / 96f * y);
            //        width = (int)(dpiX / 96f * width);
            //        height = (int)(dpiY / 96f * height);

            //        break;
            //    }
            //}

            //using (var graphics = Graphics.FromHwnd(IntPtr.Zero))
            //{
            //    x = (int)(graphics.DpiX / 96f * x);
            //    y = (int)(graphics.DpiY / 96f * y);
            //    width = (int)(graphics.DpiX / 96f * width);
            //    height = (int)(graphics.DpiY / 96f * height);
            //}

            return CaptureScreen(x, y, width, height);
        }

        public static Bitmap CaptureScreen()
        {
            Size screenSize = Screen.PrimaryScreen.Bounds.Size;
            return CaptureScreen(0, 0, screenSize.Width, screenSize.Height);
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
