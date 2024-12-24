using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin_Control
{
    public partial class AdminDairyFarm : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("AdminLogin.aspx");
        }
    }
}