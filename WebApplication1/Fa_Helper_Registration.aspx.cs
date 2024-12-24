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
    public partial class Registration : System.Web.UI.Page
    {
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected DateTime GetCurrentTime()
        //{
        //    DateTime serverTime = DateTime.Now;
        //    DateTime _localTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(serverTime, TimeZoneInfo.Local.Id, "India Standard Time");
        //    return _localTime;
        //}
        //protected void btnRegister_Click(object sender, EventArgs e)
        //{
        //    con.Close();
        //    SqlCommand cmdcheck = new SqlCommand("select * from Users where contact=@contact", con);
        //    cmdcheck.Parameters.AddWithValue("@contact", UserContact.Text);
        //    con.Open();
        //    SqlDataReader reader = cmdcheck.ExecuteReader();
        //    if (reader.HasRows)
        //    {
        //        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('This contact allrady taken','','warning');", true);

        //    }
        //    else
        //    {
        //        con.Close();

        //        SqlCommand cmd = new SqlCommand("insert into Users values (@name,@pass,@contact,@email,@dt)", con);
        //        cmd.Parameters.AddWithValue("@name", txtname.Text);
        //        cmd.Parameters.AddWithValue("@pass", UserPassword.Text);
        //        cmd.Parameters.AddWithValue("@contact", UserContact.Text);
        //        cmd.Parameters.AddWithValue("@email", txtemail.Text);
        //        cmd.Parameters.AddWithValue("@dt", GetCurrentTime());

        //        con.Open();
        //        cmd.ExecuteNonQuery();

        //        txtname.Text = "";
        //        txtemail.Text = "";
        //        UserContact.Text = "";
        //        UserPassword.Text = "";
        //        txtConPass.Text = "";
        //        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('You are registered successfully..!','','success');", true);

        //    }
        //}
    }
}