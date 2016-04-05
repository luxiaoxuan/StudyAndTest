using System;
using System.Collections.Generic;
using System.Linq;
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
            Application.Run(new Form());
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public extern static IntPtr SetProcessDPIAware();
    }
}
