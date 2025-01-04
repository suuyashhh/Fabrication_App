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
    public partial class Fab_Admin_MonthlyPE : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ShowMonthlyData();
            }
        }

        protected void ShowMonthlyData()
        {
            
            string query = @"
   WITH MonthlySummary AS (
    
    SELECT 
        DATENAME(MONTH, fp.date) AS MonthName,
        YEAR(fp.date) AS YearValue,
        MONTH(fp.date) AS MonthNumber,
        SUM(fp.Pro_price) AS TotalBill,
        0 AS TotalExpense
    FROM 
        Fab_profit fp
    GROUP BY 
        DATENAME(MONTH, fp.date),
        YEAR(fp.date),
        MONTH(fp.date)
    
    UNION ALL

    
    SELECT 
        DATENAME(MONTH, fe.date) AS MonthName,
        YEAR(fe.date) AS YearValue,
        MONTH(fe.date) AS MonthNumber,
        0 AS TotalBill,
        SUM(ISNULL(fe.Exp_price, 0) + ISNULL(fe.user_advance, 0)) AS TotalExpense
    FROM 
        Fab_Expanse fe
    GROUP BY 
        DATENAME(MONTH, fe.date),
        YEAR(fe.date),
        MONTH(fe.date)
    
    UNION ALL

    
    SELECT 
        DATENAME(MONTH, ss.Slip_Day) AS MonthName,
        YEAR(ss.Slip_Day) AS YearValue,
        MONTH(ss.Slip_Day) AS MonthNumber,
        0 AS TotalBill,
        SUM(ISNULL(ss.Grand_Total, 0)) AS TotalExpense
    FROM 
        Salary_Slip ss
    GROUP BY 
        DATENAME(MONTH, ss.Slip_Day),
        YEAR(ss.Slip_Day),
        MONTH(ss.Slip_Day)
)

SELECT 
    MonthName,
    YearValue,
    SUM(TotalBill) AS TotalBill,
    SUM(TotalExpense) AS TotalExpense,
    (SUM(TotalBill) - SUM(TotalExpense)) AS Profit
FROM 
    MonthlySummary
GROUP BY 
    MonthName, YearValue, MonthNumber
ORDER BY 
    YearValue DESC, MonthNumber DESC";


            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        string monthName = reader["MonthName"].ToString();
                        int yearValue = Convert.ToInt32(reader["YearValue"]);
                        decimal totalBill = reader["TotalBill"] != DBNull.Value ? Convert.ToDecimal(reader["TotalBill"]) : 0;
                        decimal totalExpense = reader["TotalExpense"] != DBNull.Value ? Convert.ToDecimal(reader["TotalExpense"]) : 0;
                        decimal profit = totalBill - totalExpense;

                        
                        string profitColor = profit < 0 ? "red" : "green";

                        
                        MonthPE.Text += $@"
                    <div class='content'>
                        <div class='month-box'>
                            <h5>{monthName} {yearValue}</h5>
                            <div class='profit-expense'>
                                <p class='profit' style='color:{profitColor};margin-bottom:1rem;'>Profit : ₹ {profit:N0}</p>
                                <p class='bill' style='color:green;margin:0px !important'>Bill : ₹ {totalBill:N0}</p>
                                <p class='expense' style='color:red;'>Expense : ₹ {totalExpense:N0}</p>
                            </div>
                        </div>
                    </div>";
                    }
                }
                else
                {
                    MonthPE.Text = "<div class='alert alert-warning'>No data available for the selected period.</div>";
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MonthPE.Text = $"<div class='alert alert-danger'>An error occurred: {ex.Message}</div>";
            }
            finally
            {
                con.Close();
            }
        }

    }
}