using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebBlog
{
    public partial class AdminLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection
                  (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
            {
                try
                {
                    if (!TextBox1.Text.Equals("") && !TextBox2.Text.Equals(""))
                    {
                        connection.Open();
                        SqlCommand myCommand = new SqlCommand("select * from Administor where email='" + TextBox1.Text.Trim() + "' and password='" + TextBox2.Text.Trim() + "';", connection);
                        SqlDataReader myReader = myCommand.ExecuteReader();
                        
                        if (myReader.Read()==true) { 
                            Response.Redirect("Manage.aspx?Adminame="+TextBox1.Text.Trim());
                        }
                        else if (myReader.Read() == false){
                            Response.Write("<script>alert('用户名或密码错误');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('请输入用户名和密码');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('"+ex.Message+"');</script>");
                }
            }
        }
    }
}
