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
    public partial class UserSign : System.Web.UI.Page
    {
        string spath="";
        string sname="";
        int filelen = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection connection = new SqlConnection
                      (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
                {
                    connection.Open();
                    SqlCommand myCommand = new SqlCommand("select * from Province;", connection);
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        DropDownListProvince.Items.Add(myReader["ProvinceName"].ToString());
                    }
                    DropDownListCity.Items.Add("北京市");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string city = "";
            
            if (DropDownListProvince.SelectedValue != DropDownListCity.SelectedValue)
                city = DropDownListProvince.SelectedValue + DropDownListCity.SelectedValue;
            else
                city = DropDownListCity.SelectedValue;

            string sex = "保密";
            string date = DateTime.Now.ToString("yyyy-MM-dd"); // 2008-09-04
            byte[] PhotoArray = null;

            if (RadioButton1.Checked == true)
                sex = RadioButton1.Text;
            else if (RadioButton2.Checked == true)
                sex = RadioButton2.Text;
            else if (RadioButton3.Checked == true)
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
                        string number = aa.Next(100).ToString();

                        string fileName = file.FileName;
                        string[] SplitFileName = fileName.Split('.');

                        //原始图片保存路径  
                        string path = "/upload/" + DateTime.Now.ToString("yyyMMddHHmmss") + stamp + "." + SplitFileName[1];
                        //缩略图保存路径  
                        spath = "upload/" + DateTime.Now.ToString("yyyMMddHHmmss") + number + "." + SplitFileName[1];
                        sname = DateTime.Now.ToString("yyyMMddHHmmss") + number + "." + SplitFileName[1];
                        try
                        {
                            //原始图片保存  
                            pic_upload.SaveAs(Server.MapPath(path));
                            //缩略图保存  
                            MakeThumbImage(Server.MapPath(path), Server.MapPath(spath), 200, 200);

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
            string selsql = "select * from UserTable where username='" + TextBox1.Text.Trim() + "';";
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

                    if (PhotoArray != null)
                    {
                        string sql = "insert into UserTable(username,password,name,sex,city,sign,signdate,ico) Values(@username,@password,@name,@sex,@city,@sign,@signdate,@ico);";

                        SqlCommand myCommand = new SqlCommand(sql, connection);
                        myCommand.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = TextBox1.Text.Trim();
                        myCommand.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = TextBox2.Text.Trim();
                        myCommand.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = TextBox4.Text.Trim();
                        myCommand.Parameters.Add("@sex", SqlDbType.VarChar, 4).Value = sex;
                        myCommand.Parameters.Add("@city", SqlDbType.VarChar, 100).Value = city;
                        myCommand.Parameters.Add("@sign", SqlDbType.VarChar, 200).Value = TextBox5.Text.Trim();
                        myCommand.Parameters.Add("@signdate", SqlDbType.VarChar, 10).Value = date;
                        myCommand.Parameters.Add("@ico", SqlDbType.Binary, filelen).Value = PhotoArray;
                        int n = myCommand.ExecuteNonQuery();

                        if (n > 0)
                        {
                            SqlCommand myCommand1 = new SqlCommand(sqlimg, connection);
                            myCommand1.Parameters.Add("@imgname", SqlDbType.VarChar, 30).Value = sname;
                            myCommand1.Parameters.Add("@ico", SqlDbType.Binary, filelen).Value = PhotoArray;
                            myCommand1.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = TextBox1.Text.Trim();
                            myCommand1.Parameters.Add("@now", SqlDbType.VarChar, 10).Value = date;
                            int m = myCommand1.ExecuteNonQuery();
                            if (m > 0)
                            {
                                Response.Redirect("UserLog.aspx?Username=" + TextBox1.Text);
                            }
                        }
                    }
                    else
                    {
                        string sqlnoico = "insert into UserTable(username,password,name,sex,city,sign,signdate) Values(@username,@password,@name,@sex,@city,@sign,@signdate);";

                        SqlCommand myCommand3 = new SqlCommand(sqlnoico, connection);
                        myCommand3.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = TextBox1.Text.Trim();
                        myCommand3.Parameters.Add("@password", SqlDbType.VarChar, 20).Value = TextBox2.Text.Trim();
                        myCommand3.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = TextBox4.Text.Trim();
                        myCommand3.Parameters.Add("@sex", SqlDbType.VarChar, 4).Value = sex;
                        myCommand3.Parameters.Add("@city", SqlDbType.VarChar, 100).Value = city;
                        myCommand3.Parameters.Add("@sign", SqlDbType.VarChar, 200).Value = TextBox5.Text.Trim();
                        myCommand3.Parameters.Add("@signdate", SqlDbType.VarChar, 10).Value = date;
                        int num = myCommand3.ExecuteNonQuery();

                        if (num > 0)
                        {
                            Response.Redirect("UserLog.aspx?Username=" + TextBox1.Text);
                        }
                    }

                }
            }
        }

        protected void DropDownListProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            string province = DropDownListProvince.SelectedValue;
            string sql="select CityName from City,Province where ParentID=ProID and ProvinceName='"+province+"';";
            
            DropDownListCity.Items.Clear();

            using (SqlConnection connection = new SqlConnection
                  (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
            {
                connection.Open();
                SqlCommand myCommand = new SqlCommand(sql, connection);
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    DropDownListCity.Items.Add(myReader["CityName"].ToString());
                }
            }
        }

        private void MakeThumbImage(string sPath, string stPath, int nWidth, int nHeight)  
    {  
        System.Drawing.Image sImage = System.Drawing.Image.FromFile(sPath);  
        int tw = nWidth;  
        int th = nHeight;  
        ///原始图片的宽度和高度  
        int sw = sImage.Width;  
        int sh = sImage.Height;  
        if (sw > tw)  
        {  
            sw = tw;  
        }  
        if (sh > th)  
        {  
            sh = th;  
        }  
        System.Drawing.Bitmap objPic, objNewPic;  
        objPic = new System.Drawing.Bitmap(sPath);  
        objNewPic = new System.Drawing.Bitmap(objPic, sw, sh);  
        objNewPic.Save(stPath);  
        sImage.Dispose();  
        objPic.Dispose();  
        objNewPic.Dispose();  
        }

    }
}