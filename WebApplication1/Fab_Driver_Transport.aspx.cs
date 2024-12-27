using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Fab_Driver_Transport : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateTransportSlip();
            }
        }

        protected void GenerateTransportSlip()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT date, Exp_name, Exp_price FROM Fab_Expanse WHERE User_id = 20203";
                SqlCommand cmd = new SqlCommand(query, con);
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

                // Add rows dynamically from the database
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
            }
        }

    }
}