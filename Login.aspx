<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <table>
            <tr>
                <td>
                    username:</td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" Width="116px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    password:</td>
                <td>
                    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Width="117px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnLogin" runat="server" Text="login" OnClick="btnLogin_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="cancel" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
