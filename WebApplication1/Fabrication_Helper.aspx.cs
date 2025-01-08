using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Fab_Helper_WebPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Check if the session is active, otherwise check for cookie
            if (Session["HelperName"] == null)
            {
                // Check for login cookie
                if (Request.Cookies["HelperAuth"] != null)
                {
                    // Restore session from the cookie
                    HttpCookie cookie = Request.Cookies["HelperAuth"];
                    Session["HelperName"] = cookie["HelperName"];
                    Session["HelperId"] = cookie["HelperId"];
                }
                else
                {
                    // Redirect to login page if no session or cookie
                    Response.Redirect("Fab_Helper_Login.aspx?type=Fabrication_Helper");
                }
            }

            // Set username in the label
            if (Session["HelperName"] != null)
            {
                btn_lbl.Text = Session["HelperName"].ToString();
            }




        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            // Clear session
            Session.RemoveAll();

            // Clear the authentication cookie
            if (Request.Cookies["HelperAuth"] != null)
            {
                HttpCookie cookie = new HttpCookie("HelperAuth");
                cookie.Expires = DateTime.Now.AddDays(-1); // Expire the cookie
                Response.Cookies.Add(cookie);
            }

            // Show logout success message and redirect to login page
            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('You are logged out successfully','','success');", true);
            Response.Redirect("Fab_Helper_Login.aspx");
        }
    }
}