using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class MonthlyPE : System.Web.UI.Page
    {
     //   SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
     //   protected void Page_Load(object sender, EventArgs e)
     //   {
     //       if (Session["userId"] == null)
     //       {
     //           Response.Redirect("Login.aspx?type=MonthPe");
     //       }

     //       if (!IsPostBack)
     //       {
     //           menushow();
     //       }
     //   }

     //   protected void menushow()
     //   {
     //       con.Close();

     //       string query = @"
     //   WITH MonthlySummary AS (
     //       SELECT 
     //           DATENAME(MONTH, b.date) AS MonthName,
     //           YEAR(b.date) AS YearValue,
     //           MONTH(b.date) AS MonthNumber,
     //           SUM(b.price) AS TotalBill,
     //           0 AS TotalExpense
     //       FROM 
     //           Bill b
     //       WHERE 
     //           b.user_id = @userId
     //       GROUP BY 
     //           DATENAME(MONTH, b.date), 
     //           YEAR(b.date), 
     //           MONTH(b.date)
            
     //       UNION ALL
            
     //       SELECT 
     //           DATENAME(MONTH, e.date) AS MonthName,
     //           YEAR(e.date) AS YearValue,
     //           MONTH(e.date) AS MonthNumber,
     //           0 AS TotalBill,
     //           SUM(e.price) AS TotalExpense
     //       FROM 
     //           Expense e
     //       WHERE 
     //           e.user_id = @userId
     //       GROUP BY 
     //           DATENAME(MONTH, e.date), 
     //           YEAR(e.date), 
     //           MONTH(e.date)
     //   )
     //   SELECT 
     //       MonthName, 
     //       YearValue,
     //       SUM(TotalBill) AS TotalBill, 
     //       SUM(TotalExpense) AS TotalExpense, 
     //       (SUM(TotalBill) - SUM(TotalExpense)) AS Profit
     //   FROM 
     //       MonthlySummary
     //   GROUP BY 
     //       MonthName, YearValue, MonthNumber
     //   ORDER BY 
     //       YearValue DESC, MonthNumber DESC";

     //       SqlCommand cmd = new SqlCommand(query, con);

     //       cmd.Parameters.AddWithValue("@userId", Session["userId"]);

     //       con.Open();
     //       SqlDataReader reader = cmd.ExecuteReader();

     //       if (reader.HasRows)
     //       {
     //           while (reader.Read())
     //           {
     //               decimal profit = Convert.ToDecimal(reader["Profit"]);
     //               string profitColor = profit < 0 ? "red" : "green";

     //               MonthPE.Text += "<div class='content'>"
     //+ "<div class='month-box'>"
     //+ "<h5>" + reader["MonthName"] + " " + reader["YearValue"] + "</h5>"
     //+ "<div class='profit-expense'>"
     //+ "<p class='profit' style='color:" + profitColor + ";margin-bottom:1rem;'>Profit : ₹  "
     //+ Convert.ToDecimal(reader["Profit"]).ToString("N0") + "</p>"
     //+ "<p class='bill' style='color:green;margin:0px !important'>Bill : ₹  "
     //+ Convert.ToDecimal(reader["TotalBill"]).ToString("N0") + "</p>"
     //+ "<p class='expense' style='color:red;'>Expense : ₹  "
     //+ Convert.ToDecimal(reader["TotalExpense"]).ToString("N0") + "</p>"
     //+ "</div></div></div>";

     //           }
     //       }
     //       else
     //       {
     //           MonthPE.Text = "<div class='alert alert-warning'>No data available for the selected period.</div>";
     //       }

     //       con.Close();
     //   }






    }
}