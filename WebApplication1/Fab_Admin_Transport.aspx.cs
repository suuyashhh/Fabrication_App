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
    public partial class Fab_Admin_Transport : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitTransport_Click(object sender, EventArgs e)
        {
            con.Close();
            SqlCommand cmd = new SqlCommand("INSERT INTO Fab_Expanse (Exp_name,Exp_price,date,User_id) VALUES (@exname,@rs,@dt,@id)", con);

            cmd.Parameters.AddWithValue("@exname", TrnPlace.Text);
            cmd.Parameters.AddWithValue("@rs", TrnPrice.Text);            
            cmd.Parameters.AddWithValue("@id", 20203);

            DateTime selectedDate;
            if (DateTime.TryParse(TrnDate.Text, out selectedDate))
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
            TrnDate.Text = "";
            TrnPlace.Text = "";
            TrnPrice.Text = "";
            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Record saved successfully','','success');", true);

        }
    }
}