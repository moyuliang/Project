using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Personal_Income_and_Expences
{
    public partial class AddRecord : System.Web.UI.Page
    {
        string username="";
        static int opMain = 0;
        double mainNum2 = 0;
        double sum = 0;
        static double mainNum1 = 0;
        static string type = "";
        string type_id = "";
        string date="";
        string sum1 = "";
        string date1 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.QueryString["Username"] != null)
            {
                username = Request.QueryString["Username"];
            }
            if (username.Equals(""))
                Response.Redirect("Login.aspx");
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

        protected void Button32_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            TextBox1.Text += "7";
        }

        protected void Button13_Click(object sender, EventArgs e)
        {
            TextBox1.Text += "8";
        }

        protected void Button14_Click(object sender, EventArgs e)
        {
            TextBox1.Text += "9";
        }
        protected void Button15_Click(object sender, EventArgs e)
        {
            mainNum1 = double.Parse(TextBox1.Text);
            opMain = 4;
            TextBox1.Text = "";
        }

        protected void Button16_Click(object sender, EventArgs e)
        {
            TextBox1.Text += "4";
        }

        protected void Button17_Click(object sender, EventArgs e)
        {
            TextBox1.Text += "5";
        }

        protected void Button18_Click(object sender, EventArgs e)
        {
            TextBox1.Text += "6";
        }

        protected void Button19_Click(object sender, EventArgs e)
        {
            mainNum1 = double.Parse(TextBox1.Text);
            opMain = 3;
            TextBox1.Text = "";
        }

        protected void Button20_Click(object sender, EventArgs e)
        {
            TextBox1.Text += "1";
        }

        protected void Button21_Click(object sender, EventArgs e)
        {
            TextBox1.Text += "2";
        }

        protected void Button22_Click(object sender, EventArgs e)
        {
            TextBox1.Text += "3";
        }

        protected void Button23_Click(object sender, EventArgs e)
        {
            mainNum1 = double.Parse(TextBox1.Text);
            opMain = 2;
            TextBox1.Text = "";
        }

        protected void Button24_Click(object sender, EventArgs e)
        {
            TextBox1.Text += ".";
        }

        protected void Button25_Click(object sender, EventArgs e)
        {
            TextBox1.Text += "0";
        }

        protected void Button26_Click(object sender, EventArgs e)
        {
            TextBox1.Text += "00";
        }

        protected void Button27_Click(object sender, EventArgs e)
        {
            mainNum1 = double.Parse(TextBox1.Text);
            opMain = 1;
            TextBox1.Text = "";
        }

        protected void Button28_Click(object sender, EventArgs e)
        {
            mainNum2 = double.Parse(TextBox1.Text);
            TextBox1.Text = "";
            if (mainNum2 != 0)
            {
                double answer = 0;
                switch (opMain)
                {
                    case 1:
                        answer = mainNum1 + mainNum2;
                        break;
                    case 2:
                        answer = mainNum1 - mainNum2;
                        break;
                    case 3:
                        answer = mainNum1 * mainNum2;
                        break;
                    case 4:
                        answer = mainNum1 / mainNum2;
                        break;
                }
                TextBox1.Text = answer.ToString();
            }
            if (mainNum2 == 0)
                TextBox1.Text = "除数不能为零。";
        }
        protected void Gettypeid()
        {
            using (SqlConnection connection = new SqlConnection
               (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
            {
                string SQLstr = "select* from Species_table where name='" + type + "'";
                SqlCommand myCommand = new SqlCommand(SQLstr, connection);
                SqlDataReader myReader;
                try
                {
                    connection.Open();
                    myReader = myCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        type_id = myReader["id"].ToString();
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

        protected void AddDailytable()
        {
            using (SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
            {
                if (type != "" && sum.ToString() != "" && TextBox2.Text != "")
                {
                    try
                    {
                        date1 = TextBox2.Text;
                        connection.Open();
                        string data = "insert into Daily_table(date,species_id,user_name,day_cost) " + " values('" + date1 + "','" + type_id + "','" + username + "','" + sum + "')";

                        SqlCommand myCommand = new SqlCommand(data, connection);

                        int count = myCommand.ExecuteNonQuery();
                        if (count > 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "提示", "alert('填写成功');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "提示", "alert('对不起，填写失败！');", true);
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
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "提示", "alert('请选择类型、输入金额和日期！！');", true);
                }
            }
        }
        protected void btninit()
        {
            Button1.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            Button2.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            Button3.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            Button4.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            Button5.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            Button6.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            Button7.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            Button8.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            Button9.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            Button10.BackColor = ColorTranslator.FromHtml("#FFFFFF");
            Button11.BackColor = ColorTranslator.FromHtml("#FFFFFF");
        }
        protected void btnchecked(Button button)
        {
            button.BackColor = ColorTranslator.FromHtml("#EEE");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            type = Button1.Text;
            btninit();
            btnchecked(Button1);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            type = Button2.Text;
            btninit();
            btnchecked(Button2);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            type = Button3.Text;
            btninit();
            btnchecked(Button3);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            type = Button4.Text;
            btninit();
            btnchecked(Button4);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            type = Button5.Text;
            btninit();
            btnchecked(Button5);
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            type = Button6.Text;
            btninit();
            btnchecked(Button6);
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            type = Button7.Text;
            btninit();
            btnchecked(Button7);
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            type = Button8.Text;
            btninit();
            btnchecked(Button8);
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            type = Button9.Text;
            btninit();
            btnchecked(Button9);
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            type = Button10.Text;
            btninit();
            btnchecked(Button10);
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            type = Button11.Text;
            btninit();
            btnchecked(Button11);
        }

        protected void Button29_Click(object sender, EventArgs e)
        {
            sum = Convert.ToDouble(TextBox1.Text);
            Gettypeid();
            AddDailytable();
            TextBox1.Text = "";
        }


        //登录之后导航栏上的主页按钮
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx?Username=" + username);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageRecord.aspx?Username=" + username + "&Date=" + date);
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            date = Calendar1.SelectedDate.Date.ToString("yyyyMMdd");
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "提示", "alert('" + date + "');", true);
            Response.Redirect("ManageRecord.aspx?Username=" + username + "&Date=" + date);
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date.Month == Convert.ToInt16(DateTime.Now.ToString("MM")) && e.Day.Date.Day == Convert.ToInt16(DateTime.Now.ToString("dd")))
            {
                SqlConnection connection3 = new SqlConnection
                  (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString());
                SqlCommand cmd = new SqlCommand("select sum(day_cost) sum from costs where user_name='" + username + "' group by user_name;", connection3);
                SqlDataReader myReader;
                try
                {
                    connection3.Open();
                    myReader = cmd.ExecuteReader();
                    if (myReader.Read())
                    {
                        sum1 = myReader["sum"].ToString();
                    }

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                    connection3.Close();
                }
                string str = sum1.ToString();
                e.Cell.Controls.Add(new LiteralControl("<br/>" + str + "&nbsp;&nbsp;"));
            }

        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reset.aspx?Username=" + username);
        }

        protected void Button30_Click(object sender, EventArgs e)
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