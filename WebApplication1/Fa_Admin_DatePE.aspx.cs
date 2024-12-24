using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace WebApplication1
{
    public partial class DatePE : System.Web.UI.Page
    {
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);

        //    protected void Page_Load(object sender, EventArgs e)
        //    {
        //        if (Session["userId"] == null)
        //        {
        //            Response.Redirect("Login.aspx?type=DatePE");
        //        }
        //    }

        protected void btnSearchDatePE_Click(object sender, EventArgs e)
        {
            //DateTime startDate, endDate;


            //if (DateTime.TryParse(fromDate.Text, out startDate) && DateTime.TryParse(toDate.Text, out endDate))
            //{
            //    ShowProfitExpenseForDateRange(startDate, endDate);
            //}
            //else
            //{
            //    DatePEResult.Text = "<div class='alert alert-danger'>Please select valid dates.</div>";
            //}
        }


        //    protected void ShowProfitExpenseForDateRange(DateTime fromDate, DateTime toDate)
        //    {

        //        if (Session["userId"] == null)
        //        {
        //            DatePEResult.Text = "<div class='alert alert-danger'>User is not logged in.</div>";
        //            return;
        //        }


        //        int userId = Convert.ToInt32(Session["userId"]);

        //        string query = @"
        //SELECT SUM(price) AS TotalBill, NULL AS TotalExpense
        //FROM Bill 
        //WHERE user_id = @userId AND date BETWEEN @fromDate AND @toDate

        //UNION ALL

        //SELECT NULL AS TotalBill, SUM(price) AS TotalExpense
        //FROM Expense
        //WHERE user_id = @userId AND date BETWEEN @fromDate AND @toDate;
        //";

        //        SqlCommand cmd = new SqlCommand(query, con);
        //        cmd.Parameters.AddWithValue("@fromDate", fromDate);
        //        cmd.Parameters.AddWithValue("@toDate", toDate);
        //        cmd.Parameters.AddWithValue("@userId", userId);

        //        con.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        decimal totalBill = 0;
        //        decimal totalExpense = 0;


        //        while (reader.Read())
        //        {
        //            if (reader["TotalBill"] != DBNull.Value)
        //            {
        //                totalBill += Convert.ToDecimal(reader["TotalBill"]);
        //            }
        //            if (reader["TotalExpense"] != DBNull.Value)
        //            {
        //                totalExpense += Convert.ToDecimal(reader["TotalExpense"]);
        //            }
        //        }

        //        decimal profit = totalBill - totalExpense;
        //        string profitColor = profit < 0 ? "red" : "green";

        //        DatePEResult.Text = "<div class='content'>" +
        //                  "<div class='month-box'>" +
        //                  "<h5>  " + fromDate.ToString("dd-MMM-yyyy") + " <p style='margin: 0px !important;'>To</p> " + toDate.ToString("dd-MMM-yyyy") + "</h5>" +
        //                  "<div class='profit-expense'>" +
        //                  "<p class='profit' style='color:" + profitColor + ";'>Profit : ₹ " + profit.ToString("N0") + "</p>" +
        //                  "<p class='bill' style='color:green;margin-bottom: 0px !important;'>Bill : ₹ " + totalBill.ToString("N0") + "</p>" +
        //                  "<p class='expense' style='color:red;'>Expense : ₹ " + totalExpense.ToString("N0") + "</p>" +
        //                  "</div></div></div>";


        //        con.Close();
        //    }



    }
}
