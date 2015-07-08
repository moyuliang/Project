using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace 图片管理
{
    public partial class ImageService : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/binary;";  
            //这个地方图片可以从数据库中读取二进制图片  
           //byte[] img = DBHelper.ReadImg();  
            byte[] img = File.ReadAllBytes(Server.MapPath("img") + @"/叶子.jpg");  
            Response.BinaryWrite(img);              
            Response.Flush();  
            Response.End();  

        }
    }
}