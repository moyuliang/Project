using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Drawing;
using System.IO;

namespace WebBlog
{
    public partial class Personal_Setting : System.Web.UI.Page
    {
        string user_name = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Username"] != null)
                user_name = Request.QueryString["Username"];
            if (!IsPostBack)
            {
                using (SqlConnection connection = new SqlConnection
                     (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
                {
                    connection.Open();
                    SqlCommand myCommand = new SqlCommand("select * from UserTable where username='" + user_name + "'", connection);
                    SqlDataReader myReader = myCommand.ExecuteReader();                 
                    
                    Label3.Text = user_name;
                    
                    if (myReader.Read())
                    {
                        Label1.Text = myReader["name"].ToString();
                        TextBox1.Text = myReader["name"].ToString();
                        TextBox2.Text = myReader["city"].ToString();
                        TextBox3.Text = myReader["sign"].ToString();
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sname = "";
            int filelen = 0;
            string sex = "保密";
            string date = DateTime.Now.ToString("yyyy-MM-dd"); // 2008-09-04
            byte[] PhotoArray = null;

            if (RadioButton1.Checked)
                sex = RadioButton1.Text;
            else if (RadioButton2.Checked)
                sex = RadioButton2.Text;
            else if (RadioButton3.Checked)
                sex = RadioButton3.Text;

            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFile file = Request.Files[i];
                if (file.ContentLength > 0)
                {
                    if (file.ContentType.Contains("image/"))
                    {
                        filelen = file.ContentLength;

                        PhotoArray = new Byte[filelen];
                        Stream PhotoStream = file.InputStream;
                        PhotoStream.Read(PhotoArray, 0, file.ContentLength);

                        ///随机数据  
                        Guid guid = Guid.NewGuid();
                        string stamp = guid.ToString("N");
                        //生成随机数  
                        Random aa = new Random();
                        string number = aa.Next(10000).ToString();

                        string fileName = file.FileName;
                        string[] SplitFileName = fileName.Split('.');

                        //原始图片保存路径  
                        string path = "/upload/" + DateTime.Now.ToString("yyyMMddHHmmss") + stamp + "." + SplitFileName[1];
                        
                        try
                        {
                            //原始图片保存  
                            pic_upload.SaveAs(Server.MapPath(path));
                        }
                        catch (Exception ex)
                        {
                            Response.Write("<script>alert('" + ex.Message + "')<script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('该文件不是图片格式！');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('请选择要上传的图片');</script>");
                }
            }
            string sqlimg = "update Image set image_name=@imgname,image=@ico,now=@now where username=@username";
            
            if(PhotoArray!=null)
            {
                string sql = "update UserTable set name=@name,city=@city,sex=@sex,ico=@ico,sign=@sign,signdate=@signdate where username=@username";
            
                using (SqlConnection connection = new SqlConnection
                        (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
                {
                    connection.Open();
                    SqlCommand myCommand = new SqlCommand(sql, connection);
                    myCommand.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = TextBox1.Text.Trim();
                    myCommand.Parameters.Add("@sex", SqlDbType.VarChar, 4).Value = sex;
                    myCommand.Parameters.Add("@city", SqlDbType.VarChar, 100).Value = TextBox2.Text.Trim();
                    myCommand.Parameters.Add("@sign", SqlDbType.VarChar, 200).Value = TextBox3.Text.Trim();
                    myCommand.Parameters.Add("@signdate", SqlDbType.VarChar, 10).Value = date;
                    myCommand.Parameters.Add("@ico", SqlDbType.Binary, filelen).Value = PhotoArray;
                    myCommand.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = user_name;

                    int n = myCommand.ExecuteNonQuery();
                    if (n > 0)
                    {
                        SqlCommand myCommand1 = new SqlCommand(sqlimg, connection);
                        myCommand1.Parameters.Add("@imgname", SqlDbType.VarChar, 30).Value = sname;
                        myCommand1.Parameters.Add("@ico", SqlDbType.Binary, filelen).Value = PhotoArray;
                        myCommand1.Parameters.Add("@now", SqlDbType.VarChar, 10).Value = date;
                        myCommand1.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = user_name;
                        int m = myCommand1.ExecuteNonQuery();
                        if (m > 0)
                        {
                            Response.Write("<script>alert('修改成功');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('修改失败');</script>");
                    }
                }
            }
            else
            {
                string sql = "update UserTable set name=@name,city=@city,sex=@sex,sign=@sign,signdate=@signdate where username=@username";

                using (SqlConnection connection = new SqlConnection
                        (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
                {
                    connection.Open();
                    SqlCommand myCommand = new SqlCommand(sql, connection);
                    myCommand.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = TextBox1.Text.Trim();
                    myCommand.Parameters.Add("@sex", SqlDbType.VarChar, 4).Value = sex;
                    myCommand.Parameters.Add("@city", SqlDbType.VarChar, 100).Value = TextBox2.Text.Trim();
                    myCommand.Parameters.Add("@sign", SqlDbType.VarChar, 200).Value = TextBox3.Text.Trim();
                    myCommand.Parameters.Add("@signdate", SqlDbType.VarChar, 10).Value = date;
                    myCommand.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = user_name;

                    int n = myCommand.ExecuteNonQuery();
                    if (n > 0)
                    {
                        Response.Write("<script>alert('修改成功');</script>");
                    }
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
            Response.Redirect("Personal_Homepage.aspx?Username=" + user_name);
        }
    }
}