using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Fab_Admin_WebPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Check if the session is active, otherwise check for cookie
            if (Session["AdminId"] == null)
            {
                // Check for login cookie
                if (Request.Cookies["AdminAuth"] != null)
                {
                    // Restore session from the cookie
                    HttpCookie cookie = Request.Cookies["AdminAuth"];
                    Session["AdminId"] = cookie["AdminId"];
                }
                else
                {
                    // Redirect to login page if no session or cookie
                    Response.Redirect("Fab_Admin_Login.aspx?type=Fabrication_Admin");
                }
            }

            btn_lbl.Text = "JB-FABRICATION";

        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            // Clear session
            Session.RemoveAll();

            // Clear the authentication cookie
            if (Request.Cookies["AdminAuth"] != null)
            {
                HttpCookie cookie = new HttpCookie("AdminAuth");
                cookie.Expires = DateTime.Now.AddDays(-1); // Expire the cookie
                Response.Cookies.Add(cookie);
            }

            // Show logout success message and redirect to login page
            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('You are logged out successfully','','success');", true);
            Response.Redirect("Fab_Admin_Login.aspx");

        }
    }
}