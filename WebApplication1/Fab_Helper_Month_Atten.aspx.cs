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
    public partial class Fab_Helper_Month_Atten : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    BindAttendanceSummary();
            //}
        }


        private void BindAttendanceSummary(DateTime fromDate, DateTime toDate)
        {
            string connString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"
                        WITH AttendanceSummary AS (
                            SELECT 
                                HA.User_id,
                                SUM(CASE WHEN HA.User_day = 'Full Day' THEN 1 ELSE 0 END) AS FullDay_Count,
                                SUM(CASE WHEN HA.User_day = 'Half Day' THEN 1 ELSE 0 END) AS HalfDay_Count,
                                SUM(CASE WHEN HA.User_day = 'Off Day' THEN 1 ELSE 0 END) AS OffDay_Count
                            FROM
                                Fab_Helper_Att HA
                            WHERE 
                                CAST(HA.date AS DATE) BETWEEN @FromDate AND @ToDate
                            GROUP BY 
                                HA.User_id
                        ),
                        ExpenseSummary AS (
                            SELECT 
                                FE.User_id,
                                SUM(FE.User_advance) AS TOTAL_ADVANCE
                            FROM 
                                Fab_Expanse FE
                            WHERE 
                                CAST(FE.date AS DATE) BETWEEN @FromDate AND @ToDate
                            GROUP BY 
                                FE.User_id
                        )
                        SELECT 
                            FU.User_id,
                            FU.User_name,
                            FU.User_salary,
                            COALESCE(ES.TOTAL_ADVANCE, 0) AS TOTAL_ADVANCE,
                            COALESCE(ASUM.FullDay_Count, 0) AS FullDay_Count,
                            COALESCE(ASUM.HalfDay_Count, 0) AS HalfDay_Count,
                            COALESCE(ASUM.OffDay_Count, 0) AS OffDay_Count
                        FROM 
                            Fab_Users FU
                        LEFT JOIN 
                            AttendanceSummary ASUM 
                            ON FU.User_id = ASUM.User_id
                        LEFT JOIN 
                            ExpenseSummary ES 
                            ON FU.User_id = ES.User_id
                        WHERE 
                            FU.User_id = 1
                        ORDER BY 
                            FU.User_id;
                        ";


                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                    cmd.Parameters.AddWithValue("@ToDate", toDate);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    rptAttendanceSummary.DataSource = reader;
                    rptAttendanceSummary.DataBind();

                    conn.Close();
                }
            }
        }

        protected void btnSearchDatePE_Click(object sender, EventArgs e)
        {
            DateTime fromDateValue, toDateValue;

            if (!DateTime.TryParse(fromDate.Text, out fromDateValue) || !DateTime.TryParse(toDate.Text, out toDateValue))
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "swal('Invalid Date Format', '', 'error');", true);
                return;
            }

            if (fromDateValue > toDateValue)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "swal('From Date cannot be later than To Date!', '', 'warning');", true);
                return;
            }


            BindAttendanceSummary(fromDateValue, toDateValue);
        }
    }
}