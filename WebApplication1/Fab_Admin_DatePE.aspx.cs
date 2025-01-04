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
                    SUM(fp.Pro_price) AS TotalAmount,
                    0 AS TotalExpense
                FROM 
                    Fab_profit fp
                WHERE 
                    fp.date BETWEEN @fromDate AND @toDate

                UNION ALL

                
                SELECT 
                    'Expense' AS Category,
                    0 AS TotalAmount,
                    SUM(ISNULL(fe.Exp_price, 0) + ISNULL(fe.user_advance, 0)) AS TotalExpense
                FROM 
                    Fab_Expanse fe
                WHERE 
                    fe.date BETWEEN @fromDate AND @toDate

                UNION ALL

                
                SELECT 
                    'Salary' AS Category,
                    0 AS TotalAmount,
                    SUM(ISNULL(ss.Grand_Total, 0)) AS TotalExpense
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
                MonthlySummary";

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