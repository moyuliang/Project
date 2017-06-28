using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Personal_Income_and_Expences
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["userinfo"] != null)
                {
                    TextBox1.Text = Request.Cookies["userinfo"].Values["UserName"].ToString();
                    TextBox2.Attributes.Add("value", Request.Cookies["userinfo"].Values["UserPassword"].ToString());
                    CheckBox1.Checked = true;
                }
                if (Request.QueryString["Username"] != null)
                {
                    TextBox2.Attributes.Add("value", "");
                    TextBox1.Text = Request.QueryString["Username"];
                }
            }
        }

        //public void getPassword()
        //{
        //    if (Request.Cookies["userinfo"] != null)
        //    {
        //        if(Request.Cookies["userinfo"].Values["UserName"].ToString().Equals(TextBox1.Text.Trim()))
        //            TextBox2.Attributes.Add("value", Request.Cookies["userinfo"].Values["UserPassword"].ToString());
        //        CheckBox1.Checked = true;
        //    }
        //}

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
                        SqlCommand myCommand = new SqlCommand("select * from User_table where username='" + TextBox1.Text.Trim() + "' and password='" + TextBox2.Text.Trim() + "';", connection);
                        SqlDataReader myReader = myCommand.ExecuteReader();
                        
                        if (myReader.Read()==true) {
                            HttpCookie cookie = new HttpCookie("userinfo");

                            if (CheckBox1.Checked == true)
                            {
                                cookie.Values["UserName"]= TextBox1.Text.Trim();
                                cookie.Values["UserPassword"]=TextBox2.Text.Trim();

                                cookie.Expires = System.DateTime.Now.AddDays(7.0);
                                HttpContext.Current.Response.Cookies.Add(cookie);
                            }
                            Response.Redirect("Home.aspx?Username="+TextBox1.Text.Trim());
                        }
                        else{
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