using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Fab_Helper_Registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            con.Close();
            SqlCommand cmdcheck = new SqlCommand("select * from Users where contact=@contact", con);
            cmdcheck.Parameters.AddWithValue("@contact", UserContact.Text);
            con.Open();
            SqlDataReader reader = cmdcheck.ExecuteReader();
            if (reader.HasRows)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('This contact allrady taken','','warning');", true);

            }
            else
            {
                con.Close();

                SqlCommand cmd = new SqlCommand("insert into Fab_Users values (@name,@contact,@pass)", con);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@contact", UserContact.Text);
                cmd.Parameters.AddWithValue("@pass", UserPassword.Text);

                con.Open();
                cmd.ExecuteNonQuery();

                txtname.Text = "";
                UserContact.Text = "";
                UserPassword.Text = "";
                txtConPass.Text = "";
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('You are registered successfully..!','','success');", true);

            }
        }
    }
}