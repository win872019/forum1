<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Post-hyper.aspx.cs" Inherits="Forum_fianl.Post_hyper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>




<link rel="stylesheet" type="text/css" href="listStyle.css" />







</head>
<body>
    <form id="form1" runat="server">
        <div>            


            <asp:Button ID="createBtn" runat="server" Text="新增" Visible="False" OnClick="createBtn_Click" />
            <asp:Button ID="editBtn" runat="server" Text="編輯" Visible="False" OnClick="editBtn_Click" />
            <asp:Button ID="deleteBtn" runat="server" Text="刪除" Visible="False" OnClick="deleteBtn_Click" />


            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="List_hyper.aspx">留言板列表</asp:HyperLink>

            <asp:DetailsView ID="DetailsView1" runat="server"  AutoGenerateRows="False" CssClass="listSty">

                <Fields>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="false" />
                    <asp:BoundField DataField="User" HeaderText="發表者" SortExpression="User" Visible="true" />
                    <asp:BoundField DataField="Title" HeaderText="標題" SortExpression="Title" Visible="true" />
                    <asp:BoundField DataField="Content" HeaderText="內容" SortExpression="Content" Visible="true" />
                    <asp:BoundField DataField="PostDate" HeaderText="留言日期" SortExpression="PostDate" Visible="true" />
                    <asp:BoundField DataField="UpdateDate" HeaderText="更新日期" SortExpression="UpdateDate" Visible="true" />
                    <asp:BoundField DataField="UserId" HeaderText="UserId" SortExpression="UserId" Visible="true" />
                    <asp:BoundField DataField="ListId" HeaderText="ListId" SortExpression="ListId" Visible="false" />
                </Fields>

            </asp:DetailsView>
            <br />
            <br />
            <asp:TextBox ID="replyMes" runat="server" Visible="False"  Height="60px" Width="590px" CssClass="auto-style1" TextMode="MultiLine" Text=" "></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="replyBtn" runat="server" Text="回覆" Visible="False" CssClass="auto-style2" Height="30px" Width="70px" OnClick="replyBtn_Click"/>




        </div>




        <h3>留言回覆</h3> 
        <%-- OnItemDataBound="ListView1_ItemDataBound" --%>
            <asp:ListView ID="ListView1" runat="server" DataKeyNames="Id"  >
                <LayoutTemplate>
                    <div runat="server" id="itemPlaceholder"></div>
                </LayoutTemplate>
                <ItemTemplate>
                    <div class="replySty">
                        <p class="user">回覆者： <b ><%# Eval("User") %></b></p>
                        <p><%# Eval("Content") %></p>
                        <br />
                        <br />
                        <p class="replyDate">回覆時間：<%# Eval("ReplyDate") %></p>
                        <br />

                    </div>
                </ItemTemplate>
            </asp:ListView>


            
    <script>
        // 顯示視窗的函式
        function showPopup() {
            // 打開新視窗
            var popup = window.open('', '_blank', 'width=300,height=200');

            // 在新視窗中寫入 HTML 內容
            popup.document.write('<html><head><title>Popup</title></head><body>');
            popup.document.write('<h1>Popup Window</h1>');
            popup.document.write('<button onclick="continueWorkflow()">Continue</button>');
            popup.document.write('</body></html>');
        }

        // 新視窗中按鈕的函式
        function continueWorkflow() {
            // 在這裡執行接下來的工作
            alert("Workflow continued!");
            // 關閉新視窗
            window.close();
        }
    </script>










    </form>









</body>
</html>
