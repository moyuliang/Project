using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBlog
{
    public partial class Manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('删除该用户成功');</script>");
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('更新用户信息成功');</script>");
        }


        protected void InsertButton_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('新增用户成功');</script>");
        }

    }
}