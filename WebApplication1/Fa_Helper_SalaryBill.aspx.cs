using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Feedss : System.Web.UI.Page
    {
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["userId"] == null)
            //{
            //    Response.Redirect("Login.aspx?type=Feeds");
            //}

            //if (!IsPostBack)
            //{
            //    BindFeedDropdown();
            //    //feedDate.Text = GetCurrentTime().ToString("yyyy-MM-dd");
            //    //DateTime dt = GetCurrentTime().Date;
            //}
        }

        //protected DateTime GetCurrentTime()
        //{
        //    DateTime serverTime = DateTime.Now;
        //    DateTime _localTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(serverTime, TimeZoneInfo.Local.Id, "India Standard Time");
        //    return _localTime;
        //}

        //private void BindFeedDropdown()
        //{
        //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("SELECT feed_id, feed_name FROM Feeds WHERE user_id = @userId", con))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Parameters.AddWithValue("@userId", Session["userId"]);
        //            con.Open();
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                ddlfeedname.DataSource = reader;
        //                ddlfeedname.DataTextField = "feed_name";
        //                ddlfeedname.DataValueField = "feed_name";
        //                ddlfeedname.DataBind();
        //            }
        //        }
        //    }

        //    ddlfeedname.Items.Insert(0, new ListItem("--Select Feed--", ""));
        //}

        //protected void btnSubmitFeed_Click(object sender, EventArgs e)
        //{
        //    con.Close();
        //    SqlCommand cmd = new SqlCommand("INSERT INTO Expense (user_id,expense_name,feed_name,price,quantity,date) VALUES (@id,@exname,@feed,@rs,@qt,@dt)", con);

        //    cmd.Parameters.AddWithValue("@id", Session["userId"]);
        //    cmd.Parameters.AddWithValue("@exname", "Feeds");
        //    cmd.Parameters.AddWithValue("@feed", ddlfeedname.Text);
        //    cmd.Parameters.AddWithValue("@rs", feedPrice.Text);
        //    cmd.Parameters.AddWithValue("@qt", feedqty.Text);

        //    DateTime selectedDate;
        //    if (DateTime.TryParse(feedDate.Text, out selectedDate))
        //    {
        //        cmd.Parameters.AddWithValue("@dt", selectedDate);
        //    }
        //    else
        //    {
        //        Response.Write("<script>alert('Invalid date format!');</script>");
        //        return;
        //    }

        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    feedPrice.Text = "";
        //    feedqty.Text = "";
        //    feedDate.Text = "";            
        //    BindFeedDropdown();
        //    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Record saved successfully','','success');", true);
        //}

    }
}