using LXXCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplicationTrial
{
    public partial class ColorTestForm : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("gdi32.dll")]
        private static extern int GetBkColor(IntPtr hdc);

        [DllImport("gdi32.dll")]
        private static extern int GetTextColor(IntPtr hdc);

        [DllImport("gdi32.dll")]
        private static extern int SetBkColor(int hdc, int crColor);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);


        private const int WM_ACTIVATEAPP = 0x001C;

        private bool appActive = true;


        public ColorTestForm()
        {
            InitializeComponent();

            this.txtCnc.ForeColorChanged += TxtCnc_ForeColorChanged;
            this.txtCnc.TextChanged += TxtCnc_TextChanged;
        }

        private void TxtCnc_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Text changed!");
        }

        private void TxtCnc_ForeColorChanged(object sender, EventArgs e)
        {
            MessageBox.Show("ForeColor changed!");
        }

        private void btnHaku_Click(object sender, EventArgs e)
        {
            //IntPtr text = Marshal.StringToCoTaskMemUni("mang liu gede.");
            //Message.Create((IntPtr)this.txtCnc.Handle, (int)WindowsMessage.WM_SETTEXT, IntPtr.Zero, text);
            //Marshal.FreeCoTaskMem(text);

            //SendMessage(this.txtCnc.Handle, (int)WindowsMessage.WM_SETTEXT, IntPtr.Zero, "mang liu gede.");

            using (var g = this.CreateGraphics())
            {
                g.FillRegion(Brushes.ForestGreen, g.Clip);
                g.DrawString("kaka", new Font(FontFamily.GenericSerif, 12), Brushes.Red, new PointF(0, 0));
            }

            var bmp = new Bitmap(this.btnHaku.Width, this.btnHaku.Height);
            this.btnHaku.DrawToBitmap(bmp, this.btnHaku.ClientRectangle);
            bmp.Save(@"C:\Users\u851299\Desktop\aaa.bmp");
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            // Paint a string in different styles depending on whether the
            // application is active.
            if (appActive)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Green), 10, 50, 150, 50);
                e.Graphics.DrawString("Application is active", this.Font, new SolidBrush(Color.White), 10, 70);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Blue), 10, 50, 150, 50);
                e.Graphics.DrawString("Application is Inactive", this.Font, new SolidBrush(Color.White), 10, 70);
            }
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            // Listen for operating system messages.
            switch (m.Msg)
            {
                // The WM_ACTIVATEAPP message occurs when the application
                // becomes the active application or becomes inactive.
                case (int)WindowsMessage.WM_ACTIVATEAPP:

                    // The WParam value identifies what is occurring.
                    appActive = (((int)m.WParam != 0));

                    // Invalidate to get new text painted.
                    //this.Invalidate();

                    break;
                case (int)WindowsMessage.WM_CTLCOLOR:
                    Trace.WriteLine(m.HWnd);
                    break;
                case (int)WindowsMessage.WM_CTLCOLOREDIT:
                    Trace.WriteLine("HWnd:" + m.HWnd + ",WParam:" + m.WParam + ",LParam:" + m.LParam + ",txtCnc:" + this.txtCnc.Handle);
                    //SetBkColor((int)m.LParam, ColorTranslator.ToWin32(Color.Red));
                    //SetBkColor((int)GetDC(m.LParam), ColorTranslator.ToWin32(Color.Red));
                    //SetBkColor((int)GetDC(this.txtCnc.Handle), ColorTranslator.ToWin32(Color.Red));
                    Trace.WriteLine("BkColor:" + ColorTranslator.FromWin32(GetBkColor(GetDC(this.txtCnc.Handle))));
                    break;
            }
            base.WndProc(ref m);
        }
    }
}
