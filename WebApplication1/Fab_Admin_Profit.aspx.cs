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
    public partial class Fab_Admin_Profit : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitProfit_Click(object sender, EventArgs e)
        {
            con.Close();
            SqlCommand cmd = new SqlCommand("INSERT INTO Fab_Profit (Pro_name,Pro_price,date) VALUES (@exname,@rs,@dt)", con);

            cmd.Parameters.AddWithValue("@exname", ProfitName.Text);
            cmd.Parameters.AddWithValue("@rs", ProfitProfit.Text);

            DateTime selectedDate;
            if (DateTime.TryParse(ProfitDate.Text, out selectedDate))
            {
                cmd.Parameters.AddWithValue("@dt", selectedDate);
            }
            else
            {
                Response.Write("<script>alert('Invalid date format!');</script>");
                return;
            }

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            ProfitName.Text = "";
            ProfitDate.Text = "";
            ProfitProfit.Text = "";
            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Record saved successfully','','success');", true);

        }
    }
}