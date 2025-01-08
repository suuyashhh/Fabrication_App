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
            if (Session["AdminId"]== null)
            {
                Response.Redirect("Fab_Admin_Login.aspx?type=Fab_Admin_Attendance");
            }
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
            gridAttendance.EditIndex = e.NewEditIndex;
            gridAttendance.DataSource = GvAttendance();
            gridAttendance.DataBind();
        }

        protected void gridAttendance_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridAttendance.EditIndex = -1;
            gridAttendance.DataSource = GvAttendance();
            gridAttendance.DataBind();
        }

        protected void gridAttendance_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridAttendance.Rows[e.RowIndex];
            string H_id = gridAttendance.DataKeys[e.RowIndex].Value.ToString();
            string User_day = ((TextBox)row.FindControl("txtday")).Text;

            SqlCommand cmd = new SqlCommand("UPDATE Fab_Helper_Att SET User_day = @User_day WHERE H_id = @H_id", con);
            cmd.Parameters.AddWithValue("@User_day", User_day);
            cmd.Parameters.AddWithValue("@H_id", H_id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            gridAttendance.EditIndex = -1;
            gridAttendance.DataSource = GvAttendance();
            gridAttendance.DataBind();
        }

        protected void gridAttendance_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string H_id = gridAttendance.DataKeys[e.RowIndex].Value.ToString();
            SqlCommand cmd = new SqlCommand("DELETE FROM Fab_Helper_Att WHERE H_id = @H_id", con);
            cmd.Parameters.AddWithValue("@H_id", H_id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            gridAttendance.DataSource = GvAttendance();
            gridAttendance.DataBind();

        }

       

    }
}