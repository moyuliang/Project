using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Personal_Income_and_Expences
{
    public partial class SignOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //注册按钮点击事件
        protected void Button1_Click(object sender, EventArgs e)
        {
            string insert_sql = "insert into User_table values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox4.Text + "');";
            string selsql = "select * from User_table where username='" + TextBox1.Text.Trim() + "';";
            using (SqlConnection connection = new SqlConnection
                      (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
            {
                connection.Open();
                SqlCommand myCommand2 = new SqlCommand(selsql, connection);
                SqlDataReader myReader2 = myCommand2.ExecuteReader();

                if (myReader2.Read() == true)
                {
                    Response.Write("<script>alert('已存在该用户名，请更换电子邮件');</script>");
                    myReader2.Close();
                }
                else
                {
                    myReader2.Close();

                    SqlCommand myCommand1 = new SqlCommand(insert_sql, connection);

                    int num = myCommand1.ExecuteNonQuery();

                    if (num > 0)
                    {
                        Response.Redirect("Login.aspx?Username=" + TextBox1.Text);
                    }
                }
            }
        }
    }
}