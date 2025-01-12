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
    public partial class Transport : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                TransportSlip.Text = "";
            }

            if (!IsPostBack)
            {
                // Get the first and last dates of the current month
                DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                // Set the default dates in the textboxes
                fromDate.Text = firstDayOfMonth.ToString("yyyy-MM-dd"); // Ensure the format matches the expected input
                toDate.Text = lastDayOfMonth.ToString("yyyy-MM-dd");

                // Trigger the search for the current month's data
                fromDateSpan.InnerText = firstDayOfMonth.ToString("dd-MMM-yyyy");
                toDateSpan.InnerText = lastDayOfMonth.ToString("dd-MMM-yyyy");
                GenerateTransportSlip(firstDayOfMonth, lastDayOfMonth);
            }
        }

        protected void btnSearchDate_Click(object sender, EventArgs e)
        {

            string fromDateText = fromDate.Text;
            string toDateText = toDate.Text;

            DateTime fromDateValue, toDateValue;


            if (DateTime.TryParse(fromDateText, out fromDateValue) && DateTime.TryParse(toDateText, out toDateValue))
            {

                fromDateSpan.InnerText = fromDateValue.ToString("dd-MMM-yyyy");
                toDateSpan.InnerText = toDateValue.ToString("dd-MMM-yyyy");


                GenerateTransportSlip(fromDateValue, toDateValue);
            }
            else
            {

                TransportSlip.Text = "<div class='alert alert-danger'>Invalid dates provided. Please try again.</div>";
            }
        }


        protected void GenerateTransportSlip(DateTime fromDate, DateTime toDate)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                string query = "SELECT date, Exp_name, Exp_price FROM Fab_Expanse WHERE User_id = 20203 AND date >= @FromDate AND date <= @ToDate order by date Asc";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                TransportSlip.Text = "<table class='salary-slip-table table table-bordered'>" +
                                     "<thead>" +
                                     "<tr>" +
                                     "<th>Date</th>" +
                                     "<th>Place</th>" +
                                     "<th>Payment</th>" +
                                     "</tr>" +
                                     "</thead>" +
                                     "<tbody>";

                decimal total = 0;


                while (reader.Read())
                {
                    DateTime date = Convert.ToDateTime(reader["date"]);
                    string place = reader["Exp_name"].ToString();
                    decimal payment = Convert.ToDecimal(reader["Exp_price"]);

                    TransportSlip.Text += "<tr>" +
                                          "<td>" + date.ToString("dd-MMM-yyyy") + "</td>" +
                                          "<td>" + place + "</td>" +
                                          "<td>" + payment.ToString("N0") + "</td>" +
                                          "</tr>";

                    total += payment;
                }


                TransportSlip.Text += "<tr>" +
                                      "<td colspan='2'><strong>TOTAL</strong></td>" +
                                      "<td>" + total.ToString("N0") + "</td>" +
                                      "</tr>";

                TransportSlip.Text += "</tbody></table>";


                reader.Close();
            }
        }

    }
}