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
    public class ScreenCapturer
    {
        //[DllImport("user32.dll")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        //[StructLayout(LayoutKind.Sequential)]
        //private struct RECT
        //{
        //    public int Left;
        //    public int Top;
        //    public int Right;
        //    public int Bottom;
        //}


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
            var rect2 = ae.Current.BoundingRectangle;
            var width2 = rect2.Right - rect2.Left;
            var height2 = rect2.Bottom - rect2.Top;
            var x2 = rect2.Left;
            var y2 = rect2.Top;

            //using (var mc = new ManagementClass("Win32_DesktopMonitor"))
            //{
            //    foreach (ManagementObject each in mc.GetInstances())
            //    {
            //        dpiX = int.Parse((each.Properties["PixelsPerXLogicalInch"].Value.ToString()));

            //        break;
            //    }
            //}
            return CaptureScreen((int)x2, (int)y2, (int)width2, (int)height2);
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
