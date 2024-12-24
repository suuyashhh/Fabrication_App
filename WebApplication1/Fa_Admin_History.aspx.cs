using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI;

namespace WebApplication1
{
    public partial class History : System.Web.UI.Page
    {
    //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);

    //    protected void Page_Load(object sender, EventArgs e)
    //    {
    //        if (Session["userId"] == null)
    //        {
    //            Response.Redirect("Login.aspx?type=History");
    //        }
    //        if (!IsPostBack)
    //        {
    //            LoadHistoryRecords();
    //        }
    //    }

    //    private void LoadHistoryRecords()
    //    {
    //        string query = @"
    //    SELECT 
    //        user_id, 
    //        'Bill' AS record_type, 
    //        animal_type, 
    //        NULL AS feed_name, 
    //        NULL AS reason, 
    //        price, 
    //        date AS record_date
    //    FROM Bill
    //    WHERE user_id = @userId
        
    //    UNION ALL
        
    //    SELECT 
    //        user_id, 
    //        expense_name AS record_type, 
    //        NULL AS animal_type, 
    //        feed_name, 
    //        reason, 
    //        price, 
    //        date AS record_date
    //    FROM Expense
    //    WHERE user_id = @userId
        
    //    ORDER BY record_date DESC;
    //";

    //        using (SqlCommand cmd = new SqlCommand(query, con))
    //        {

    //            cmd.Parameters.AddWithValue("@userId", Convert.ToInt32(Session["userId"]));

    //            con.Open();
    //            SqlDataReader reader = cmd.ExecuteReader();
    //            StringBuilder sb = new StringBuilder();


    //            string currentMonthYear = "";

    //            while (reader.Read())
    //            {
    //                string recordType = reader["record_type"].ToString();
    //                DateTime recordDate = Convert.ToDateTime(reader["record_date"]);
    //                decimal price = Convert.ToDecimal(reader["price"]);

    //                string imagePath = "";
    //                string displayType = "";


    //                if (recordType == "Doctor" || recordType == "Medicine")
    //                {
    //                    displayType = reader["reason"].ToString();
    //                    imagePath = "assets/img/" + (recordType == "Doctor" ? "doctor_16802630.png" : "tablet_16443237.png");
    //                }
    //                else if (recordType == "Feeds" || recordType == "OtherFeeds")
    //                {
    //                    displayType = reader["feed_name"].ToString();
    //                    imagePath = recordType == "Feeds" ? "assets/img/seed-bag_12627079.png" : "assets/img/Dryfeed_9137270.png";
    //                }
    //                else if (recordType == "Bill")
    //                {
    //                    displayType = reader["animal_type"].ToString();
    //                    imagePath = "assets/img/bill_1052856.png";
    //                }


    //                string newMonthYear = recordDate.ToString("MMMM yyyy");
    //                if (newMonthYear != currentMonthYear)
    //                {
    //                    currentMonthYear = newMonthYear;


    //                    sb.Append($@"
    //        <div class='month-year-header'>
    //            <h3>{currentMonthYear}</h3>
    //        </div>");
    //                }


    //                sb.Append($@"
    //    <div class='card-horizontal'>
    //        <div class='left-content'>
    //            <img src='{imagePath}' alt='Logo' />
    //            <div class='text-content'>
    //                <h5>{displayType}</h5>
    //                <p>{recordDate:dd-MMM-yyyy}</p>
    //            </div>
    //        </div>
    //        <div class='right-content'>
    //            <h4>₹ {price:N0}</h4>
    //        </div>
    //    </div>");
    //            }

    //            litRecords.Text = sb.ToString();
    //            con.Close();
    //        }
    //    }

    }
}
