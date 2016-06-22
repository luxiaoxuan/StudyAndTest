using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel = Microsoft.Office.Interop.Excel;

namespace LXXTestSite.Basics
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var bugList = this.GetData();
            this.rptBug.DataSource = bugList;
            this.rptBug.DataBind();
            this.ltCount.Text = bugList.Count.ToString();
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bugList = this.GetData();
            if (this.ddlStatus.SelectedValue != "全て")
            {
                bugList = bugList.Where(r => r.Mikomi == this.ddlStatus.SelectedValue).ToList();
            }

            this.rptBug.DataSource = bugList;
            this.rptBug.DataBind();
            this.ltCount.Text = bugList.Count.ToString();
        }

        private List<Bug> GetData()
        {
            var bugList = new List<Bug>();
            var wb = new Excel.Application().Workbooks.Open(@"C:\Subversion\BASICS\01 管理\70_障害管理\伝票障害一覧_最新_20160617上海記入.xlsx");
            try
            {
                var ws = wb.Worksheets[1] as Excel.Worksheet;

                var i = 6;
                var no = (ws.Cells[i, 2] as Excel.Range).Value?.ToString();
                while (no != null)
                {
                    var id = (ws.Cells[i, 1] as Excel.Range).Value?.ToString();
                    var title = (ws.Cells[i, 4] as Excel.Range).Value?.ToString();
                    var mikomi = (ws.Cells[i, 21] as Excel.Range).Value?.ToString();
                    var biko = (ws.Cells[i, 22] as Excel.Range).Value?.ToString();
                    var lackDoc = (ws.Cells[i, 23] as Excel.Range).Value?.ToString();

                    if (mikomi != null)
                    {
                        bugList.Add(new Bug
                        {
                            Id = id,
                            No = no,
                            Title = title,
                            Mikomi = mikomi,
                            Biko = biko,
                            LackDoc = lackDoc,
                        });
                    }

                    i++;
                    no = (ws.Cells[i, 2] as Excel.Range).Value?.ToString();
                }
            }
            finally
            {
                wb.Close(true);
            }

            return bugList;
        }
    }
}