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
    public partial class Fab_Admin_Attendance : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                lblDay.Text = DateTime.Now.ToString("dddd");
            }

            if (!IsPostBack)
            {
                gridAttendance.DataSource = GvAttendance();
                gridAttendance.DataBind();
            }
        }


        protected DataSet GvAttendance()
        {
            con.Close();
            DateTime today = DateTime.Now.Date;

            SqlCommand cmd = new SqlCommand("select * from Fab_Helper_Att where CAST(date AS DATE) = @ToDate ", con);
            con.Open();

            cmd.Parameters.AddWithValue("@ToDate",today); 

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;

        }

        protected void gridAttendance_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gridAttendance_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void gridAttendance_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void gridAttendance_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}