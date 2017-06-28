using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Personal_Income_and_Expences
{
    public partial class ManageRecord : System.Web.UI.Page
    {
        string username = "";
        string date = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Username"] != null)
            {
                username = Request.QueryString["Username"];
                if (Request.QueryString["Date"] != null)
                    date = Request.QueryString["Date"];
            }
            if (username.Equals(""))
                Response.Redirect("Login.aspx");
            if (!IsPostBack)
            {
                ViewState["SortOrder"] = "date";
                ViewState["OrderDire"] = "desc";
                BindGridView();
            }
            using (SqlConnection connection2 = new SqlConnection
                  (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
            {
                try
                {
                    connection2.Open();
                    SqlCommand myCommand = new SqlCommand("select * from User_table where username='" + username + "';", connection2);
                    SqlDataReader myReader = myCommand.ExecuteReader();

                    if (myReader.Read() == true)
                    {
                        Label1.Text = myReader["name"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message+ "');</script>");
                }
                finally
                {
                    connection2.Close();
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            Response.Redirect("Home.aspx?Username=" + username);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {

            Response.Redirect("AddRecord.aspx?Username=" + username);
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection
                  (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
            {
                try
                {
                    connection.Open();
                    string id = "";
                    string sel = "select id from Species_table where name='" + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim() + "';";
                    SqlCommand myCommand1 = new SqlCommand(sel, connection);
                    SqlDataReader myReader = myCommand1.ExecuteReader();

                    if (!myReader.HasRows)
                    {
                        ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "提示", "alert('输入的费用类型有误');", true);
                        GridView1.EditIndex = -1;
                        BindGridView();
                        return;
                    }
                    else
                    {
                        if (myReader.Read())
                            id = myReader["id"].ToString();
                    }
                    myReader.Close();
                    myCommand1.Clone();
                    string str = "update Daily_table set species_id='" + id + "',day_cost='" + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim() + "',date='" + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim() + "' where id='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'  and user_name='" + username + "';";
                    SqlCommand myCommand = new SqlCommand(str, connection);
                    myCommand.ExecuteNonQuery();
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "提示", "alert('修改成功');", true);
                    GridView1.EditIndex = -1;
                    BindGridView();
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

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection
                  (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
            {
                try
                {
                    SqlCommand myCommand = new SqlCommand("delete from Daily_table where id='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "' and user_name='" + username + "';", connection);
                    connection.Open();
                    myCommand.ExecuteNonQuery();
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "提示", "alert('删除成功');", true);
                    BindGridView();
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

        public void BindGridView()
        {
            string sql = "";

            SqlConnection connection3 = new SqlConnection
                  (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString());

            if (date.Equals(""))
                sql = "select Daily_table.id,Species_table.name,day_cost,date from Daily_table,Species_table where species_id=Species_table.id and user_name='" + username + "' order by date desc;";
            else
                sql = "select Daily_table.id,Species_table.name,day_cost,date from Daily_table,Species_table where species_id=Species_table.id and user_name='" + username + "' and date='" + date + "' order by date desc;";
            SqlDataAdapter myAdapter = new SqlDataAdapter(sql, connection3);
            DataSet myds = new DataSet();
            connection3.Open();

            myAdapter.Fill(myds, "Daily_table,Species_table");

            DataView view = myds.Tables["Daily_table,Species_table"].DefaultView;
            string sort = (string)ViewState["SortOrder"] + " " + (string)ViewState["OrderDire"];
            view.Sort = sort;
            GridView1.DataSource = view;
            GridView1.DataKeyNames = new string[] { "id" };//主键
            GridView1.DataBind();
            connection3.Close();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //如果是绑定数据行 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    ((LinkButton)e.Row.Cells[5].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('你确认要删除：\"" + e.Row.Cells[0].Text + "\"这条记录吗?')");
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sPage = e.SortExpression;
            if (ViewState["SortOrder"].ToString() == sPage)
            {
                if (ViewState["OrderDire"].ToString() == "desc")
                    ViewState["OrderDire"] = "asc";
                else
                    ViewState["OrderDire"] = "desc";
            }
            else
            {
                ViewState["SortOrder"] = e.SortExpression;
            }
            BindGridView();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reset.aspx?Username=" + username);
        }

        public string dataChart()
        {
            if (username.Equals(""))
            {
                Response.Redirect("Login.aspx");
            }
            string s = null;
            string x = "";
            string sql="";
            using (SqlConnection connection6 = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
            {
                connection6.Open();

                if (date.Equals(""))
                    sql = "select Sum from Species_Sum where user_name='" + username + "';";
                else
                {
                    string month = "";
                    if (date.Substring(4, 1).Equals("0"))
                        month = date.Substring(5, 1);
                    else
                        month = date.Substring(4, 2);
                    sql = "select Sum from Species_Month_Sum where user_name='" + username + "' and Month='" + month + "';";
                }
                    
                SqlCommand myCommand = new SqlCommand(sql, connection6);
                SqlDataReader myReader = myCommand.ExecuteReader();
                if (!myReader.HasRows)
                {
                    x = "0";
                }
                else
                {
                    while (myReader.Read())
                    {
                        s += myReader["Sum"].ToString() + ",";
                    }
                    x = s.Substring(0, s.Length - 1);
                }
            }
            return x;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(System.Web.Configuration.WebConfigurationManager
                                               .ConnectionStrings["Con"].ConnectionString.ToString()))
            {
                con.Open();
                try
                {
                    string sql = "update User_table set name='" + TextBox1.Text.Trim() + "'" + " where username='" + username + "';";
                    SqlCommand command1 = new SqlCommand(sql, con);
                    command1.ExecuteNonQuery();
                    Label1.Text = TextBox1.Text.Trim();
                    Response.Write("<script type='text/javascript'>alert('修改成功');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script type='text/javascript'>alert('" + ex.Message + "');</script>");
                }
            }
        }

    }
}