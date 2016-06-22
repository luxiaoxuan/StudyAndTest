<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BugDetail.aspx.cs" Inherits="LXXTestSite.Basics.BugDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>障害詳細</title>
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

        table td:nth-child(2n+1) {
            color: gray;
        }
    </style>
</head>
<body>
    <table class="table">
        <caption class="h1 text-center">障害詳細</caption>
        <tbody>
            <asp:Repeater ID="rptRow" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="col-md-2"><%# Eval("Name") %></td>
                        <td>
                            <%# Eval("Value") %>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</body>
</html>
