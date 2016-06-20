using LXXTestSite.Basics.BugDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LXXTestSite.Basics
{
    public partial class BugDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dt = new BugsTableAdapter().GetData();
            var bug = dt.First(r => r.F2 == this.Request.QueryString["TicketNo"]);
            var names = new string[]
            {
                "No.",
                "チケットNo.",
                "ステータス",
                "題名",
                "発生日",
                "ＭＤ区分",
                "業務所管",
                "優先度MRI",
                "優先度DCS",
                "優先度MD",
                "調整メモ",
                "対応チーム",
                "ｽﾃｰﾀｽ",
                "本番ﾘﾘｰｽ予定日",
                "暫定対応",
                "調査",
                "恒久対応承認",
                "実装",
                "検証ﾘﾘｰｽ予定日",
                "業務検証",
                "障害発生機能名",
                "障害内容＿詳細",
                "顧客対応内容",
                "社内対応内容",
                "システム対応内容",
                "暫定対応承認日_MRI",
                "暫定対応承認者_MRI",
                "暫定対応承認日_DCS",
                "暫定対応承認者_DCS",
                "原因システム",
                "表層原因",
                "恒久対応内容",
                "＃恒久対応承認日_MRI",
                "＃恒久対応承認者_MRI",
                "＃恒久対応承認日_DCS",
                "＃恒久対応承認者_DCS",
                "検証環境リリース予定日",
                "検証環境リリース実施日",
                "テスト結果確認方法",
                "テスト結果業務所管確認日_MRI",
                "テスト結果業務所管確認結果_MRI",
                "テスト結果業務所管確認者_MRI",
                "テスト結果業務所管確認日_DCS",
                "テスト結果業務所管確認結果_DCS",
                "テスト結果業務所管確認者_DCS",
                "説明",
            };

            var ds = new List<dynamic>();
            for (var i = 0; i < dt.Columns.Count; i++)
            {
                var c = bug[i]?.ToString().Replace("_x000D_", string.Empty).Replace("\n", "<br />");

                ds.Add(new
                {
                    Name = names[i],
                    Content = c,
                });
            }

            this.rptRow.DataSource = ds;
            this.rptRow.DataBind();
        }
    }
}