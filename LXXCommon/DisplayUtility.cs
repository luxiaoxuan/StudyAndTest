using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Automation;
using System.Windows.Forms;

namespace LXXCommon
{
    public class DisplayUtility
    {
        [DllImport("gdi32.dll")]
        private static extern int GetBkColor(IntPtr hdc);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("gdi32.dll")]
        private static extern int GetTextColor(IntPtr hdc);

        [DllImport("gdi32.dll")]
        private static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("gdi32.dll")]
        private static extern int GetPixel(IntPtr hdc, Point p);

        [DllImport("gdi32.dll")]
        private static extern int SetTextColor(IntPtr hdc, int crColor);


        public static Bitmap CaptureControl(AutomationElement ae)
        {
            var rect = ae.Current.BoundingRectangle;
            var width = rect.Right - rect.Left;
            var height = rect.Bottom - rect.Top;
            var x = rect.Left;
            var y = rect.Top;

            return CaptureScreen((int)x, (int)y, (int)width, (int)height);
        }

        public static Bitmap CaptureControl(IntPtr hwnd)
        {
            var ae = AutomationElement.FromHandle(hwnd);
            
            return CaptureControl(ae);
        }

        public static Bitmap CaptureForegroundWindow()
        {
            var window = GetForegroundWindow();

            var ae = AutomationElement.FromHandle(window);
            var rect = ae.Current.BoundingRectangle;
            var width = rect.Right - rect.Left;
            var height = rect.Bottom - rect.Top;
            var x = rect.Left;
            var y = rect.Top;

            return CaptureScreen((int)x, (int)y, (int)width, (int)height);
        }

        public static Bitmap CaptureScreen()
        {
            Size screenSize = Screen.PrimaryScreen.Bounds.Size;
            return CaptureScreen(0, 0, screenSize.Width, screenSize.Height);
        }

        public static int GetBackgroundColor(IntPtr hwnd)
        {
            var ptr = GetDC(hwnd);

            return GetBkColor(ptr);
        }

        public static int GetTextForeColor(IntPtr hwnd)
        {
            var ptr = GetDC(hwnd);

            return GetTextColor(ptr);
        }

        public static Color GetScreenPixelColor(IntPtr hwnd, Point p)
        {
            using (var graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                var color = GetPixel(graphics.GetHdc(), p);

                return ColorTranslator.FromWin32(color);
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

        public static int SetTextForeColor(IntPtr hwnd, Color color)
        {
            var hdc = GetDC(hwnd);

            return SetTextColor(hdc, ColorTranslator.ToWin32(color));
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
