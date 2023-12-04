using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum_fianl
{
    public partial class autoAddDV : System.Web.UI.Page
    {


        protected void Page_Init(object sender, EventArgs e)
        {
            // Dynamic creation of DetailsView
            DetailsView DetailsView1 = new DetailsView();
            DetailsView1.ID = "dynamicDetailsView";
            DetailsView1.AutoGenerateRows = true;



            #region 連接資料庫(ADO.NET)

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Forum1ConnectionString"].ConnectionString);

            //跟資料庫建立連線
            connection.Open();

            // 建立要操作SQL的指令物件
            SqlCommand sqlCommand = new SqlCommand();



            // 連接到哪個資料庫
            sqlCommand.Connection = connection;



            // 使用參數化查詢
            string sql = $"SELECT * FROM Reply WHERE Id = @Id";
            sqlCommand.Parameters.AddWithValue("@Id", 2);




            // 將準備的SQL指令給操作物件
            sqlCommand.CommandText = sql;

            // DataReader 速度快只能逐筆單向由上往下且不能計算，適合用來抓單筆資料
            SqlDataReader reader = sqlCommand.ExecuteReader();


            // 將資料放入 DataTable
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            // 使用 DataTable 作為 DetailsView1 的資料來源
            DetailsView1.DataSource = dataTable;

            // GridView 控制項進行資料繫結(data binding)綁定資料
            DetailsView1.DataBind();

            connection.Close();


            #endregion 連接資料庫(ADO.NET)



            form1.Controls.Add(DetailsView1);



        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


               
            }
        }


        private void CreateDynamicDetailsView()
        {

            // Dynamic creation of DetailsView
            DetailsView DetailsView1 = new DetailsView();
            DetailsView1.ID = "dynamicDetailsView";
            DetailsView1.AutoGenerateRows = true;



            #region 連接資料庫(ADO.NET)

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Forum1ConnectionString"].ConnectionString);

            //跟資料庫建立連線
            connection.Open();

            // 建立要操作SQL的指令物件
            SqlCommand sqlCommand = new SqlCommand();



            // 連接到哪個資料庫
            sqlCommand.Connection = connection;



            // 使用參數化查詢
            string sql = $"SELECT * FROM Post WHERE Id = @Id";
            sqlCommand.Parameters.AddWithValue("@Id", 2);




            // 將準備的SQL指令給操作物件
            sqlCommand.CommandText = sql;

            // DataReader 速度快只能逐筆單向由上往下且不能計算，適合用來抓單筆資料
            SqlDataReader reader = sqlCommand.ExecuteReader();


            // 將資料放入 DataTable
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            // 使用 DataTable 作為 DetailsView1 的資料來源
            DetailsView1.DataSource = dataTable;

            // GridView 控制項進行資料繫結(data binding)綁定資料
            DetailsView1.DataBind();

            connection.Close();


            #endregion 連接資料庫(ADO.NET)



            form1.Controls.Add(DetailsView1);



        }


    }


}
