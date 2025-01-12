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
    public partial class Fab_Admin_DatePE : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminId"] == null)
            {
                Response.Redirect("Fab_Admin_Login.aspx?type=Fab_Admin_DatePE");
            }

            if (!IsPostBack)
            {
                // Get the first and last dates of the current month
                DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                // Set the default dates in the textboxes
                fromDate.Text = firstDayOfMonth.ToString("yyyy-MM-dd"); // Ensure the format matches the expected input
                toDate.Text = lastDayOfMonth.ToString("yyyy-MM-dd");

              
                ShowProfitExpenseForDateRange(firstDayOfMonth, lastDayOfMonth);
            }
        }

        protected void btnSearchDatePE_Click(object sender, EventArgs e)
        {
            DateTime startDate, endDate;

            if (DateTime.TryParse(fromDate.Text, out startDate) && DateTime.TryParse(toDate.Text, out endDate))
            {
                ShowProfitExpenseForDateRange(startDate, endDate);
            }
            else
            {
                DatePEResult.Text = "<div class='alert alert-danger'>Please select valid dates.</div>";
            }
        }

        protected void ShowProfitExpenseForDateRange(DateTime fromDate, DateTime toDate)
        {
            string query = @"
          WITH MonthlySummary AS (
    SELECT 
        'Bill' AS Category,
        SUM(CAST(fp.Pro_price AS DECIMAL(18, 2))) AS TotalAmount,
        0 AS TotalExpense
    FROM 
        Fab_profit fp
    WHERE 
        fp.date BETWEEN @fromDate AND @toDate

    UNION ALL

    SELECT 
        'Expense' AS Category,
        0 AS TotalAmount,
        SUM(ISNULL(CAST(fe.Exp_price AS DECIMAL(18, 2)), 0) + ISNULL(CAST(fe.user_advance AS DECIMAL(18, 2)), 0)) AS TotalExpense
    FROM 
        Fab_Expanse fe
    WHERE 
        fe.date BETWEEN @fromDate AND @toDate

    UNION ALL

    SELECT 
        'Salary' AS Category,
        0 AS TotalAmount,
        SUM(ISNULL(CAST(ss.Grand_Total AS DECIMAL(18, 2)), 0)) AS TotalExpense
    FROM 
        Salary_Slip ss
    WHERE 
        ss.Slip_Day BETWEEN @fromDate AND @toDate
)
SELECT 
    SUM(TotalAmount) AS TotalBill,
    SUM(TotalExpense) AS TotalExpense,
    (SUM(TotalAmount) - SUM(TotalExpense)) AS Profit
FROM 
    MonthlySummary;
";

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@fromDate", fromDate);
                cmd.Parameters.AddWithValue("@toDate", toDate);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    decimal totalBill = 0;
                    decimal totalExpense = 0;

                    while (reader.Read())
                    {
                        totalBill = reader["TotalBill"] != DBNull.Value ? Convert.ToDecimal(reader["TotalBill"]) : 0;
                        totalExpense = reader["TotalExpense"] != DBNull.Value ? Convert.ToDecimal(reader["TotalExpense"]) : 0;
                    }

                    decimal profit = totalBill - totalExpense;
                    string profitColor = profit < 0 ? "red" : "green";

                    DatePEResult.Text = $@"
                        <div class='content'>
                            <div class='month-box'>
                                <h5>{fromDate:dd-MMM-yyyy} <p style='margin:0px;'>To</p> {toDate:dd-MMM-yyyy}</h5>
                                <div class='profit-expense'>
                                    <p class='profit' style='color:{profitColor};margin-bottom:1rem;'>Profit : ₹ {profit:N0}</p>
                                    <p class='bill' style='color:green;margin:0px !important'>Bill : ₹ {totalBill:N0}</p>
                                    <p class='expense' style='color:red;'>Expense : ₹ {totalExpense:N0}</p>
                                </div>
                            </div>
                        </div>";
                }
                else
                {
                    DatePEResult.Text = "<div class='alert alert-warning'>No data available for the selected period.</div>";
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                DatePEResult.Text = $"<div class='alert alert-danger'>An error occurred: {ex.Message}</div>";
            }
            finally
            {
                con.Close();
            }
        }

    }
}