using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplicationTrial
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void btnFontPoint_Click(object sender, EventArgs e)
        {
            new FormFontPoint().Show();
        }

        private void btnFontPixel_Click(object sender, EventArgs e)
        {
            new FormFontPixel().Show();
        }


        private void btnDPIPoint_Click(object sender, EventArgs e)
        {
            new FormDpiPoint().Show();
        }

        private void btnDPIPixel_Click(object sender, EventArgs e)
        {
            new FormDpiPixel().Show();
        }


        private void btnNonePoint_Click(object sender, EventArgs e)
        {
            new FormNonePoint().Show();
        }

        private void btnNonePixel_Click(object sender, EventArgs e)
        {
            new FormNonePixel().Show();
        }
    }
}
