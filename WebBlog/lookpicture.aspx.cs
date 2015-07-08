using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace 图片管理
{
    public partial class lookpicture : System.Web.UI.Page
    {
        SqlConnection connection = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Con"].ConnectionString.ToString());
        string str = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Text"] != null)
            {
                str = Request.QueryString["Text"];
            }

            connection.Open();
            string SQLstr = "Select * from Image where id='" +str+ "'";
            SqlCommand command = new SqlCommand(SQLstr, connection);           
            SqlDataReader myReader;
            myReader = command.ExecuteReader();

        }
      
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            //connection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = connection;             
            myCommand.CommandText = "delete * from Image where id=TextBox1.Text";
            connection.Close();
        }
    }
}