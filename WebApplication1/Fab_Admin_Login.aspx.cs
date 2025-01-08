using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Fab_Admin_Login : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if there is already a login cookie
            if (Session["AdminId"] == null && Request.Cookies["AdminAuth"] != null)
            {
                // Restore session from the cookie
                HttpCookie cookie = Request.Cookies["AdminAuth"];
                Session["AdminId"] = cookie["AdminId"];

                // Redirect to home page
                Response.Redirect("Fabrication_Admin.aspx");
            }   
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
                Session["AdminId"] = reader.GetValue(1);

                // Create a persistent cookie
                HttpCookie AdminCookie = new HttpCookie("AdminAuth");
                AdminCookie["AdminId"] = reader.GetValue(1).ToString();
                AdminCookie.Expires = DateTime.Now.AddDays(30); // Cookie valid for 30 days
                Response.Cookies.Add(AdminCookie);

                // Clear the input fields
                txtcontact.Text = "";
                txtpass.Text = "";

                // Redirect to the corresponding page
                if (Request.QueryString["type"] != null)
                {
                    string type = Request.QueryString["type"];
                    Response.Redirect($"{type}.aspx");
                }
                else
                {
                    Response.Redirect("Fabrication_Admin.aspx");
                }
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Invalid Login..!','','error');", true);
            }

            con.Close();
        }
    }
}