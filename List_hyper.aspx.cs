using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum_fianl
{
    public partial class List_hyper : System.Web.UI.Page
    {
        string myName = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            
            string sql = "select * from List";
            DbTool db = new DbTool();
            db.showDB_GridView(sql, GridView1);


            if (!IsPostBack)
            {
                if (Session["myName"] != null)
                {
                    myName = Session["myName"].ToString();
                    WelcomeText.Text = $"哈囉! {myName}";
                    LoginBtn.Visible = false;
                    LogoutBtn.Visible = true;
                    CreateBtn.Visible = true;
                }
                else
                {
                    WelcomeText.Text = "哈囉! 訪客 ";
                    LoginBtn.Visible = true;
                    LogoutBtn.Visible = false;
                    CreateBtn.Visible = false;
                }

            }
            else
            {
                CreateBtn.Visible = false;
            }









        }



        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login_hyper.aspx");
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Session["myName"] = null;
            Session["userId"] = null;
            WelcomeText.Text = "哈囉! 訪客 ";
            LoginBtn.Visible = true;
            LogoutBtn.Visible = false;
        }

        protected void CreateBtn_Click(object sender, EventArgs e)
        {

            if (Session["myName"] != null)
            {
                Response.Redirect("Add_post.aspx");
            }


        }
    }
}