using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplicationTrial
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //SetProcessDPIAware();// ここかマニフェストかに指定することでDpiバーチャルを使わないとする
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var dpiX = 0f;
            var dpiY = 0f;
            using (var graphics = System.Drawing.Graphics.FromHwnd(IntPtr.Zero))
            {
                dpiX = graphics.DpiX;
                dpiY = graphics.DpiY;
            }
            //MessageBox.Show(string.Format("DpiX: {0}\r\nDpiY: {1}", dpiX, dpiY));

            Application.Run(new ColorTestForm());
        }

        [DllImport("user32.dll")]
        public extern static IntPtr SetProcessDPIAware();
    }
}
