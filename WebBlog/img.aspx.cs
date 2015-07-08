using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBlog
{
    public partial class img : System.Web.UI.Page
    {
        string user_name = "";
        string picname = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                user_name = Request.QueryString["Username"];
                picname = Request.QueryString["Picname"];
                using (SqlConnection connection = new SqlConnection
                      (System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString()))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand myCommand = new SqlCommand("select image from Image where username='" + user_name + "' and image_name='"+picname+ "';", connection);

                        SqlDataReader myReader = myCommand.ExecuteReader();

                        if (myReader.Read() == true)
                        {
                            Response.BinaryWrite((byte[])myReader["image"]);
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