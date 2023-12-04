<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_hyper.aspx.cs" Inherits="Forum_fianl.Login_hyper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Email:
            <asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox><br />
            <br />
            密碼:
            <asp:TextBox ID="PasswordTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="LoginButton" runat="server" Text="登入" OnClick="LoginButton_Click" />
            <asp:Label ID="StatusLabel" runat="server" Text=""></asp:Label><br />
            <br />
            <%--<asp:Button ID="LogoutButton" runat="server" Text="登出" OnClick="LogoutButton_Click" /><br />--%>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="List_hyper.aspx">留言板列表</asp:HyperLink>
        </div>
    </form>
</body>
</html>
