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
    public partial class Fab_Admin_Create_Salaryslip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindHelperDropdown();
            }
        }
        private void BindHelperDropdown()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT User_id, User_name FROM Fab_Users", con))
                {

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ddlHelpername.DataSource = reader;
                        ddlHelpername.DataTextField = "User_name";
                        ddlHelpername.DataValueField = "User_id";
                        ddlHelpername.DataBind();
                    }
                }
            }

            ddlHelpername.Items.Insert(0, new ListItem("--Select Helper--", ""));
        }

    }
}