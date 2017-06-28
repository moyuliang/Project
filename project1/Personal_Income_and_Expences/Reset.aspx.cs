using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Personal_Income_and_Expences
{
    public partial class Reset : System.Web.UI.Page
    {
        String username = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Username"] != null)
            {
                username = Request.QueryString["Username"];
                TextBox1.Text = username;
            }
            else
                Response.Redirect("Login.aspx");
            using (SqlConnection connection2 = new SqlConnection
                  (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
            {
                try
                {
                    connection2.Open();
                    SqlCommand myCommand = new SqlCommand("select * from User_table where username='" + username + "';", connection2);
                    SqlDataReader myReader = myCommand.ExecuteReader();

                    if (myReader.Read() == true)
                    {
                        Label1.Text = myReader["name"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
                finally
                {
                    connection2.Close();
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string oldPsw = TextBox2.Text;
            string newPsw = TextBox3.Text;
            string confirmPsw = TextBox4.Text;
            using (SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager
                                               .ConnectionStrings["Con"].ConnectionString.ToString()))
            {
                con.Open();
                try
                {
                    string sql = "select password from User_table where username='" + username + "'";
                    SqlCommand command = new SqlCommand(sql, con);
                    SqlDataReader reader = command.ExecuteReader();
                    string tablePsw = null;

                    if (reader.Read())
                    {
                        tablePsw = (string)reader["password"];
                        if (!tablePsw.Equals(oldPsw.Trim()))
                        {
                            Response.Write("<script type='text/javascript'>alert('您输入的旧密码不正确！');</script>");
                            return;
                        }
                        if (oldPsw.Trim() == newPsw.Trim())
                        {
                            Response.Write("<script type='text/javascript'>alert('新旧密码不能一致！');</script>");
                            return;
                        }

                        reader.Close();
                        sql = "update User_table set password='" + newPsw + "'" + " where username='" + username + "';";
                        command = new SqlCommand(sql, con);

                        command.ExecuteNonQuery();

                    }
                    Response.Write("<script type='text/javascript'>alert('修改成功');</script>");

                }
                catch (Exception ex)
                {
                    Response.Write("<script type='text/javascript'>alert('" + ex.Message + "');</script>");
                }
                finally
                {
                    con.Close();
                }

            }
        }



        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageRecord.aspx?Username=" + username);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            Response.Redirect("Home.aspx?Username=" + username);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {

            Response.Redirect("AddRecord.aspx?Username=" + username);
        }
    }
}