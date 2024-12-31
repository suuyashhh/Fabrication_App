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
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
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
                using (SqlCommand cmd = new SqlCommand("SELECT User_id, User_name FROM Fab_Users", con)) // Filter valid users
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


        private void BindAttendanceSummary(DateTime fromDate, DateTime toDate)
        {
            string connString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"
WITH AttendanceSummary AS (
    SELECT 
        HA.User_id,
        SUM(CASE WHEN HA.User_day = 'Full Day' THEN 1 ELSE 0 END) AS FullDay_Count,
        SUM(CASE WHEN HA.User_day = 'Half Day' THEN 1 ELSE 0 END) AS HalfDay_Count,
        SUM(CASE WHEN HA.User_day = 'Off Day' THEN 1 ELSE 0 END) AS OffDay_Count
    FROM
        Fab_Helper_Att HA
    WHERE 
        CAST(HA.date AS DATE) BETWEEN @FromDate AND @ToDate
    GROUP BY 
        HA.User_id
),
ExpenseSummary AS (
    SELECT 
        FE.User_id,
        SUM(FE.User_advance) AS TOTAL_ADVANCE
    FROM 
        Fab_Expanse FE
    WHERE 
        CAST(FE.date AS DATE) BETWEEN @FromDate AND @ToDate
    GROUP BY 
        FE.User_id
)
SELECT 
    FU.User_id,
    FU.User_name,
    FU.User_salary,
    COALESCE(ES.TOTAL_ADVANCE, 0) AS TOTAL_ADVANCE,
    COALESCE(ASUM.FullDay_Count, 0) AS FullDay_Count,
    COALESCE(ASUM.HalfDay_Count, 0) AS HalfDay_Count,
    COALESCE(ASUM.OffDay_Count, 0) AS OffDay_Count
FROM 
    Fab_Users FU
LEFT JOIN 
    AttendanceSummary ASUM 
    ON FU.User_id = ASUM.User_id
LEFT JOIN 
    ExpenseSummary ES 
    ON FU.User_id = ES.User_id
WHERE 
    FU.User_id = @UserId
ORDER BY 
    FU.User_id;
";


                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                    cmd.Parameters.AddWithValue("@ToDate", toDate);
                    cmd.Parameters.AddWithValue("@UserId", ddlHelpername.SelectedValue);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    rptAttendanceSummary.DataSource = reader;
                    rptAttendanceSummary.DataBind();

                    conn.Close();
                }
            }
        }

        protected void btnSearchDatePE_Click(object sender, EventArgs e)
        {
            DateTime fromDateValue, toDateValue;

            if (!DateTime.TryParse(fromDate.Text, out fromDateValue) || !DateTime.TryParse(toDate.Text, out toDateValue))
            {
            
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "swal('Invalid Date Format', '', 'error');", true);
                return;
            }

            if (fromDateValue > toDateValue)
            {
            
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "swal('From Date cannot be later than To Date!', '', 'warning');", true);
                return;
            }

            
            BindAttendanceSummary(fromDateValue, toDateValue);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            string userId = ddlHelpername.SelectedValue; 
            string fromDat = fromDate.Text; 
            string toDat = toDate.Text; 

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(fromDat) || string.IsNullOrEmpty(toDat))
            {
                Response.Write("<script>alert('Please fill in all required fields.');</script>");
                return;
            }

            
            string connectionString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

            
                foreach (RepeaterItem item in rptAttendanceSummary.Items)
                {
            
                    int fullDayCount = int.Parse(((Label)item.FindControl("fullDayCount")).Text);
                    int halfDayCount = int.Parse(((Label)item.FindControl("halfDayCount")).Text);
                    int offDayCount = int.Parse(((Label)item.FindControl("offDayCount")).Text);
                    decimal fullDaySalary = decimal.Parse(((TextBox)item.FindControl("fullDaySalary")).Text);
                    decimal halfDaySalary = decimal.Parse(((TextBox)item.FindControl("halfDaySalary")).Text);
                    decimal advanceAmount = decimal.Parse(((TextBox)item.FindControl("advanceAmount")).Text);
                    decimal fullDayTotal = decimal.Parse(((Label)item.FindControl("fullDayTotal")).Text);
                    decimal halfDayTotal = decimal.Parse(((Label)item.FindControl("halfDayTotal")).Text);
                    decimal grandTotal = decimal.Parse(((Label)item.FindControl("grandTotal")).Text);

            
                    string query = @"
                INSERT INTO Salary_Slip 
                (user_id, From_date, TO_date, Full_day, Half_day, Off_day, Full_salary, Half_salary, Advance_salary, Full_day_Total, Half_day_total, Advance_total, Grand_total, Slip_day)
                VALUES 
                (@user_id, @From_date, @TO_date, @Full_day, @Half_day, @Off_day, @Full_salary, @Half_salary, @Advance_salary, @Full_day_Total, @Half_day_total, @Advance_total, @Grand_total, @Slip_day)";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@user_id", userId);
                        cmd.Parameters.AddWithValue("@From_date", fromDate);
                        cmd.Parameters.AddWithValue("@TO_date", toDate);
                        cmd.Parameters.AddWithValue("@Full_day", fullDayCount);
                        cmd.Parameters.AddWithValue("@Half_day", halfDayCount);
                        cmd.Parameters.AddWithValue("@Off_day", offDayCount);
                        cmd.Parameters.AddWithValue("@Full_salary", fullDaySalary);
                        cmd.Parameters.AddWithValue("@Half_salary", halfDaySalary);
                        cmd.Parameters.AddWithValue("@Advance_salary", advanceAmount);
                        cmd.Parameters.AddWithValue("@Full_day_Total", fullDayTotal);
                        cmd.Parameters.AddWithValue("@Half_day_total", halfDayTotal);
                        cmd.Parameters.AddWithValue("@Advance_total", advanceAmount);
                        cmd.Parameters.AddWithValue("@Grand_total", grandTotal);
                        cmd.Parameters.AddWithValue("@Slip_day", 1);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            Response.Write("<script>alert('Salary slip saved successfully.');</script>");
        }


    }
}