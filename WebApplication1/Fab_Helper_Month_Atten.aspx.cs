using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Fab_Helper_Month_Atten : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["HelperId"] == null)
            {
                Response.Redirect("Fab_Helper_Login.aspx?type=Fab_Helper_Month_Atten");
            }
            if (Session["HelperName"] != null)
            {
                LblHelper.Text = Session["HelperName"].ToString();
            }
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
                FU.User_id = @HelperId
            ORDER BY 
                FU.User_id;
        ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate); cmd.Parameters.AddWithValue("@ToDate", toDate); cmd.Parameters.AddWithValue("@HelperId", Session["HelperId"]);



                    try
                    {
                        conn.Open();
                        rptAttendanceSummary.DataSource = cmd.ExecuteReader();
                        rptAttendanceSummary.DataBind();
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "error", $"swal('Error: {ex.Message}', '', 'error');", true);
                    }
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


        protected void AttendanceCalendar_DayRender(object sender, DayRenderEventArgs e)
        {
            // Ensure we're only modifying dates in the current month
            if (e.Day.IsOtherMonth)
            {
                e.Cell.Text = string.Empty; // Clear the cell for other months
                e.Cell.BackColor = System.Drawing.Color.LightGray;
                return;
            }

            // Fetch the attendance data for the current Helper
            DataTable attendanceData = GetAttendanceDataForMonth(e.Day.Date);

            if (attendanceData.Rows.Count > 0)
            {
                foreach (DataRow row in attendanceData.Rows)
                {
                    DateTime attendanceDate = Convert.ToDateTime(row["Date"]);
                    string dayType = row["User_day"].ToString();

                    if (e.Day.Date == attendanceDate)
                    {
                        switch (dayType)
                        {
                            case "Full Day":
                                e.Cell.BackColor = System.Drawing.Color.LightGreen; // Full Day - Green
                                break;
                            case "Half Day":
                                e.Cell.BackColor = System.Drawing.Color.Yellow; // Half Day - Yellow
                                break;
                            case "Off Day":
                                e.Cell.BackColor = System.Drawing.Color.Red; // Off Day - Red
                                break;
                        }
                    }
                }
            }
        }

        private DataTable GetAttendanceDataForMonth(DateTime date)
        {
            DataTable dataTable = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"
            SELECT CAST(date AS DATE) AS Date, User_day 
            FROM Fab_Helper_Att 
            WHERE 
                User_id = @HelperId AND
                MONTH(date) = @Month AND YEAR(date) = @Year";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@HelperId", Session["HelperId"]);
                    cmd.Parameters.AddWithValue("@Month", date.Month);
                    cmd.Parameters.AddWithValue("@Year", date.Year);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

    }
}