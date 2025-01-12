using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Fab_Admin_HistoryAll : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminId"] == null)
            {
                Response.Redirect("Fab_Admin_Login.aspx?type=Fab_Admin_HistoryAll");
            }
            if (!IsPostBack)
            {
                LoadHistoryRecords();
            }
        }

        private void LoadHistoryRecords()
        {
            string query = @"
SELECT 
    Exp_id AS record_id,
    User_id,
    CASE 
        WHEN User_id IS NULL THEN 'GoodExpanse'
        WHEN User_id = 20203 THEN 'TransportPlace'
        WHEN User_id BETWEEN 0 AND 1000 THEN 'Advance'
        ELSE 'Other'
    END AS record_type,
    CASE 
        WHEN User_id BETWEEN 0 AND 1000 THEN 
            (SELECT user_name 
             FROM Fab_Users 
             WHERE Fab_Users.user_id = Fab_Expanse.User_id)
        ELSE Exp_name
    END AS record_name,
    CASE
        WHEN User_id BETWEEN 0 AND 1000 THEN User_advance -- Display advance values date-wise
        ELSE Exp_price
    END AS price,
    date AS record_date
FROM 
    Fab_Expanse

UNION ALL

SELECT 
    Slip_id AS record_id,
    User_id,
    'SalarySlip' AS record_type,
    (SELECT user_name 
     FROM Fab_Users 
     WHERE Fab_Users.user_id = Salary_Slip.User_id) AS record_name,
    Grand_Total AS price,
    Slip_Day AS record_date
FROM Salary_Slip

UNION ALL

SELECT 
    Pro_id AS record_id,
    NULL AS User_id,
    'FabProfit' AS record_type,
    Pro_name AS record_name,
    Pro_price AS price,
    date AS record_date
FROM dbo.Fab_Profit

ORDER BY record_date DESC, User_id;
";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                StringBuilder sb = new StringBuilder();

                string currentMonthYear = "";

                while (reader.Read())
                {
                    string recordType = reader["record_type"].ToString();
                    DateTime recordDate = Convert.ToDateTime(reader["record_date"]);
                    decimal price = Convert.ToDecimal(reader["price"]);
                    string recordName = reader["record_name"].ToString();

                    string imagePath = "";

                    switch (recordType)
                    {
                        case "FabProfit":
                            imagePath = "FabImage/Profit.png";
                            break;
                        case "GoodExpanse":
                            imagePath = "FabImage/Expanse.png";
                            break;
                        case "TransportPlace":
                            imagePath = "FabImage/TransportList.png";
                            break;
                        case "Advance":
                            imagePath = "FabImage/AdvanceMoney.png";
                            break;
                        case "SalarySlip":
                            imagePath = "FabImage/AdminCreateSalaySlip.png";
                            break;
                    }

                    string newMonthYear = recordDate.ToString("MMMM yyyy");
                    if (newMonthYear != currentMonthYear)
                    {
                        currentMonthYear = newMonthYear;

                        sb.Append($@"
            <div class='month-year-header'>
                <h3>{currentMonthYear}</h3>
            </div>");
                    }

                    sb.Append($@"
        <div class='card-horizontal'>
            <div class='left-content'>
                <img src='{imagePath}' alt='Logo' />
                <div class='text-content'>
                    <h5>{recordName}</h5>
                    <p>{recordDate:dd-MMM-yyyy}</p>
                </div>
            </div>
            <div class='right-content'>
                <h4>₹ {price:N0}</h4>
            </div>
        </div>");
                }

                litRecords.Text = sb.ToString();
                con.Close();
            }
        }

    }
}