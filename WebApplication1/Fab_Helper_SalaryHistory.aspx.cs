using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Fab_Helper_SalaryHistory : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridhelpSalaryHistory.DataSource = HelperSalary();
                gridhelpSalaryHistory.DataBind();
            }

        }

        protected DataSet HelperSalary()
        {
            con.Close();

            SqlCommand cmd = new SqlCommand("select Slip_id,User_id,Slip_Day from Salary_Slip where User_id = 1 order by Slip_Day Desc ", con);
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            sdr.Fill(ds);
            return ds;
        }
    }
}