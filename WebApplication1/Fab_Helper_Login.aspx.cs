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
    public partial class Fab_Helper_Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if there is already a login cookie
            if (Session["HelperName"] == null && Request.Cookies["HelperAuth"] != null)
            {
                // Restore session from the cookie
                HttpCookie cookie = Request.Cookies["HelperAuth"];
                Session["HelperId"] = cookie["HelperId"];
                Session["HelperName"] = cookie["HelperName"];

                // Redirect to home page
                Response.Redirect("Fabrication_Helper.aspx");
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("Select * from Fab_Users where User_contact=@contact and User_pass=@Pass", con);
            sqlCommand.Parameters.AddWithValue("@contact", UserContact.Text);
            sqlCommand.Parameters.AddWithValue("@pass", UserPassword.Text);

            con.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                Session["HelperName"] = reader.GetValue(1);
                Session["HelperId"] = reader.GetValue(0);

                // Create a persistent cookie
                HttpCookie helperCookie = new HttpCookie("HelperAuth");
                helperCookie["HelperName"] = reader.GetValue(1).ToString();
                helperCookie["HelperId"] = reader.GetValue(0).ToString();
                helperCookie.Expires = DateTime.Now.AddDays(30); // Cookie valid for 30 days
                Response.Cookies.Add(helperCookie);

                // Clear the input fields
                UserContact.Text = "";
                UserPassword.Text = "";

                // Redirect to the corresponding page
                if (Request.QueryString["type"] != null)
                {
                    string type = Request.QueryString["type"];
                    Response.Redirect($"{type}.aspx");
                }
                else
                {
                    Response.Redirect("Fabrication_Helper.aspx");
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
