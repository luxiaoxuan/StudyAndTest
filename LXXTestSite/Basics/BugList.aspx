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
            width: 60%;
        }
    </style>
</head>
<body>
    <table class="table">
        <caption class="h1 text-center">障害一覧</caption>
        <tbody>
            <asp:Repeater ID="rptBug" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("F1") %></td>
                        <td><%# Eval("F2") %></td>
                        <td><%# Eval("F8") %></td>
                        <td><%# Eval("F9") %></td>
                        <td><%# Eval("F10") %></td>
                        <td>
                            <asp:DynamicHyperLink runat="server" Text='<%# Eval("F4") %>'
                                NavigateUrl='<%# "~/Basics/BugDetail.aspx?TicketNo=" + Eval("F2").ToString() %>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</body>
</html>
