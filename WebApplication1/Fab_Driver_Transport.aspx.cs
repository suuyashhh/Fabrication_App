using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace WebApplication1
{
    public partial class Fab_Driver_Transport : Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminId"] == null)
            {
                Response.Redirect("Fab_Admin_Login.aspx?type=Fab_Driver_Transport");
            }

            if (!IsPostBack)
            {
                TransportSlip.Text = ""; 
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
