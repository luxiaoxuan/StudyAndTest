using LXXCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplicationTrial
{
    public partial class ColorTestForm : Form
    {
        public ColorTestForm()
        {
            InitializeComponent();
        }

        private void btnHaku_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(
            //    "BackgroundColor:" +
            //    ColorTranslator.FromWin32(DisplayUtility.GetBackgroundColor(this.Handle)).Name +
            //    "\r\nTextColor:" +
            //    ColorTranslator.FromWin32(DisplayUtility.GetTextForeColor(this.Handle)).Name);

            DisplayUtility.SetTextForeColor(this.txtCnc.Handle, Color.Red);
            //this.Refresh();
        }
    }
}
