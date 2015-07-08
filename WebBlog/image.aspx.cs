using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace 图片管理
{
    public partial class image : System.Web.UI.Page
    {
        string spath = "";
        string sname = "";
        string user_name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
             user_name="Qing_L@163.com";
        }

        SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString());
      
        protected void Button1_Click(object sender, EventArgs e)//输入图片序号，查询图片
        {
            Response.Redirect("lookpicture.aspx?Text="+TextBox1.Text );//跳转到查看页面 
        }

        protected void Button3_Click(object sender, EventArgs e)//输入图片序号，删除图片
        {
            connection.Open();
            string SQLstr = "delete from Image where id='" + TextBox1.Text + "'";
            SqlCommand command = new SqlCommand(SQLstr, connection);
            int Count = command.ExecuteNonQuery();
            if (Count > 0)
            {
                Response.Write("<script>alert('删除成功！');</script>");
            }
            else
            {
                Response.Write("<script>alert('对不起，删除失败！');</script>");
            }

            connection.Close();
 }

        protected void Button2_Click(object sender, EventArgs e)//输入图片信息，上传图片
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd"); // 2008-09-04
            byte[] PhotoArray = null;

            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFile file = Request.Files[i];
                if (file.ContentLength > 0)
                {
                    if (file.ContentType.Contains("image/"))
                    {
                        PhotoArray = new Byte[file.ContentLength];
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
                        //缩略图保存路径  
                        spath = "upload/" + DateTime.Now.ToString("yyyMMddHHmmss") + number + "." + SplitFileName[1];
                        sname = DateTime.Now.ToString("yyyMMddHHmmss") + number + "." + SplitFileName[1];
                        try
                        {
                            //原始图片保存  
                            FileUpload1.SaveAs(Server.MapPath(path));
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

            connection.Open();
            string SQLstr = "insert into Image(image_name,image,username,now)" + " values('" + TextBox2.Text + "','" + PhotoArray + "','" + user_name + "','" + date+ "')";
            SqlCommand command = new SqlCommand(SQLstr, connection);
            int Count =command.ExecuteNonQuery();
            if(Count>0)
            {
                Response.Write("<script>alert('插入成功！');</script>");
            }
            else{
                Response.Write("<script>alert('对不起，插入失败！');</script>");
            }
            
             connection.Close();
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