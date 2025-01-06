using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
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
                    var fullDayLabel = item.FindControl("fullDayCount") as Label;
                    var halfDayLabel = item.FindControl("halfDayCount") as Label;
                    var offDayLabel = item.FindControl("offDayCount") as Label;
                    var fullDayTextBox = item.FindControl("fullDaySalary") as TextBox;
                    var halfDayTextBox = item.FindControl("halfDaySalary") as TextBox;
                    var advanceTextBox = item.FindControl("advanceAmount") as TextBox;
                    var fullDayTotalLabel = item.FindControl("fullDayTotal") as Label;
                    var halfDayTotalLabel = item.FindControl("halfDayTotal") as Label;
                    var grandTotalLabel = item.FindControl("grandTotal") as Label;

                    if (fullDayLabel != null && halfDayLabel != null && fullDayTextBox != null)
                    {
                        int fullDayCount = int.Parse(fullDayLabel.Text);
                        int halfDayCount = int.Parse(halfDayLabel.Text);
                        int offDayCount = int.Parse(offDayLabel.Text);
                        decimal fullDaySalary = decimal.Parse(fullDayTextBox.Text);
                        decimal halfDaySalary = decimal.Parse(halfDayTextBox.Text);
                        decimal advanceAmount = decimal.Parse(advanceTextBox.Text);
                        decimal fullDayTotal = decimal.Parse(fullDayTotalLabel.Text);
                        decimal halfDayTotal = decimal.Parse(halfDayTotalLabel.Text);
                        decimal grandTotal = decimal.Parse(grandTotalLabel.Text);

                        string query = @"
                    INSERT INTO Salary_Slip 
                    (user_id, From_date, TO_date, Full_day, Half_day, Off_day, Full_salary, Half_salary, Advance_salary, Full_day_Total, Half_day_total, Advance_total, Grand_total, Slip_day)
                    VALUES 
                    (@user_id, @From_date, @TO_date, @Full_day, @Half_day, @Off_day, @Full_salary, @Half_salary, @Advance_salary, @Full_day_Total, @Half_day_total, @Advance_total, @Grand_total, @Slip_day)";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@user_id", userId);
                            cmd.Parameters.AddWithValue("@From_date", fromDat);
                            cmd.Parameters.AddWithValue("@TO_date", toDat);
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
                            cmd.Parameters.AddWithValue("@Slip_day", DateTime.Now.Date);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            Response.Write("<script>alert('Salary slip saved successfully.');</script>");
        }



        protected void CalculateSalary(object sender, EventArgs e)
        {
            TextBox salaryBox = sender as TextBox;
            RepeaterItem item = salaryBox.NamingContainer as RepeaterItem;

            if (item != null)
            {
                // Access controls in the current RepeaterItem
                Label lblFullDayCount = item.FindControl("fullDayCount") as Label;
                TextBox txtFullDaySalary = item.FindControl("fullDaySalary") as TextBox;
                Label lblFullDayTotal = item.FindControl("fullDayTotal") as Label;

                Label lblHalfDayCount = item.FindControl("halfDayCount") as Label;
                TextBox txtHalfDaySalary = item.FindControl("halfDaySalary") as TextBox;
                Label lblHalfDayTotal = item.FindControl("halfDayTotal") as Label;

                TextBox txtAdvanceAmount = item.FindControl("advanceAmount") as TextBox;
                Label lblAdvanceTotal = item.FindControl("advanceTotal") as Label;

                Label lblGrandTotal = item.FindControl("grandTotal") as Label;

                // Perform calculations
                decimal fullDayCount = Convert.ToDecimal(lblFullDayCount.Text);
                decimal fullDaySalary = Convert.ToDecimal(txtFullDaySalary.Text);
                decimal fullDayTotal = fullDayCount * fullDaySalary;

                decimal halfDayCount = Convert.ToDecimal(lblHalfDayCount.Text);
                decimal halfDaySalary = Convert.ToDecimal(txtHalfDaySalary.Text);
                decimal halfDayTotal = halfDayCount * halfDaySalary;

                decimal advanceAmount = Convert.ToDecimal(txtAdvanceAmount.Text);
                decimal advanceTotal = -advanceAmount;

                decimal grandTotal = fullDayTotal + halfDayTotal + advanceTotal;

                // Update UI
                lblFullDayTotal.Text = fullDayTotal.ToString("F2");
                lblHalfDayTotal.Text = halfDayTotal.ToString("F2");
                lblAdvanceTotal.Text = advanceTotal.ToString("F2");
                lblGrandTotal.Text = grandTotal.ToString("F2");
            }
        }



        [WebMethod]
        public static object CalculateSalary(int fullDayCount, decimal fullDaySalary, int halfDayCount, decimal halfDaySalary, decimal advanceAmount)
        {
            // Perform calculations
            decimal fullDayTotal = fullDayCount * fullDaySalary;
            decimal halfDayTotal = halfDayCount * halfDaySalary;
            decimal advanceTotal = -advanceAmount;
            decimal grandTotal = fullDayTotal + halfDayTotal + advanceTotal;

            // Return results as an object
            return new
            {
                FullDayTotal = fullDayTotal.ToString("F2"),
                HalfDayTotal = halfDayTotal.ToString("F2"),
                AdvanceTotal = advanceTotal.ToString("F2"),
                GrandTotal = grandTotal.ToString("F2")
            };
        }


    }
}