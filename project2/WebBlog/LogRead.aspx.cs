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
    public partial class LogRead : System.Web.UI.Page
    {
        string Id="";
        string user_name="";
        string theme,Author,content,Author1;
        SqlConnection MyConn = null;
        int PageSize, RecordCount, PageCount, CurrentPage;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ID"] != null&&Request.QueryString["Username"]!=null)
            {
                Id = Request.QueryString["ID"];
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

                using (SqlConnection connection = new SqlConnection
               (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
                {
                    string SQLstr = "select* from Artical where id='" + Id + "'";
                    SqlCommand myCommand = new SqlCommand(SQLstr, connection);
                    SqlDataReader myReader;
                   
                    try
                    {
                        connection.Open();
                        myReader = myCommand.ExecuteReader();
                        TextBox1.Text = ""; 
                        if(myReader.Read())
                        {
                            theme = myReader["title"].ToString();
                            Author = myReader["author"].ToString();
                            content = myReader["detail"].ToString();

                            string SQLstr1 = "select* from UserTable where username='" + Author + "'";
                            SqlCommand myCommand1 = new SqlCommand(SQLstr1, connection);
                            SqlDataReader myReader1;

                            connection.Close();
                            connection.Open();
                            myReader1 = myCommand1.ExecuteReader();
                            if(myReader1.Read())
                            {
                                Author1 = myReader1["name"].ToString();
                            }
                            TextBox1.Text += "标题：" + "\t" + theme + "\n\n";
                            TextBox1.Text += "作者：" + "\t" + Author1 + "\n\n";
                            TextBox1.Text += "内容：" + "\n" + content;                         
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
            //设定PageSize 
            PageSize = 5;
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
            using (SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
            {
                if (TextBox2.Text != "")
                {
                    try
                    {
                        string name = user_name;
                        string detail = TextBox2.Text;
                        string time = DateTime.Now.ToString("yyyy-MM-dd");

                        connection.Open();
                        string data = "insert into Comment(artical_id,comment_username,comment_detail,comment_time) " + " values('" + Id + "','" + name + "','" + detail + "','" + time + "')";

                        SqlCommand myCommand = new SqlCommand(data, connection);

                        int count = myCommand.ExecuteNonQuery();
                        if (count > 0)
                        {
                            ListBind();
                            Response.Write("<script>alert('发表成功！');</script>");
                            TextBox2.Text = "";
                        }
                        else
                        {
                            Response.Write("<script>alert('对不起，发表失败！');</script>");
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
                else
                {
                    Response.Write("<script language='javascript'>alert('留言内容不能为空！');</script>");
                    this.TextBox2.Text = "";
                    this.TextBox2.Focus();
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

        protected void update_Click(object sender, EventArgs e)
        {
            ListBind();
        }

        //计算总共有多少条记录 
        public int CalculateRecord()
        {
            using (MyConn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString()))
            {
                MyConn.Open();
                int intCount;
                string strCount = "select count(*) as num from Comment where artical_id='" + Id + "'";

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
                string strSel = "select Comment.id,title,UserTable.name,comment_detail,comment_time from Comment,Artical,UserTable where UserTable.username=Comment.comment_username and Comment.artical_id=Artical.id and Artical.id='" + Id + "'";
                DataSet ds = new DataSet();

                SqlDataAdapter MyAdapter = new SqlDataAdapter(strSel, MyConn);

                MyAdapter.Fill(ds, StartIndex, PageSize, "Comment,Artical,UserTable");

                return ds.Tables["Comment,Artical,UserTable"].DefaultView;
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            Response.Redirect("LogHomepage.aspx?Username=" + user_name + "");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {

            Response.Redirect("Personal_Homepage.aspx?Username=" + user_name + "");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {

            Response.Redirect("UserArticleType.aspx?Username=" + user_name + "");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Article.aspx?Username=" + user_name + "");

        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {

            Response.Redirect("CheckArticle.aspx?Username=" + user_name + "");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("Personal_Setting.aspx?Username=" + user_name);
        }

    }
}