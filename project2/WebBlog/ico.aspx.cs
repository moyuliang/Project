using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBlog
{
    public partial class ico : System.Web.UI.Page
    {
        string user_name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                user_name = Request.QueryString["Username"];
                using (SqlConnection connection = new SqlConnection
                      (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand myCommand = new SqlCommand("select ico from UserTable where username='" + user_name + "';", connection);

                        SqlDataReader myReader = myCommand.ExecuteReader();

                        if (myReader.Read() == true)
                        {
                            Response.BinaryWrite((byte[])myReader["ico"]);
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
            }
        }
    }
}