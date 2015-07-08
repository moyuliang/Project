using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.Common;

namespace WebBlog
{
    public partial class CheckArticle : System.Web.UI.Page
    {
        string user_name="";
        string str;
        string  num;
        SqlConnection MyConn = null;
        int PageSize, RecordCount, PageCount, CurrentPage;
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
            string sqlstr = "select Artical.id,Artical.title,Artical.now,ArticalType.name from Artical,ArticalType where Artical.type=ArticalType.id AND author='" + user_name + "' ";
            SqlConnection connection1 = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString());
            SqlDataAdapter myda = new SqlDataAdapter(sqlstr, connection1);
            DataSet myds = new DataSet();
            connection1.Open();
            myda.Fill(myds, "Artical,ArticalType");
            GridView1.DataSource = myds;
            GridView1.DataKeyNames = new string[] { "id" };//主键
            GridView1.DataBind();
            connection1.Close();

            //设定PageSize 
            PageSize = 3;
            //ID = Request.QueryString["artical_id"].ToString();
            using (MyConn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString()))
            {
                MyConn.Open();
                //第一次请求执行 
                if (!Page.IsPostBack)
                {
                    ListBind();
                    CurrentPage = 0;
                    ViewState["PageIndex"] = 0;

                    //计算总共有多少记录 
                    RecordCount = CalculateRecord();
                    if (RecordCount > 0)
                    {
                        this.lnkbtnfirst.Visible = true;
                        this.lnkbtnlast.Visible = true;
                        this.lnkbtnNext.Visible = true;
                        this.lnkbtnUp.Visible = true;
                    }
                    else
                    {
                        this.lnkbtnfirst.Visible = false;
                        this.lnkbtnlast.Visible = false;
                        this.lnkbtnNext.Visible = false;
                        this.lnkbtnUp.Visible = false;
                    }

                    //计算总共有多少页 
                    if (RecordCount % PageSize != 0)
                    {
                        PageCount = RecordCount / PageSize + 1;
                    }
                    else
                    {
                        PageCount = RecordCount / PageSize;
                    }
                    ViewState["PageCount"] = PageCount;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text!=null)
            {
                using (SqlConnection connection = new SqlConnection
               (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString()))
                {
                    string SQLstr = "select* from Artical where id='" + TextBox1.Text + "'";
                    SqlCommand myCommand = new SqlCommand(SQLstr, connection);
                    SqlDataReader myReader;

                    try
                    {
                        connection.Open();
                        myReader = myCommand.ExecuteReader();
                        while(myReader.Read())
                        {
                            TextBox2.Text = "";                   
                            TextBox2.Text += "\t"+myReader["detail"].ToString() + "\n";
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
                Response.Write("<script>alert('请先填写文章ID！');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != null)
            {
                using (SqlConnection connection = new SqlConnection
               (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString()))
                {
                    string SQLstr = "update Artical set detail='"+TextBox2.Text+"' where id='" + TextBox1.Text.Trim() + "'";
                    SqlCommand myCommand = new SqlCommand(SQLstr, connection);                   
                    try
                    {
                        connection.Open();
                        int count = (int)myCommand.ExecuteNonQuery();
                        if (count > 0)
                        {
                            Response.Write("<script>alert('文章内容修改成功！');</script>");
                        }
                        else
                            Response.Write("<script>alert('文章内容修改失败！');</script>");
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
                Response.Write("<script>alert('请先填写文章ID！');</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != null)
            {
                using (SqlConnection connection = new SqlConnection
               (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString()))
                {
                    string SQLstr = "delete from Artical where id='" + TextBox1.Text.Trim() + "'";                    
                    try
                    {
                        connection.Open();
                        SqlCommand myCommand = new SqlCommand(SQLstr, connection);
                        int count = (int)myCommand.ExecuteNonQuery();
                        if (count > 0)
                        {
                            Response.Write("<script>alert('文章删除成功！');</script>");
                        }
                        else
                            Response.Write("<script>alert('文章删除失败！');</script>");
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
                Response.Write("<script>alert('请先填写文章ID！');</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        protected void Button5_Click1(object sender, EventArgs e)
        {
            string sqlstr = "select Artical.id,Artical.title,Artical.now,ArticalType.name from Artical,ArticalType where Artical.type=ArticalType.id AND author='" + user_name + "' ";
            SqlConnection connection1 = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString());
            SqlDataAdapter myda = new SqlDataAdapter(sqlstr, connection1);
            DataSet myds = new DataSet();
            connection1.Open();
            myda.Fill(myds, "Artical,ArticalType");
            GridView1.DataSource = myds;
            GridView1.DataKeyNames = new string[] { "id" };//主键
            GridView1.DataBind();
            connection1.Close();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            string sqlstr = "select Artical.id,Artical.title,Artical.now,ArticalType.name from Artical,ArticalType where Artical.type=ArticalType.id AND author='" + user_name + "' ";
            SqlConnection connection1 = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString());
            SqlDataAdapter myda = new SqlDataAdapter(sqlstr, connection1);
            DataSet myds = new DataSet();
            connection1.Open();
            myda.Fill(myds, "Artical,ArticalType");
            GridView1.DataSource = myds;
            GridView1.DataKeyNames = new string[] { "id" };//主键
            GridView1.DataBind();
            connection1.Close();
        }

        protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            using (MyConn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString()))
            {
                MyConn.Open();
                string strid = this.DataList1.DataKeys[e.Item.ItemIndex].ToString(); //获取当前DataList控件列
                Response.Write(strid);
                string strdel = "delete from Comment where id ='" + strid + "'";
                SqlCommand sqlcmd = new SqlCommand(strdel, MyConn);

                int n = sqlcmd.ExecuteNonQuery();
                if (n > 0)
                {
                    Response.Write("<script>alert('删除成功！')</script>");
                    ListBind();
                }
                else
                {
                    Response.Write("<script>alert('删除失败！')</script>");
                }
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (((Label)e.Item.Controls[0].FindControl("comment_detail")).Text.Length > 500)
            {
                ((Label)e.Item.Controls[0].FindControl("comment_detail")).Text = ((Label)e.Item.Controls[0].FindControl("labContext")).Text.Substring(0, 500) + "...";
            }
            ((LinkButton)e.Item.Controls[0].FindControl("LinkButton1")).Attributes.Add("onclick", "return confirm('确定要删除吗？')");
     
        }

        protected void update_Click(object sender, EventArgs e)
        {
            ListBind();
        }

        public int CalculateRecord()
        {
            using (MyConn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString()))
            {
                MyConn.Open();
                int intCount;
                string strCount = "select count(*) as num from Comment where artical_id='" + TextBox1.Text.Trim() + "'";

                SqlCommand MyComm = new SqlCommand(strCount, MyConn);
                intCount = (int)MyComm.ExecuteScalar();
                return intCount;
            }
        }

        ICollection CreateSource()
        {
            using (MyConn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString()))
            {
                MyConn.Open();
                int StartIndex;

                //设定导入的起终地址 
                StartIndex = CurrentPage * PageSize;
                string strSel = "select Comment.id,title,comment_username,comment_detail,comment_time from Comment,Artical where Comment.artical_id=Artical.id and Artical.id='" + TextBox1.Text.Trim() + "'";
                DataSet ds = new DataSet();

                SqlDataAdapter MyAdapter = new SqlDataAdapter(strSel, MyConn);

                MyAdapter.Fill(ds, StartIndex, PageSize, "Comment,Artical");

                return ds.Tables["Comment,Artical"].DefaultView;
            }
        }
        public void ListBind()
        {
            this.DataList1.DataSource = CreateSource();
            this.DataList1.DataKeyField = "id";
            this.DataList1.DataBind();
            this.lnkbtnNext.Enabled = true;
            this.lnkbtnUp.Enabled = true;
            if (CurrentPage == (PageCount - 1))
                this.lnkbtnNext.Enabled = false;
            if (CurrentPage == 0)
                this.lnkbtnUp.Enabled = false;

        }


        protected void Page_OnClick(object sender, CommandEventArgs e)
        {
            CurrentPage = (int)ViewState["PageIndex"];
            PageCount = (int)ViewState["PageCount"];

            string cmd = e.CommandName;
            //判断cmd，以判定翻页方向 
            switch (cmd)
            {
                case "next":
                    if (CurrentPage < (PageCount - 1)) CurrentPage++;
                    break;
                case "prev":
                    if (CurrentPage > 0) CurrentPage--;
                    break;
                case "first":
                    CurrentPage = 0;
                    break;
                case "last":
                    if (PageCount - 1 >= 0)
                    {
                        CurrentPage = PageCount - 1;
                    }
                    break;
            }

            ViewState["PageIndex"] = CurrentPage;
            ListBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection
               (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString()))
            {
                string SQLstr = "select* from Artical where id='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
                SqlCommand myCommand = new SqlCommand(SQLstr, connection);
                SqlDataReader myReader;

                try
                {
                    connection.Open();
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        TextBox2.Text = "";
                        TextBox2.Text += "\t" + myReader["detail"].ToString() + "\n";
                        TextBox1.Text = GridView1.DataKeys[e.RowIndex].Value.ToString();
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //鼠标经过时，行背景色变 
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#9999CC'");
                //鼠标移出时，行背景色变 
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#d9edf7'");
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogHomepage.aspx?Username=" + user_name);
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Personal_Homepage.aspx?Username=" + user_name);
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserArticleType.aspx?Username=" + user_name);
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Article.aspx?Username=" + user_name);
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("Personal_Setting.aspx?Username=" + user_name);
        }
    }
}