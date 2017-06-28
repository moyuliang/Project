using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBlog
{
    public partial class Picture : System.Web.UI.Page
    {
        string user_name = "";
        int filelen = 0;
        byte[] PhotoArray = null;
        string picname = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Username"] != null)
                user_name = Request.QueryString["Username"];
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
                RefreshFilename();
                Image1.ImageUrl = "img.aspx?Username=" + user_name + "&Picname=" + picname;
            }
        }

        private void RefreshFilename()
        {
            using (SqlConnection connection = new SqlConnection
                      (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
            {
                try
                {
                    connection.Open();
                    SqlCommand myCommand = new SqlCommand("select image_name from Image where username='" + user_name + "';", connection);

                    SqlDataReader myReader = myCommand.ExecuteReader();
                    DropDownList1.Items.Clear();
                    while (myReader.Read() == true)
                    {
                        DropDownList1.Items.Add(myReader["image_name"].ToString());
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
            Response.Redirect("Personal_Homepage.aspx?Username=" + user_name);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            Response.Redirect("LogHomepage.aspx?Username=" + user_name);
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Personal_Setting.aspx?Username=" + user_name);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd"); // 2008-09-04

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
                        string number = aa.Next(100).ToString();

                        string fileName = file.FileName;
                        string[] SplitFileName = fileName.Split('.');

                        string path = "/upload/" + DateTime.Now.ToString("yyyMMddHHmmss") + stamp + "." + SplitFileName[1];
                        picname = DateTime.Now.ToString("yyyMMddHHmmss") + number + "." + SplitFileName[1];
                        try
                        {
                            //原始图片保存  
                            FileUpload1.SaveAs(Server.MapPath(path));
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

            string sqlimg = "insert into Image Values(@imgname,@ico,@username,@now)";
            using (SqlConnection connection = new SqlConnection
                      (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
            {
                connection.Open();

                SqlCommand myCommand1 = new SqlCommand(sqlimg, connection);
                myCommand1.Parameters.Add("@imgname", SqlDbType.VarChar, 30).Value = picname;
                myCommand1.Parameters.Add("@ico", SqlDbType.Binary, filelen).Value = PhotoArray;
                myCommand1.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = user_name;
                myCommand1.Parameters.Add("@now", SqlDbType.VarChar, 10).Value = date;

                int m = myCommand1.ExecuteNonQuery();

                if (m > 0)
                {
                    Image1.ImageUrl = "img.aspx?Username=" + user_name + "&Picname=" + picname;
                 }
            }
            RefreshFilename();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection
                      (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
            {
                try
                {
                    connection.Open();

                    SqlCommand myCommand2 = new SqlCommand("delete from Image where username='" + user_name + "' and image_name='"+DropDownList1.SelectedValue+"';", connection);

                    int n = myCommand2.ExecuteNonQuery();

                    if (n > 0)
                    {
                        Response.Write("<script>alert('删除图片成功');</script>");
                        RefreshFilename();
                        Image1.ImageUrl = "img.aspx?Username=" + user_name + "&Picname=" + DropDownList1.SelectedValue;
                    }
                    else
                        Response.Write("<script>alert('删除图片失败');</script>");
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            Image1.ImageUrl = "img.aspx?Username=" + user_name + "&Picname=" + DropDownList1.SelectedValue;
        }
    }
}