using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBlog
{
    public partial class Homepage : System.Web.UI.Page
    {
        int num=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string sqlstr = "select id,title,author from Artical ";
            SqlConnection connection1 = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString());
            SqlDataAdapter myda = new SqlDataAdapter(sqlstr, connection1);
            DataSet myds = new DataSet();
            connection1.Open();
            myda.Fill(myds, "Artical");
            GridView1.DataSource = myds;
            GridView1.DataKeyNames = new string[] { "id" };//主键
            GridView1.DataBind();
            connection1.Close();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString());
            string SQLstr1 = "select * from ArticalType where name='" + LinkButton4.Text + "'";
            SqlCommand myCommand1 = new SqlCommand(SQLstr1, connection);
            SqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = myCommand1.ExecuteReader();
                while (myReader.Read())
                {
                    num = (Int32)myReader["id"];
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

            string sqlstr = "select id,title,author from Artical where type='" + num + "'";
            SqlConnection connection1 = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString());
            SqlDataAdapter myda = new SqlDataAdapter(sqlstr, connection1);
            DataSet myds = new DataSet();
            connection1.Open();
            myda.Fill(myds, "Artical");
            GridView1.DataSource = myds;
            GridView1.DataKeyNames = new string[] { "id" };//主键
            GridView1.DataBind();
            connection1.Close();

        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString());
            string SQLstr1 = "select * from ArticalType where name='" + LinkButton4.Text + "'";
            SqlCommand myCommand1 = new SqlCommand(SQLstr1, connection);
            SqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = myCommand1.ExecuteReader();
                while(myReader.Read())
                {
                    num = (Int32)myReader["id"];
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

            string sqlstr = "select id,title,author from Artical where type='" + num + "'";
            SqlConnection connection1 = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString());
            SqlDataAdapter myda = new SqlDataAdapter(sqlstr, connection1);
            DataSet myds = new DataSet();
            connection1.Open();
            myda.Fill(myds, "Artical");
            GridView1.DataSource = myds;
            GridView1.DataKeyNames = new string[] { "id" };//主键
            GridView1.DataBind();
            connection1.Close();
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString());
            string SQLstr1 = "select * from ArticalType where name='" + LinkButton5.Text + "'";
            SqlCommand myCommand1 = new SqlCommand(SQLstr1, connection);
            SqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = myCommand1.ExecuteReader();
                if (myReader.Read())
                {
                    num = (Int32)myReader["id"];
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
            string sqlstr = "select id,title,author from Artical where type='" + num + "'";
            SqlConnection connection1 = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString());
            SqlDataAdapter myda = new SqlDataAdapter(sqlstr, connection1);
            DataSet myds = new DataSet();
            connection1.Open();
            myda.Fill(myds, "Artical");
            GridView1.DataSource = myds;
            GridView1.DataKeyNames = new string[] { "id" };//主键
            GridView1.DataBind();
            connection1.Close();
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString());
            string SQLstr1 = "select * from ArticalType where name='" + LinkButton7.Text + "'";
            SqlCommand myCommand1 = new SqlCommand(SQLstr1, connection);
            SqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = myCommand1.ExecuteReader();
                if (myReader.Read())
                {
                    num = (Int32)myReader["id"];
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
            string sqlstr = "select id,title,author from Artical where type='" + num + "'";
            SqlConnection connection1 = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString());
            SqlDataAdapter myda = new SqlDataAdapter(sqlstr, connection1);
            DataSet myds = new DataSet();
            connection1.Open();
            myda.Fill(myds, "Artical");
            GridView1.DataSource = myds;
            GridView1.DataKeyNames = new string[] { "id" };//主键
            GridView1.DataBind();
            connection1.Close();
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString());
            string SQLstr1 = "select * from ArticalType where name='" + LinkButton6.Text + "'";
            SqlCommand myCommand1 = new SqlCommand(SQLstr1, connection);
            SqlDataReader myReader;
            try
            {
                connection.Open();
                myReader = myCommand1.ExecuteReader();
                if (myReader.Read())
                {
                    num = (Int32)myReader["id"];
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
            string sqlstr = "select id,title,author from Artical where type='" + num + "'";
            SqlConnection connection1 = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString());
            SqlDataAdapter myda = new SqlDataAdapter(sqlstr, connection1);
            DataSet myds = new DataSet();
            connection1.Open();
            myda.Fill(myds, "Artical");
            GridView1.DataSource = myds;
            GridView1.DataKeyNames = new string[] { "id" };//主键
            GridView1.DataBind();
            connection1.Close();
        }


        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string sqlstr = "select id,title,author from Artical ";
            SqlConnection connection1 = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString());
            SqlDataAdapter myda = new SqlDataAdapter(sqlstr, connection1);
            DataSet myds = new DataSet();
            connection1.Open();
            myda.Fill(myds, "Artical");
            GridView1.DataSource = myds;
            GridView1.DataKeyNames = new string[] { "id" };//主键
            GridView1.DataBind();
            connection1.Close();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            string sqlstr = "select id,title,author from Artical ";
            SqlConnection connection1 = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString());
            SqlDataAdapter myda = new SqlDataAdapter(sqlstr, connection1);
            DataSet myds = new DataSet();
            connection1.Open();
            myda.Fill(myds, "Artical");
            GridView1.DataSource = myds;
            GridView1.DataKeyNames = new string[] { "id" };//主键
            GridView1.DataBind();
            connection1.Close();
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Response.Redirect("Read.aspx?ID=" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "&username=123456@qq.com");
        }

    }
}