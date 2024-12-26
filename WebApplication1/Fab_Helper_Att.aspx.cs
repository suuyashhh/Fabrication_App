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
    public partial class Fab_Helper_Att : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                lblDay.Text = DateTime.Now.ToString("dddd");
            }
        }

        protected void btnFullDay_Click(object sender, EventArgs e)
        {
            con.Close();
            SqlCommand cmd = new SqlCommand("insert into Fab_Helper_Att (User_day,date) values (@userDay,@dt)", con);

            cmd.Parameters.AddWithValue("@userDay", "FULL DAY");
            cmd.Parameters.AddWithValue("@dt", DateTime.Now);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        protected void btnHalfDay_Click(object sender, EventArgs e)
        {
            con.Close();

            SqlCommand cmd = new SqlCommand("insert into Fab_Helper_Att (User_day,date)  Values (@userDay,@dt) ", con);

            cmd.Parameters.AddWithValue("@userDay", "HALF DAY");
            cmd.Parameters.AddWithValue("@dt",DateTime.Now);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        protected void btnOffDay_Click(object sender, EventArgs e)
        {
            con.Close();

            SqlCommand cmd = new SqlCommand("insert into Fab_Helper_Att (User_day,date) values (@userDay,@dt) ", con);

            cmd.Parameters.AddWithValue("@userDay","OFF DAY");
            cmd.Parameters.AddWithValue("@dt", DateTime.Now);

            con.Open();
            cmd.ExecuteNonQuery();

        }
    }
}