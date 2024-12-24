using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin_Control
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnbutton_Click(object sender, EventArgs e)
        {
            con.Close();

            SqlCommand sqlCommand = new SqlCommand("select * from Admin where admin_id=@contact and password=@pass", con);
            sqlCommand.Parameters.AddWithValue("@contact", txtcontact.Text);
            sqlCommand.Parameters.AddWithValue("@pass", txtpass.Text);  
            con.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Session["user"] = reader.GetValue(1);
                txtcontact.Text = "";
                txtpass.Text = "";
                if (Request.QueryString["type"] != null)
                {
                    if (Request.QueryString["type"] == "access")
                    {
                        Response.Redirect("Registrations.aspx");
                        Response.Redirect("AdminRegistration.aspx");                       
                        Response.Redirect("ContactAmin.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Registrations.aspx");

                }

            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Invalid Login..!','','error');", true);
            }
        }
    }
}