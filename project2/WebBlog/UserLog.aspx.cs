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
    public partial class UserLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Username"] != null)
                {
                    TextBox1.Text = Request.QueryString["Username"];
                }

                HttpCookie cookies = Request.Cookies["USER_COOKIE"];
                if(cookies!=null)
                {
                    TextBox1.Text = cookies["UserName"];
                    TextBox2.Attributes.Add("value", cookies["UserPassword"]);
                    CheckBox1.Checked = true;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string UserName = TextBox1.Text.Trim();
            string Password = TextBox2.Text.Trim();

            using (SqlConnection connection = new SqlConnection
                  (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
            {
                try
                {
                    if (!TextBox1.Text.Equals("") && !TextBox2.Text.Equals(""))
                    {
                        connection.Open();
                        SqlCommand myCommand = new SqlCommand("select * from UserTable where username='" + TextBox1.Text.Trim() + "' and password='" + TextBox2.Text.Trim() + "';", connection);
                        SqlDataReader myReader = myCommand.ExecuteReader();

                        if (myReader.Read() == true)
                        {
                            HttpCookie cookie = new HttpCookie("USER_COOKIE");
                            
                            if(CheckBox1.Checked==true)
                            {
                                cookie.Values.Add("UserName", TextBox1.Text.Trim());
                                cookie.Values.Add("UserPassword", TextBox2.Text.Trim());

                                cookie.Expires = System.DateTime.Now.AddDays(7.0);
                                HttpContext.Current.Response.Cookies.Add(cookie);
                            }
                            else
                            {
                                if (cookie["USER_COOKIE"] != null)
                                    Response.Cookies["USER_COOKIE"].Expires = DateTime.Now;
                            }
                            Response.Redirect("Personal_Homepage.aspx?Username=" + TextBox1.Text.Trim());
                        }
                        else if (myReader.Read() == false)
                        {
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
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserReset.aspx?Username=" + TextBox1.Text.Trim());
        }
    }
}