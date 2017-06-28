using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBlog
{
    public partial class Article : System.Web.UI.Page
    {
        string user_name="";
        string num;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Username"] != null)
            {
                user_name = Request.QueryString["Username"];
            }
            using (SqlConnection connection = new SqlConnection
                      (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
            {
                try
                {
                    connection.Open();
                    SqlCommand myCommand = new SqlCommand("select name from UserTable where username='" + user_name + "';", connection);

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
                    connection.Close();
                }
            }
            if (!IsPostBack)
            {

            using (SqlConnection connection1 = new SqlConnection
               (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
            {
                string SQLstr1 = "select * from UserArticalType where username='" + user_name + "'";
                SqlCommand myCommand1 = new SqlCommand(SQLstr1, connection1);
                SqlDataReader myReader1;
                try
                {
                    connection1.Open();
                    myReader1 = myCommand1.ExecuteReader();
                    while (myReader1.Read())
                    {
                        DropDownList1.Items.Add(myReader1["typename"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                    connection1.Close();
                }
            }
            }
              
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("yyyy-MM-dd");
            using (SqlConnection connection = new SqlConnection
              (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
            {               
                string SQLstr1 = "select* from ArticalType where name='" + DropDownList1.Text + "'";
                SqlCommand myCommand = new SqlCommand(SQLstr1, connection);
                SqlDataReader myReader;
                try
                {
                    connection.Open();
                    myReader = myCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        num = myReader["id"].ToString();
                    }
                    else
                    {
                        Response.Write("<script>alert('对不起，没有该类型！');</script>");
                    }
                    connection.Close();
                    connection.Open();
                    string SQLstr = "insert into Artical(title,detail,author,now,type) " + "values('" + TextBox1.Text + "','" + TextBox3.Text + "','" + user_name + "','" + time + "','" + num + "')";
                    SqlCommand command = new SqlCommand(SQLstr, connection);
                    int count = (int)command.ExecuteNonQuery();
                    if (count > 0){
                        TextBox1.Text = "";
                        TextBox3.Text = "";
                        Response.Write("<script>alert('恭喜，提交成功！');</script>");
                    }
                    else
                        Response.Write("<script>alert('对不起，提交失败！');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox3.Text = "";
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogHomepage.aspx?Username=" + user_name);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Personal_Homepage.aspx?Username=" + user_name);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserArticleType.aspx?Username=" + user_name);
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckArticle.aspx?Username=" + user_name);
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Picture.aspx?Username=" + user_name);
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Personal_Setting.aspx?Username=" + user_name);
        }
    }
}