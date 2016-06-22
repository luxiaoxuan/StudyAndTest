using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel = Microsoft.Office.Interop.Excel;

namespace LXXTestSite.Basics
{
    public partial class BugDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var no = this.Request.QueryString["TicketNo"];
            var bug = this.GetData(no);

            this.rptRow.DataSource = bug.Details.Select(p => new
            {
                Name = p.Key,
                Value = p.Value,
            });
            this.rptRow.DataBind();

            this.Title = this.Title + string.Format("＜{0}＞", no);
        }

        private Bug GetData(string ticketNo)
        {
            var bug = new Bug
            {
                Details = new Dictionary<string, string>(),
            };
            var wb = new Excel.Application().Workbooks.Open(@"C:\Subversion\BASICS\01 管理\70_障害管理\伝票障害一覧_最新_20160617上海記入.xlsx");
            try
            {
                var ws = wb.Worksheets[1] as Excel.Worksheet;

                var r = 6;
                var cNo = ws.Cells[r, 2] as Excel.Range;
                var no = cNo.Value?.ToString();
                while (no != null)
                {
                    if (no == ticketNo)
                    {
                        var c = 1;
                        var cName = ws.Cells[4, c] as Excel.Range;
                        var name = cName.Value;
                        while (name != null)
                        {
                            bug.Details.Add(
                                name.ToString(),
                                (ws.Cells[r, c] as Excel.Range).Value?.ToString()
                                    .Replace("\r\n", "<br />")
                                    .Replace("\r", "<br />")
                                    .Replace("\n", "<br />")
                            );

                            c++;
                            cName = ws.Cells[4, c] as Excel.Range;
                            name = cName.Value;
                        }

                        break;
                    }

                    r++;
                    cNo = ws.Cells[r, 2] as Excel.Range;
                    no = cNo.Value?.ToString();
                }
            }
            finally
            {
                wb.Close(true);
            }

            return bug;
        }
    }
}