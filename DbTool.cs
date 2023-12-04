using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace Forum_fianl
{
    public class DbTool
    {
        //建立SQL連接的物件
        SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Forum1ConnectionString"].ConnectionString);

        // 建立要操作SQL的指令物件
        SqlCommand sqlCommand = new SqlCommand();


        //連線資料庫
        public void ConnectDb()
        {

            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        // 開啟資料庫
        public void CloseDb()
        {
            connection.Close();

        }


        // 查詢資料庫

        public SqlDataReader SearchDb(string sql)
        {


            ConnectDb();

            sqlCommand.Connection = connection;

            // 將準備的SQL指令給操作物件
            sqlCommand.CommandText = sql;


            SqlDataReader reader = sqlCommand.ExecuteReader();


            return reader;

        }








        public void  showDB_GridView(string sql, GridView gridView)
        {


            gridView.DataSource = SearchDb(sql);


            //GridView 控制項進行資料繫結(data binding)綁定資料
            gridView.DataBind();


            CloseDb();


        }



        public void showDB_ListView(string sql, ListView listView)
        {


            listView.DataSource = SearchDb(sql);


            //GridView 控制項進行資料繫結(data binding)綁定資料
            listView.DataBind();


            CloseDb();


        }






        public void showDB_DetailsView(string sql, string param1, string param2, DetailsView detailsView)
        {

            ConnectDb();


            // 連接到哪個資料庫
            sqlCommand.Connection = connection;


            // 使用參數化查詢

            sqlCommand.Parameters.AddWithValue(param1, param2);


            // 將準備的SQL指令給操作物件
            sqlCommand.CommandText = sql;

            // DataReader 速度快只能逐筆單向由上往下且不能計算，適合用來抓單筆資料
            SqlDataReader reader = sqlCommand.ExecuteReader();



            // 將資料放入 DataTable
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            // 使用 DataTable 作為 DetailsView1 的資料來源
            detailsView.DataSource = dataTable;

            // GridView 控制項進行資料繫結(data binding)綁定資料
            detailsView.DataBind();

            CloseDb();

        }










    }
}