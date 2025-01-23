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
    public partial class Fab_Admin_FillAttendance : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["AdminId"] == null)
            //{
            //    Response.Redirect("Fab_Admin_Login.aspx?type=Fab_Admin_Master");
            //}

            if (!IsPostBack)
            {
                BindHelperDropdown();
            }
            SetCurrentDate();
        }

        protected void SetCurrentDate()
        {

            DateTime todayDate = GetCurrentDate();
            AFdate.Text = todayDate.ToString("yyyy-MM-dd");
        }

        protected DateTime GetCurrentDate()
        {
            DateTime serverTime = DateTime.Now;
            DateTime localTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(serverTime, TimeZoneInfo.Local.Id, "India Standard Time");
            return localTime.Date;
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

        protected void btnSubmitAFAtt_Click(object sender, EventArgs e)
        {
            con.Close();

            SqlCommand cmdcheck = new SqlCommand("Select * from Fab_helper_Att Where Cast(date AS DATE) = @dt AND User_name = @UserName", con);
            cmdcheck.Parameters.AddWithValue("@dt", AFdate.Text);
            cmdcheck.Parameters.AddWithValue("UserName", ddlHelpername.SelectedItem.Text);
            con.Open();
            SqlDataReader reader = cmdcheck.ExecuteReader();

            if (reader.HasRows)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('You have already selected:','','warning');", true);

            }
            else
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Fab_Helper_Att (User_id, User_name, User_day, date) VALUES (@UserId, @UserName, @userDay, @dt)", con))
                    {
                        // Get selected values from the dropdowns
                        cmd.Parameters.AddWithValue("@userDay", ddlworktype.SelectedValue);
                        cmd.Parameters.AddWithValue("@UserName", ddlHelpername.SelectedItem.Text);
                        cmd.Parameters.AddWithValue("@UserId", ddlHelpername.SelectedValue);
                        cmd.Parameters.AddWithValue("@dt", AFdate.Text);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                BindHelperDropdown();

                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Record saved successfully','','success');", true);

            }
        }
    }
}