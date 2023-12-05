using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum_fianl
{
    public partial class Login_hyper : System.Web.UI.Page
    {
        DbTool db = new DbTool();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["myName"] != null)
                {
                    string username = Session["myName"].ToString();

                    StatusLabel.Text = $"Hi,{username}! 您已登入";

                }

                else
                {


                    StatusLabel.Text = "未登入，請輸入帳號密碼";
                }
            }
        }



        protected void LoginButton_Click(object sender, EventArgs e)
        {

            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            string mail = "";
            string pw = "";
            string myName = "";
            string userId = "";

            //建立SQL連接的物件 方法1. V

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Forum1ConnectionString"].ConnectionString);

            //跟資料庫建立連線
            connection.Open();



            #region SQL擷取資料

            // 建立要操作SQL的指令物件
            SqlCommand sqlCommand = new SqlCommand();



            // 連接到哪個資料庫
            sqlCommand.Connection = connection;





            string sql="";



            // SQL 語法
            if (username != null && password != null && username != "" && password != "")
            {

                sql = $"SELECT * FROM [User] where Email=@uEmail";
                sqlCommand.Parameters.AddWithValue("@uEmail", username);
            }
            else
            {

                Response.Redirect("Login_hyper.aspx");
            }




            // 將準備的 SQL 指令給操作物件
            sqlCommand.CommandText = sql;




            // 一次分別讀取不同欄位
            SqlDataReader reader = sqlCommand.ExecuteReader();     // 執行該 SQL 查詢

            while (reader.Read())
            {
                userId = reader["Id"].ToString();
                myName = reader["Username"].ToString();
                pw = reader["Password"].ToString();
                mail = reader["Email"].ToString();

            }
            reader.Close();




            // 關閉資料庫連線
            connection.Close();

            #endregion SQL擷取資料



            if (mail != null && pw != null && userId != null)
            {
                if (username == mail && password == pw)
                {
                    Session["myName"] = myName;
                    Session["userId"] = userId;

                    Response.Redirect("List_hyper.aspx");

                }
                else if (username == mail && password != pw)
                {

                    StatusLabel.Text = "密碼錯誤，請輸入正確密碼";


                }
                else if (mail == null || mail == "")
                {
                    StatusLabel.Text = "此帳號未註冊";
                }


            }






        }






    }
}