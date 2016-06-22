<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BugList.aspx.cs" Inherits="LXXTestSite.Basics.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>障害一覧</title>
    <link rel="stylesheet" href="../Content/bootstrap.min.css" />
    <link rel="stylesheet" href="../Content/bootstrap-theme.min.css" />
    <script type="text/javascript" src="../Scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap.min.js"></script>
    <style type="text/css">
        body {
            font-family: HGGyoshotai;
            font-size: 2em;
            margin: 20px auto;
            width: 90%;
        }
    </style>
</head>
<body>
    <form runat="server">
        <table class="table">
            <caption class="h1 text-center">障害一覧</caption>
            <thead>
                <tr>
                    <td colspan="5">件数：
                    <asp:Literal ID="ltCount" runat="server" />
                    </td>
                    <td style="text-align: right;">
                        <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
                            <asp:ListItem Value="全て" />
                            <asp:ListItem Value="○" />
                            <asp:ListItem Value="△" />
                            <asp:ListItem Value="×" />
                        </asp:DropDownList>
                    </td>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptBug" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Id") %></td>
                            <td>
                                <asp:DynamicHyperLink runat="server" Text='<%# Eval("No") %>'
                                    NavigateUrl='<%# "~/Basics/BugDetail.aspx?TicketNo=" + Eval("No").ToString() %>' />
                            </td>
                            <td><%# Eval("Mikomi") %></td>
                            <td style="width: 25%;"><%# Eval("Biko") %></td>
                            <td style="width: 25%;"><%# Eval("LackDoc") %></td>
                            <td><%# Eval("Title") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </form>
</body>
</html>
