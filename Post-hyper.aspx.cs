using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum_fianl
{
    public partial class Post_hyper : System.Web.UI.Page
    {

        SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Forum1ConnectionString"].ConnectionString);

        // 建立要操作SQL的指令物件
        SqlCommand sqlCommand = new SqlCommand();


        string post_qString, userName, userId;        

        string sql= $"SELECT * FROM Post WHERE Id =@Id";

        

        DbTool dbTool = new DbTool();



        protected void Page_Load(object sender, EventArgs e)
        {

            post_qString = Request.QueryString["ID"];
            dbTool.showDB_DetailsView(sql, "@Id", post_qString, DetailsView1);



            if (Session["myName"] != null && Session["userId"] != null)
            {
                userName = Session["myName"].ToString();
                userId = Session["userId"].ToString();
            }



            // 取得 DetailsView 欄位的值
            string user_row = DetailsView1.Rows[1].Cells[1].Text;
            string userId_row = DetailsView1.Rows[6].Cells[1].Text;

            // 已登入
            if (Session["myName"] != null && Session["userId"] != null)
            {
                // 使用者進自己的Post
                if (Session["myName"].ToString() == user_row && Session["userId"].ToString() == userId_row)
                {
                    createBtn.Visible = true;
                    editBtn.Visible = true;
                    deleteBtn.Visible = true;

                    // 問題： .aspx 的 UserId 欄位設定 Visible ="false" 時，.aspx.cs 讀出來的值無法顯示(但沒有報錯); 對照： User(string)設 Visible ="false" 時，卻可讀可顯示
                    DetailsView1.Fields[6].Visible = false;



                }
                else
                {
                    DetailsView1.Fields[6].Visible = false;

                    replyMes.Visible = true;
                    replyBtn.Visible = true;
                }
            }
            else
            {
                DetailsView1.Fields[6].Visible = false;
            }


            // 留言回覆顯示

            string replySql = $"select * from Reply where PostId={post_qString}";


            dbTool.showDB_ListView(replySql, ListView1);










        }




        protected void replyBtn_Click(object sender, EventArgs e)
        {
            if(replyMes.Text!=null && replyMes.Text !=" ") 
            {
                string sql_reply = $"Insert into Reply([User],Content,UserId,PostId) Values(@userName,@replyText,@userId,@post_qString)";


                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }


                sqlCommand.Connection = connection;

                sqlCommand.Parameters.AddWithValue("@userName", userName);
                sqlCommand.Parameters.AddWithValue("@replyText", replyMes.Text);
                sqlCommand.Parameters.AddWithValue("@userId", userId);
                sqlCommand.Parameters.AddWithValue("@post_qString", post_qString);



                sqlCommand.CommandText = sql_reply;


                int f = sqlCommand.ExecuteNonQuery();

                if (f != 0)
                {



                  
       




                    Response.Redirect($"Post-hyper.aspx?ID={post_qString}");


                }
                else
                {
                    Response.Write(("<script>alert('回覆新增失敗');</script>"));

                }


            }
            else 
            {
                Response.Write(("<script>alert('回覆內容不得為空白，回覆新增失敗');</script>"));
            }
            

            

        }



        protected void createBtn_Click(object sender, EventArgs e)
        {
            if (Session["myName"] != null)
            {
                Response.Redirect("Add_post.aspx");
            }

        }


        protected void editBtn_Click(object sender, EventArgs e)
        {


        }


        protected void deleteBtn_Click(object sender, EventArgs e)
        {

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


            string delSql = $"Delete from Post where Id=@Id";



            sqlCommand.Parameters.AddWithValue("@Id", post_qString);


            // 將準備的SQL指令給操作物件
            sqlCommand.CommandText = delSql;


            // 執行非查詢的資料庫指令，ExecuteNonQuery()會回傳受影響的資料數目
            int f = sqlCommand.ExecuteNonQuery();

            if (f != 0)
            {
                Response.Write(("<script>alert('刪除成功');</script>"));
            }
            else
            {
                Response.Write(("<script>alert('刪除失敗');</script>"));
            }


        }

    }
}