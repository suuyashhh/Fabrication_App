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
            if (!IsPostBack)
            {
                gridSalaryHistory.DataSource = SalHistory();
                gridSalaryHistory.DataBind();
            }
        }

        protected DataSet SalHistory()
        {
            con.Close();
            SqlCommand cmd = new SqlCommand("Select Slip_id,User_id,Slip_Day from Salary_Slip order by Slip_Day Desc", con);
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            return ds;
        }
    }
}