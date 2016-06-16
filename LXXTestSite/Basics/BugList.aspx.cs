using LXXTestSite.Basics.BugDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LXXTestSite.Basics
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dt = new BugDataSet().Bugs;
            new BugsTableAdapter().Fill(dt);

            this.rptBug.DataSource = dt.Where(r => !r.IsF2Null() && !r.IsF4Null() && "#Num!" != r.F2 && "#N/A" != r.F4);
            this.rptBug.DataBind();
        }
    }
}