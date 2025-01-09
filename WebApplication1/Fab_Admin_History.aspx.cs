using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Remoting.Channels;

namespace WebApplication1
{
    public partial class Fab_Admin_History : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminId"] == null)
            {
                Response.Redirect("Fab_Admin_Login.aspx?type=Fab_Admin_History");
            }
            if (Request.QueryString["id"] != null)
            {
                SalaryHistory();
                HistoryAttendanceSummary.DataBind();
                UserName();
            }
        }

        protected void UserName()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);

            conn.Close();
            SqlCommand cmd = new SqlCommand("Select SS.*,FU.User_name from Salary_Slip SS Left join Fab_Users FU on SS.USer_id = FU.User_id where Slip_id=@id", conn);
            cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);


            try
            {
                
                conn.Open();

                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) 
                    {
                        object userName = reader["User_name"]; 
                        if (userName != DBNull.Value)
                        {
                            lblName.Text = userName.ToString(); 
                        }
                        else
                        {
                            lblName.Text = "User name not available."; 
                        }
                    }
                    else
                    {
                        lblName.Text = "Record not found."; 
                    }
                }
            }
            catch (Exception ex)
            {
               
                lblName.Text = "Error: " + ex.Message;
            }
            finally
            {
                
                conn.Close();
            }

        }
        protected void SalaryHistory()
        {
            try
            {
                using (conn)
                {
                    using (SqlCommand cmd = new SqlCommand("select * from Salary_Slip where Slip_id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", Request.QueryString[0]);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            
                            HistoryAttendanceSummary.DataSource = dt;
                            HistoryAttendanceSummary.DataBind();

                            
                            if (dt.Rows.Count > 0)
                            {
                                DataRow row = dt.Rows[0];
                                fromDateSpan.InnerText = Convert.ToDateTime(row["From_Date"]).ToString("dd-MMM-yyyy");
                                toDateSpan.InnerText = Convert.ToDateTime(row["To_Date"]).ToString("dd-MMM-yyyy");
                                slipDaySpan.InnerText = Convert.ToDateTime(row["Slip_Day"]).ToString("dd-MMM-yyyy");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void RepeterDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                RepeaterItem item = (RepeaterItem)btn.NamingContainer;
                Label lblSlipId = (Label)item.FindControl("AShistory");

                if (lblSlipId != null)
                {
                    int slipId = int.Parse(lblSlipId.Text);

                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM Salary_Slip WHERE Slip_id = @SlipId", conn))
                        {
                            cmd.Parameters.AddWithValue("@SlipId", slipId);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }

                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Item deleted Successfully','','success');", true);

                    Response.Redirect("Fab_Admin_SalaryHistory.aspx");
                }
                else
                {
                    throw new Exception("Slip ID label not found.");
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
            }
        }



    }
}