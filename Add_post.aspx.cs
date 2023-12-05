using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum_fianl
{
    public partial class Add_post : System.Web.UI.Page
    {
        string userName;
        string userId;


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["myName"] != null)
            {
                userName = Session["myName"].ToString();
                userId = Session["userId"].ToString();
            }
            //else 
            //{
            //    建議重新導向到Login Page
            //}
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            //TC：連線資料庫，可以效仿 List_hyper 頁面，使用db.ConnectDb()等作法，減少下方程式碼撰寫
            #region  "連線資料庫"   

            //建立SQL連接的物件 方法1. V

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Forum1ConnectionString"].ConnectionString);


            // 判斷是否已連接，沒有連接才連接
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            #endregion "連線資料庫"

            // 建立要操作SQL的指令物件
            SqlCommand sqlCommand = new SqlCommand();



            // 連接到哪個資料庫
            sqlCommand.Connection = connection;


            // SQL 語法

            string s1 = "DECLARE @postId TABLE (Id INT); DECLARE @listId TABLE (Id INT);";
            string s2 = $"insert into Post([User], Title,Content, UserId, ListId) OUTPUT INSERTED.Id INTO @postId Values(@userName,@title,@content,@userId,13)";

            string s3 = "DECLARE @postIdValue INT; SELECT @postIdValue = Id FROM @postId;";
            string s4 = $"INSERT INTO List(Title,[User], PostDate,  PostId, UserId) OUTPUT INSERTED.Id INTO @listId VALUES(@title,@userName,  GETDATE(), @postIdValue, @userId);";

            string s5 = "DECLARE @listIdValue INT; SELECT @listIdValue = Id FROM @listId; UPDATE Post SET ListId = @listIdValue WHERE Id=@postIdValue";
            //TC：我目前是沒有用DECLARE宣告SQL變數，是否有此必要，可以在衡量，畢竟，相關的變數都是透過下方的paramert設定了


            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.Parameters.AddWithValue("@title", titleBox.Text);
            sqlCommand.Parameters.AddWithValue("@userId", userId);
            sqlCommand.Parameters.AddWithValue("@content", contentBox.Text);







            // 將準備的SQL指令給操作物件
            sqlCommand.CommandText = s1+s2+s3+s4+s5;


            // 執行非查詢的資料庫指令，ExecuteNonQuery()會回傳受影響的資料數目
            int f = sqlCommand.ExecuteNonQuery();

            if (f != 0)
            {
                Response.Write(("<script>alert('新增成功');</script>"));
            }
            else
            {
                Response.Write(("<script>alert('新增失敗');</script>"));
            }



            






        }
    }
}