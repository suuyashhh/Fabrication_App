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
    public partial class OtherFeed : System.Web.UI.Page
    {
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                lblDay.Text = DateTime.Now.ToString("dddd");
            }
            //if (Session["userId"]== null)
            //{
            //    Response.Redirect("Login.aspx?type=OtherFeed");
            //}
        }

        protected void btnSubmitotherFeed_Click(object sender, EventArgs e)
        {
            //con.Close();
            //SqlCommand cmd = new SqlCommand("insert into Expense (user_id,expense_name,feed_name,price,quantity,date) values (@id,@exname,@feed,@rs,@qt,@dt)", con);


            //cmd.Parameters.AddWithValue("@id", Session["userId"]);
            //cmd.Parameters.AddWithValue("@exname", "OtherFeeds");
            //cmd.Parameters.AddWithValue("@feed", otherfeedname.Text);
            //cmd.Parameters.AddWithValue("@rs", otherfeedPrice.Text);
            //cmd.Parameters.AddWithValue("@qt", otherfeedqty.Text);


            //DateTime selectedDate;
            //if (DateTime.TryParse(otherfeedDate.Text, out selectedDate))
            //{
            //    cmd.Parameters.AddWithValue("@dt", selectedDate);
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "swal('Invalid date format!','','warning');", true);
            //    return;
            //}


            //con.Open();
            //cmd.ExecuteNonQuery();

            //otherfeedname.Text = "";
            //otherfeedPrice.Text = "";
            //otherfeedqty.Text = "";
            //otherfeedDate.Text = "";
            //this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Record saved successfully','','success');", true);

        }
    }
}