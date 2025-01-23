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
    public partial class Fab_Admin_Expanse1 : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminId"] == null)
            {
                Response.Redirect("Fab_Admin_Login.aspx?type=Fab_Admin_Expanse");
            }

            SetCurrentDate();

        }

        protected void SetCurrentDate()
        {

            DateTime todayDate = GetCurrentDate();
            SelectDate.Text = todayDate.ToString("yyyy-MM-dd");
        }


        protected DateTime GetCurrentDate()
        {
            DateTime serverTime = DateTime.Now;
            DateTime localTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(serverTime, TimeZoneInfo.Local.Id, "India Standard Time");
            return localTime.Date;
        }

        protected void btnSubmitAExpanse_Click(object sender, EventArgs e)
        {
            con.Close();
            SqlCommand cmd = new SqlCommand("INSERT INTO Fab_Expanse (Exp_name,Exp_price,date) VALUES (@exname,@rs,@dt)", con);

            cmd.Parameters.AddWithValue("@exname", Ename.Text);
            cmd.Parameters.AddWithValue("@rs", Eprice.Text);

            DateTime selectedDate;
            if (DateTime.TryParse(SelectDate.Text, out selectedDate))
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
            Ename.Text = "";
            Eprice.Text = "";
            SelectDate.Text = "";
            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Record saved successfully','','success');", true);
        }
    }
}