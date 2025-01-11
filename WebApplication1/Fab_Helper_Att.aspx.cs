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
            MarkOffDaysForMissingAttendance();
            if (Session["HelperId"] == null)
            {
                Response.Redirect("Fab_Helper_Login.aspx?type=Fab_Helper_Att");
            }

            if (!IsPostBack)
            {
                lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                lblDay.Text = DateTime.Now.ToString("dddd");
            }

            if (!IsPostBack) 
            {
                string userDay = string.Empty;
                string helperName = Session["HelperName"] as string; 

                if (!string.IsNullOrEmpty(helperName))
                {

                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString))
                    {
                        string query = "Select User_day from Fab_helper_Att Where Cast(date AS DATE) = @dt AND User_name = @UserName";
                        using (SqlCommand cmdcheck = new SqlCommand(query, con))
                        {
                            cmdcheck.Parameters.AddWithValue("@dt", DateTime.Now.Date);
                            cmdcheck.Parameters.AddWithValue("@UserName", helperName);

                            try
                            {
                                con.Open();
                                using (SqlDataReader reader = cmdcheck.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        reader.Read();
                                        userDay = reader["User_day"].ToString();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                
                                System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                            }
                            finally
                            {
                                con.Close();
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(userDay))
                    {
                        
                        ClientScript.RegisterStartupScript(
                            this.GetType(),
                            "SweetAlert",
                            $"swal('You have already selected: {userDay}', '', 'warning');",
                            true
                        );
                    }
                }
            }

        }

        protected void btnFullDay_Click(object sender, EventArgs e)
        {
            con.Close();

            SqlCommand cmdcheck = new SqlCommand("Select * from Fab_helper_Att Where Cast(date AS DATE) = @dt AND User_name = @UserName",con);
            cmdcheck.Parameters.AddWithValue("@dt",DateTime.Now.Date);
            cmdcheck.Parameters.AddWithValue("UserName", Session["HelperName"]);
            con.Open();
            SqlDataReader reader = cmdcheck.ExecuteReader();

            if (reader.HasRows)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('You have already selected:','','warning');", true);

            }
            else { 

            con.Close();
            SqlCommand cmd = new SqlCommand("insert into Fab_Helper_Att (User_id,User_name,User_day,date) values (@UserId,@UserName,@userDay,@dt)", con);
            cmd.Parameters.AddWithValue("@UserId", Session["HelperId"]);
            cmd.Parameters.AddWithValue("@UserName", Session["HelperName"]);
            cmd.Parameters.AddWithValue("@userDay", "FULL DAY");
            cmd.Parameters.AddWithValue("@dt", DateTime.Now);

            con.Open();
            cmd.ExecuteNonQuery();
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('You have selected: FULL DAY','','success');", true);
            }
        }

        protected void btnHalfDay_Click(object sender, EventArgs e)
        {
            con.Close();

            SqlCommand cmdcheck = new SqlCommand("Select * from Fab_helper_Att Where Cast(date AS DATE) = @dt AND User_name = @UserName", con);
            cmdcheck.Parameters.AddWithValue("@dt", DateTime.Now.Date);
            cmdcheck.Parameters.AddWithValue("UserName", Session["HelperName"]);
            con.Open();
            SqlDataReader reader = cmdcheck.ExecuteReader();

            if (reader.HasRows)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('You have already selected:','','warning');", true);

            }
            else
            {
                con.Close();

                SqlCommand cmd = new SqlCommand("insert into Fab_Helper_Att (User_id,User_name,User_day,date) values (@UserId,@UserName,@userDay,@dt)", con);
                cmd.Parameters.AddWithValue("@UserId", Session["HelperId"]);
                cmd.Parameters.AddWithValue("@UserName", Session["HelperName"]);
                cmd.Parameters.AddWithValue("@userDay", "HALF DAY");
                cmd.Parameters.AddWithValue("@dt", DateTime.Now);

                con.Open();
                cmd.ExecuteNonQuery();
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('You have selected: HALF DAY','','success');", true);
            }
        }

        protected void btnOffDay_Click(object sender, EventArgs e)
        {
            con.Close();

            SqlCommand cmdcheck = new SqlCommand("Select * from Fab_helper_Att Where Cast(date AS DATE) = @dt AND User_name = @UserName", con);
            cmdcheck.Parameters.AddWithValue("@dt", DateTime.Now.Date);
            cmdcheck.Parameters.AddWithValue("UserName", Session["HelperName"]);
            con.Open();
            SqlDataReader reader = cmdcheck.ExecuteReader();

            if (reader.HasRows)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('You have already selected:','','warning');", true);

            }
            else
            {
                con.Close();

                SqlCommand cmd = new SqlCommand("insert into Fab_Helper_Att (User_id,User_name,User_day,date) values (@UserId,@UserName,@userDay,@dt)", con);
                cmd.Parameters.AddWithValue("@UserId", Session["HelperId"]);
                cmd.Parameters.AddWithValue("@UserName", Session["HelperName"]);
                cmd.Parameters.AddWithValue("@userDay", "OFF DAY");
                cmd.Parameters.AddWithValue("@dt", DateTime.Now);

                con.Open();
                cmd.ExecuteNonQuery();
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('You have selected: OFF DAY','','success');", true);
            }            
        }

        protected void MarkOffDaysForMissingAttendance()
        {
            // Ensure logic only runs after 4:15 PM
            if (DateTime.Now.TimeOfDay < new TimeSpan(16, 38, 0))
            {
                return;  // Exit if the current time is before 4:15 PM
            }

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString))
            {
                try
                {
                    con.Open();

                    // Query to find users who haven't marked attendance today
                    string query = @"
                SELECT u.User_id, u.User_name
                FROM Fab_Users u
                LEFT JOIN Fab_Helper_Att a ON u.User_id = a.User_id AND CAST(a.date AS DATE) = @currentDate
                WHERE a.User_id IS NULL";  // Users who haven't marked attendance today

                    SqlCommand cmdCheck = new SqlCommand(query, con);
                    cmdCheck.Parameters.AddWithValue("@currentDate", DateTime.Now.Date);

                    List<(int UserId, string UserName)> missingUsers = new List<(int, string)>();

                    using (SqlDataReader reader = cmdCheck.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int userId = Convert.ToInt32(reader["User_id"]);
                            string userName = reader["User_name"].ToString();
                            missingUsers.Add((userId, userName)); // Collect users who haven't marked attendance
                        }
                    }

                    // Step 2: Insert "OFF DAY" for each missing user
                    foreach (var user in missingUsers)
                    {
                        SqlCommand cmdInsert = new SqlCommand(@"
                    INSERT INTO Fab_Helper_Att (User_id, User_name, User_day, date)
                    VALUES (@UserId, @UserName, @UserDay, @Date)", con);

                        cmdInsert.Parameters.AddWithValue("@UserId", user.UserId);
                        cmdInsert.Parameters.AddWithValue("@UserName", user.UserName);
                        cmdInsert.Parameters.AddWithValue("@UserDay", "OFF DAY");
                        cmdInsert.Parameters.AddWithValue("@Date", DateTime.Now.Date);

                        cmdInsert.ExecuteNonQuery(); // Insert the "OFF DAY" record
                    }

                    // Optional: Notify via UI (SweetAlert)
                    this.ClientScript.RegisterStartupScript(
                        this.GetType(),
                        "SweetAlert",
                        $"swal('Attendance updated for {missingUsers.Count} users as OFF DAY', '', 'success');",
                        true
                    );

                    // Debug log for testing
                    System.Diagnostics.Debug.WriteLine("Missing Users Count: " + missingUsers.Count);
                }
                catch (Exception ex)
                {
                    // Log any errors
                    System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    con.Close(); // Ensure the connection is always closed
                }
            }
        }




    }
}