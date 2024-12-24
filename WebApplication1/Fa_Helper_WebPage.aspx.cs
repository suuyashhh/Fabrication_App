using System;
using System.Web;

namespace WebApplication1
{
    public partial class WebPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //// Check if the session is active, otherwise check for cookie
            //if (Session["username"] == null)
            //{
            //    // Check for login cookie
            //    if (Request.Cookies["UserAuth"] != null)
            //    {
            //        // Restore session from the cookie
            //        HttpCookie cookie = Request.Cookies["UserAuth"];
            //        Session["username"] = cookie["username"];
            //        Session["userId"] = cookie["userId"];
            //        Session["contact"] = cookie["contact"];
            //    }
            //    else
            //    {
            //        // Redirect to login page if no session or cookie
            //        Response.Redirect("Login.aspx?type=webpage");
            //    }
            //}

            //// Set username in the label
            //if (Session["username"] != null)
            //{
            //    btn_lbl.Text = Session["username"].ToString();
            //}
        }

        protected void logoutButton_Click1(object sender, EventArgs e)
        {
            //// Clear session
            //Session.RemoveAll();

            //// Clear the authentication cookie
            //if (Request.Cookies["UserAuth"] != null)
            //{
            //    HttpCookie cookie = new HttpCookie("UserAuth");
            //    cookie.Expires = DateTime.Now.AddDays(-1); // Expire the cookie
            //    Response.Cookies.Add(cookie);
            //}

            //// Show logout success message and redirect to login page
            //this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('You are logged out successfully','','success');", true);
            //Response.Redirect("Login.aspx");
        }
    }
}
