using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin_Control
{
    public partial class FeedbackAdmin : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {

            }
            else
            {
                Response.Redirect("AdminLogin.aspx?type=access");
            }
            if (!IsPostBack)
            {
                showNotes();
            }
        }
        protected void showNotes()
        {
            try
            {

                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("Select feedback_id,user_name,user_contact,feedback,date from Feedback ", con))
                    {
                      
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            NoteRep.DataSource = dt;
                            NoteRep.DataBind();
                        }
                    }
                }
            }
            catch (Exception es)
            {

            }
        }

        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {

                RepeaterItem a = (sender as LinkButton).Parent as RepeaterItem;

                int b = int.Parse((a.FindControl("DelRep") as Label).Text.ToString());



                con.Close();
                string qry = "delete from Feedback where feedback_id=" + b;
                SqlCommand cmd = new SqlCommand(qry, con);
                con.Open();
                cmd.ExecuteNonQuery();
                showNotes();

                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Item deleted Successfully','','success');", true);

            }
            catch (Exception es)
            {

            }
            finally
            {
                con.Close();
            }
        }
    }
}