<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add_post.aspx.cs" Inherits="Forum_fianl.Add_post" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            標題：<asp:TextBox ID="titleBox" runat="server"></asp:TextBox>
            <br />
            <br />
            內容：<br />
            <asp:TextBox ID="contentBox" runat="server" CssClass="auto-style1" Height="180px" TextMode="MultiLine" Width="233px"></asp:TextBox>

            <br />
            <br />
            <asp:Button ID="submitBtn" runat="server" Text="送出" OnClick="submitBtn_Click" />

        </div>
    </form>
</body>
</html>
