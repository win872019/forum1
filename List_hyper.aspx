<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List_hyper.aspx.cs" Inherits="Forum_fianl.List_hyper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <link rel="stylesheet" type="text/css" href="listStyle.css" />

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            
            <asp:Label ID="WelcomeText" runat="server" Text=""></asp:Label>
            
            <asp:Button ID="LoginBtn" runat="server" Text="登入" Visible="True" OnClick="LoginBtn_Click"  CssClass="btn" />


            <asp:Button ID="CreateBtn" runat="server" Text="新增留言" Visible="True" OnClick="CreateBtn_Click" />
           
            <asp:Button ID="LogoutBtn" runat="server" Text="登出" Visible="True" OnClick="LogoutBtn_Click"/>








            <br />








            <br />
            
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="listSty" >
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" Visible="false" />

                    <%-- 連結對應 Post內容 --%>
                    <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Post-hyper.aspx?ID={0}" DataTextField="Title" HeaderText="標題"/>

                    <asp:BoundField DataField="User" HeaderText="發表者" SortExpression="User" />
                    <asp:BoundField DataField="PostDate" HeaderText="發表日期" SortExpression="PostDate" />

                    <asp:BoundField DataField="ReplyAmount" HeaderText="ReplyAmount" SortExpression="ReplyAmount" />
                    <asp:BoundField DataField="PostId" HeaderText="PostId" SortExpression="PostId" Visible="false"/>
                    <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" Visible="false"/>

                </Columns>
            </asp:GridView>








        </div>
    </form>
</body>
</html>
