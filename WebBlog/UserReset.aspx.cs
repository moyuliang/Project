using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBlog
{
    public partial class UserReset : System.Web.UI.Page
    {
        //string user_name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Username"] != null)
            {
                TextBox1.Text = Request.QueryString["Username"];
                //user_name = Request.QueryString["Username"];
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string code = Session["CheckCode"].ToString();

            if(TextBox3.Text.Trim().ToUpper()==code.ToUpper())
            {
                string sql = "update UserTable set password='"+TextBox2.Text.Trim()+"' where username='"+TextBox1.Text.Trim()+"';";
                using (SqlConnection connection = new SqlConnection
                      (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
                {
                    connection.Open();

                    SqlCommand myCommand = new SqlCommand(sql, connection);
                    int n = myCommand.ExecuteNonQuery();

                    if (n > 0)
                    {
                         Response.Redirect("UserLog.aspx?Username=" + TextBox1.Text);
                    }
                    else
                    {
                        Response.Write("<script>alert('重置密码失败');</script>");
                    }
                }
            }
        }
    }
}