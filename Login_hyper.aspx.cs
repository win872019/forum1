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
        DbTool db = new DbTool();  //TC：好像都沒有用到db物件的方法，例如db.ConnectDb()等等，下面都是你自己寫的，熟悉寫法後，建議改成以db物件所內建的方法進行撰寫
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

            string username = UsernameTextBox.Text;     // TC：建議可以加入一些驗證控制項，這樣下面可以免去null or empty的判定
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

                sql = $"SELECT * FROM [User] where Email=@uEmail";      //TC：是否要再加入password的確認，僅確認帳號，帳號的重複性可能會很高
                sqlCommand.Parameters.AddWithValue("@uEmail", username);
            }
            else                                                                                            //TC：如果帳號和密碼欄位是空的，會重新導向，但此時string sql是" "，下面的sqlCommand還是會運行，有機會出現錯誤，建議把SQL的執行寫在特定的{ }內
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
            {                                                                               //TC：你的做法是先用帳號進行資料庫比對，在抓出資料庫內的密碼，進行比較
                if (username == mail && password == pw)      //TC：這邊進行帳號和密碼的比較
                {                                                                           //TC：我會建議在79~81行就直接進行帳號和密碼的比較，這樣這附近的code都可以省略
                    Session["myName"] = myName;
                    Session["userId"] = userId;

                    Response.Redirect("List_hyper.aspx");

                }
                else if (username == mail && password != pw)
                {

                    StatusLabel.Text = "密碼錯誤，請輸入正確密碼";


                }
                else if (mail == null || mail == "")              //TC：在上一層if已經把mail=null篩選掉了
                {
                    StatusLabel.Text = "此帳號未註冊";
                }


            }






        }






    }
}