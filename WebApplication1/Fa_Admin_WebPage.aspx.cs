using System;
using System.Web;

namespace WebApplication1
{
    public partial class AWebPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["username"] == null)
            //{

            //    if (Request.Cookies["UserAuth"] != null)
            //    {
            //        HttpCookie cookie = Request.Cookies["UserAuth"];
            //        Session["username"] = cookie["username"];
            //        Session["userId"] = cookie["userId"];
            //        Session["contact"] = cookie["contact"];
            //    }
            //    else
            //    {
            //        Response.Redirect("Login.aspx?type=webpage");
            //    }
            //}

            //if (Session["username"] != null)
            //{
            //    btn_lbl.Text = Session["username"].ToString();
            //}
        }

        protected void logoutButton_Click1(object sender, EventArgs e)
        {
            //Session.RemoveAll();

            //if (Request.Cookies["UserAuth"] != null)
            //{
            //    HttpCookie cookie = new HttpCookie("UserAuth");
            //    cookie.Expires = DateTime.Now.AddDays(-1); 
            //    Response.Cookies.Add(cookie);
            //}

            //this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('You are logged out successfully','','success');", true);
            //Response.Redirect("Login.aspx");
        }
    }
}