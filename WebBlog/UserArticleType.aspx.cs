using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBlog
{
    public partial class UserArticleType : System.Web.UI.Page
    {
        string user_name="";
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

            using (SqlConnection connection = new SqlConnection
              (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
            {

                try
                {
                    connection.Open();
                    string SQLstr1 = "select * from UserArticalType where username='" + user_name + "'";
                    SqlCommand myCommand1 = new SqlCommand(SQLstr1, connection);
                    SqlDataReader myReader1;
                    myReader1 = myCommand1.ExecuteReader();
                    ListBox1.Items.Clear();
                    DropDownList2.Items.Clear();
                    DropDownList3.Items.Clear();
                    ListBox1.Items.Add("你的文章类型如下：");
                    while (myReader1.Read())
                    {
                        ListBox1.Items.Add("●" + myReader1["typename"].ToString());
                        DropDownList2.Items.Add(myReader1["typename"].ToString());
                        DropDownList3.Items.Add(myReader1["typename"].ToString());
                    }
                    connection.Close();
                    connection.Open();
                    string SQLstr = "select * from ArticalType";
                    SqlCommand myCommand = new SqlCommand(SQLstr, connection);
                    SqlDataReader myReader;
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        DropDownList1.Items.Add(myReader["name"].ToString());
                    }
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

        protected void Button1_Click(object sender, EventArgs e)
        {
             using (SqlConnection connection = new SqlConnection
             (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
                {
                    string SQLstr = "insert into UserArticalType(username,typename) " + "values('" + user_name + "','" + DropDownList1.Text  + "')";
                    SqlCommand command = new SqlCommand(SQLstr, connection);
                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteNonQuery();
                        if (count > 0)
                        {

                        }
                         else
                            Response.Write("<script>alert('对不起，新添失败！');</script>");

                        connection.Close();
                        connection.Open();
                        string SQLstr1 = "select * from UserArticalType where username='" + user_name + "'";
                        SqlCommand myCommand1 = new SqlCommand(SQLstr1, connection);
                        SqlDataReader myReader1;
                        myReader1 = myCommand1.ExecuteReader();
                        ListBox1.Items.Clear();
                        DropDownList2.Items.Clear();
                        DropDownList3.Items.Clear();
                        ListBox1.Items.Add("你的文章类型如下：");
                        while (myReader1.Read())
                        {
                            ListBox1.Items.Add("●" + myReader1["typename"].ToString());
                            DropDownList2.Items.Add(myReader1["typename"].ToString());
                            DropDownList3.Items.Add(myReader1["typename"].ToString());
                        }
                      

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
            if (DropDownList2.Text != null && TextBox2.Text != null)
            {
                using (SqlConnection connection = new SqlConnection
               (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
                {
                    string SQLstr = "update UserArticalType set typename='" + TextBox2.Text + "' where typename='" + DropDownList2.Text.Trim() + "'";
                    SqlCommand myCommand = new SqlCommand(SQLstr, connection);
                    try
                    {
                        connection.Open();
                        int count = (int)myCommand.ExecuteNonQuery();
                        if (count > 0)
                        {
                            
                        }
                        else
                            Response.Write("<script>alert('文章类型修改失败！');</script>");

                        connection.Close();
                        connection.Open();
                        string SQLstr1 = "select * from UserArticalType where username='" + user_name + "'";
                        SqlCommand myCommand1 = new SqlCommand(SQLstr1, connection);
                        SqlDataReader myReader1;
                        myReader1 = myCommand1.ExecuteReader();
                        ListBox1.Items.Clear();
                        DropDownList2.Items.Clear();
                        DropDownList3.Items.Clear();
                        ListBox1.Items.Add("你的文章类型如下：");
                        while (myReader1.Read())
                        {
                            ListBox1.Items.Add("●" + myReader1["typename"].ToString());
                            DropDownList2.Items.Add(myReader1["typename"].ToString());
                            DropDownList3.Items.Add(myReader1["typename"].ToString());
                        }

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
            else
            {
                Response.Write("<script>alert('请先填写原类型和将修改为的类型！');</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //if (TextBox4.Text == null)
            //{
            //    Response.Write("<script>alert('请先填写类型！');</script>");
            //}
            //else
            //{
                using (SqlConnection connection = new SqlConnection
               (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
                {
                    string SQLstr = "delete from UserArticalType where typename='" + DropDownList3.Text.Trim() + "'";
                    try
                    {
                        connection.Open();
                        SqlCommand myCommand = new SqlCommand(SQLstr, connection);
                        int count = (int)myCommand.ExecuteNonQuery();
                        if (count > 0)
                        {
                            
                        }
                        else
                            Response.Write("<script>alert('文章类型删除失败！');</script>");

                        connection.Close();
                        connection.Open();
                        string SQLstr1 = "select * from UserArticalType where username='" + user_name + "'";
                        SqlCommand myCommand1 = new SqlCommand(SQLstr1, connection);
                        SqlDataReader myReader1;
                        myReader1 = myCommand1.ExecuteReader();
                        ListBox1.Items.Clear();
                        DropDownList2.Items.Clear();
                        DropDownList3.Items.Clear();
                        ListBox1.Items.Add("你的文章类型如下：");
                        while (myReader1.Read())
                        {
                            ListBox1.Items.Add("●" + myReader1["typename"].ToString());
                            DropDownList2.Items.Add(myReader1["typename"].ToString());
                            DropDownList3.Items.Add(myReader1["typename"].ToString());
                        }

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
            //}
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
            Response.Redirect("Article.aspx?Username=" + user_name);
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