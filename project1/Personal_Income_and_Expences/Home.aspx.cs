using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Personal_Income_and_Expences
{
    public partial class Home : System.Web.UI.Page
    {
        string username="";
        int CurrentPage, RecordCount;
        int PageCount, PageSize;
        SqlConnection connection5 = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.QueryString["Username"] != null)
            {
                username = Request.QueryString["Username"];
                Label1.Text = username;
            }
            BindDataToSum();

            //设定PageSize 
            PageSize = 5;
            using (connection5 = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["con"].ConnectionString.ToString()))
            {
                connection5.Open();
                if (!IsPostBack)
                {
                    CurrentPage = 0;
                    ViewState["PageIndex"] = 0;

                    //计算总共有多少记录 
                    RecordCount = CalculateRecord();

                    if (RecordCount > PageSize)
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
                    BindDataToDetail();
                }
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
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
                finally
                {
                    connection2.Close();
                }
            }
        }

        //登录之后点击导航栏添加
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddRecord.aspx?Username=" + username);
        }

        //统计图表中的数据
        public string dataChart()
        {
            if(username.Equals(""))
            {
                Response.Redirect("Login.aspx");
            }
            string s = null;
            string x = "";
            using (SqlConnection connection6 = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
            {
                connection6.Open();
                SqlCommand myCommand = new SqlCommand("select Count from Month_Sum where user_name='" + username + "';", connection6);
                SqlDataReader myReader = myCommand.ExecuteReader();
                if(!myReader.HasRows)
                {
                    x = "0";
                }
                else
                {
                    while (myReader.Read())
                    {
                        s += myReader["Count"].ToString() + ",";
                    }
                    x = s.Substring(0, s.Length - 1);
                }
            }
            return x;
        }

        private void BindDataToSum()
        {
            SqlConnection connection3 = new SqlConnection
                  (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString());
            connection3.Open();
            string date = DateTime.Now.ToString("yyyyMMdd");
            SqlCommand cmd = new SqlCommand("select name,sum(day_cost) sum from costs where user_name='" + username + "' and date='" + date + "' group by name;", connection3);

            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataSet ds = new DataSet();
            sda.Fill(ds, "costs");
            Repeater1.DataSource = ds.Tables["costs"];
            Repeater1.DataBind();
            connection3.Close();
        }

        public int CalculateRecord()
        {
            SqlConnection connection4 = new SqlConnection
                  (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString());
            connection4.Open();

            SqlCommand myCommand = new SqlCommand("select count(1) from Daily_table,Species_table where species_id=Species_table.id and user_name='" + username + "';", connection4);
            int intCount = (int)myCommand.ExecuteScalar();
            return intCount;
        }

        ICollection CreateSource()
        {
            
            using (connection5 = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
            {
                connection5.Open();
                int StartIndex;

                //设定导入的起终地址 
                StartIndex = CurrentPage * PageSize;
                
                SqlDataAdapter MyAdapter = new SqlDataAdapter("select Daily_table.id,Species_table.name,day_cost,date from Daily_table,Species_table where species_id=Species_table.id and user_name='" + username + "' order by date desc;", connection5);

                DataSet ds = new DataSet();

                MyAdapter.Fill(ds, StartIndex, PageSize, "Daily_table,Species_table");
                
                return ds.Tables["Daily_table,Species_table"].DefaultView;
            }
        }

        private void BindDataToDetail()
        {
            Repeater2.DataSource = CreateSource();
            Repeater2.DataBind();
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
                    if (CurrentPage < (PageCount - 1))
                    {
                        ++CurrentPage;
                        ViewState["PageIndex"] = CurrentPage;
                    }
                    break;
                case "prev":
                    if (CurrentPage > 0)
                    {
                        --CurrentPage;
                        ViewState["PageIndex"] = CurrentPage;
                    }
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
            BindDataToDetail();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageRecord.aspx?Username=" + username);
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

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reset.aspx?Username=" + username);
        }

    }
}