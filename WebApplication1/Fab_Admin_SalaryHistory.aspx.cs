using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Fab_Admin_SalaryHistory2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminId"] == null)
            {
                Response.Redirect("Fab_Admin_Login.aspx?type=Fab_Admin_SalaryHistory");
            }

            if (!IsPostBack)
            {
                gridSalaryHistory.DataSource = SalHistory();
                gridSalaryHistory.DataBind();
            }
        }

        protected DataSet SalHistory()
        {
            con.Close();
            SqlCommand cmd = new SqlCommand("Select SS.Slip_id,FU.User_name,SS.Slip_Day from Salary_Slip SS Left join Fab_Users FU ON SS.User_id = FU.User_id order by Slip_Day Desc", con);
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            return ds;
        }
    }
}