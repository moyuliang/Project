using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

namespace WebBlog
{
    public partial class SuccessLog : System.Web.UI.Page
    {
        string user_name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack) 
            { 
                TextBox1.Text = "";
            }
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
                        SqlCommand myCommand = new SqlCommand("select name,sex,city,sign from UserTable where username='" + user_name + "';", connection);
                        
                        SqlDataReader myReader = myCommand.ExecuteReader();
                    
                        if (myReader.Read() == true)
                        {
                                Label1.Text = myReader["name"].ToString();
                                Label2.Text = myReader["name"].ToString();
                                Label3.Text = myReader["sex"].ToString();
                                Label4.Text = myReader["city"].ToString();
                                Label5.Text = myReader["sign"].ToString();
                                Image1.ImageUrl = "ico.aspx?Username="+user_name;
                        }
                        connection.Close();
                        connection.Open();
                        SqlCommand myCommand1 = new SqlCommand("select title,detail from Artical where author ='"+user_name+"'order by id DESC;",connection);
                        SqlDataReader myReader1 = myCommand1.ExecuteReader();

                        if (myReader1.Read())
                        {
                            TextBox1.Text += "标题：" + "\t" + myReader1["title"].ToString() + "\n\n";
                            TextBox1.Text += "内容：" + "\n"+"\t" + myReader1["detail"].ToString();
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
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogHomepage.aspx?Username=" + user_name);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserArticleType.aspx?Username=" + user_name);
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Article.aspx?Username=" + user_name);
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckArticle.aspx?Username=" + user_name);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Picture.aspx?Username=" + user_name);
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Personal_Setting.aspx?Username=" + user_name);
        }



    }
}