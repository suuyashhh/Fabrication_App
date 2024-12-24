using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SpecificRecords : System.Web.UI.Page
    {
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["userId"] == null)
            //{
            //    Response.Redirect("Login.aspx?type=SpecialRecords");
            //}

            if (!IsPostBack)
            {
                gridBill.Visible = false;
                GridFeedOtherFeed.Visible = false;
                GridDocMedi.Visible = false;
                lblGetTotalBill.Visible = false;
                lblGetTotalFeedOtherFeed.Visible = false;
                lblGetTotalDocMedi.Visible = false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //DateTime fromDate = DateTime.MinValue;
            //DateTime toDate = DateTime.MaxValue;

            //if (!string.IsNullOrEmpty(txtFromDate.Text))
            //{
            //    fromDate = Convert.ToDateTime(txtFromDate.Text);
            //}

            //if (!string.IsNullOrEmpty(txtToDate.Text))
            //{
            //    toDate = Convert.ToDateTime(txtToDate.Text);
            //}

            //string selectedValue = ddlRecordType.SelectedValue;

            //if (selectedValue == "bill")
            //{
            //    DataSet ds = gvBill("Bill", fromDate, toDate);
            //    gridBill.DataSource = ds;
            //    gridBill.DataBind();
            //    gridBill.Visible = true;
            //    lblGetTotalBill.Visible = true;
            //    lblGetTotalFeedOtherFeed.Visible = false;
            //    lblGetTotalDocMedi.Visible = false;
            //    GridFeedOtherFeed.Visible = false;
            //    GridDocMedi.Visible = false;
            //    gridAllRecords.Visible = false;

            //    lblGetTotalBill.Text = string.Format("Total Bill: ₹ {0:N0}", GetTotalPrice(ds));
            //}
            //else if (selectedValue == "Feeds" || selectedValue == "OtherFeeds")
            //{
            //    DataSet ds = gvFeedOtherFeed(selectedValue, fromDate, toDate);
            //    GridFeedOtherFeed.DataSource = ds;
            //    GridFeedOtherFeed.DataBind();
            //    gridBill.Visible = false;
            //    GridFeedOtherFeed.Visible = true;
            //    lblGetTotalBill.Visible = false;
            //    lblGetTotalFeedOtherFeed.Visible = true;
            //    lblGetTotalDocMedi.Visible = false;
            //    GridDocMedi.Visible = false;
            //    gridAllRecords.Visible = false;

            //    lblGetTotalFeedOtherFeed.Text = string.Format("Total Feed/Other Feed: ₹ {0:N0}", GetTotalPrice(ds));
            //}
            //else if (selectedValue == "doctor" || selectedValue == "medicine")
            //{
            //    DataSet ds = gvDocMedi(selectedValue, fromDate, toDate);
            //    GridDocMedi.DataSource = ds;
            //    GridDocMedi.DataBind();
            //    GridDocMedi.Visible = true;
            //    lblGetTotalBill.Visible = false;
            //    lblGetTotalFeedOtherFeed.Visible = false;
            //    lblGetTotalDocMedi.Visible = true;
            //    gridBill.Visible = false;
            //    GridFeedOtherFeed.Visible = false;
            //    gridAllRecords.Visible = false;

            //    lblGetTotalDocMedi.Text = string.Format("Total Doctor/Medicine: ₹ {0:N0}", GetTotalPrice(ds));

            //}
            //else if (selectedValue == "all")
            //{
            //    DataTable allRecords = gvAllRecords(fromDate, toDate);

            //    // Bind the data to the GridView
            //    gridAllRecords.DataSource = allRecords;
            //    gridAllRecords.DataBind();

            //    gridBill.Visible = false;
            //    lblGetTotalBill.Visible = false;
            //    lblGetTotalFeedOtherFeed.Visible = false;
            //    lblGetTotalDocMedi.Visible = false;
            //    GridFeedOtherFeed.Visible = false;
            //    GridDocMedi.Visible = false;
            //    gridAllRecords.Visible = true;
            //}
            //else
            //{
            //    gridBill.DataSource = null;
            //    gridBill.DataBind();
            //    GridFeedOtherFeed.DataSource = null;
            //    GridFeedOtherFeed.DataBind();
            //    GridDocMedi.DataSource = null;
            //    GridDocMedi.DataBind();
            //    lblGetTotalBill.Visible = false;
            //    lblGetTotalFeedOtherFeed.Visible = false;
            //    lblGetTotalDocMedi.Visible = false;
            //}
        }


        //protected decimal GetTotalPrice(DataSet ds)
        //{
        //    decimal total = 0;

        //    if (ds != null && ds.Tables.Count > 0)
        //    {
        //        foreach (DataRow row in ds.Tables[0].Rows)
        //        {
        //            if (row["price"] != DBNull.Value)
        //            {
        //                total += Convert.ToDecimal(row["price"]);
        //            }
        //        }
        //    }

        //    return total;
        //}


        //protected DataSet gvBill(string recordType, DateTime fromDate, DateTime toDate)
        //{
        //    SqlCommand sql = new SqlCommand
        //    {
        //        Connection = con,
        //        CommandText = @"SELECT * FROM " + recordType + @" WHERE user_id = @userId AND [date] BETWEEN @FromDate AND @ToDate ORDER BY [date] ASC"
        //    };
        //    sql.Parameters.AddWithValue("@userId", Session["userId"]);
        //    sql.Parameters.AddWithValue("@FromDate", fromDate);
        //    sql.Parameters.AddWithValue("@ToDate", toDate);

        //    con.Open();
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter adapter = new SqlDataAdapter(sql);
        //    adapter.Fill(ds);
        //    con.Close();

        //    return ds;
        //}

        //protected DataSet gvFeedOtherFeed(string recordType, DateTime fromDate, DateTime toDate)
        //{
        //    string query = @"SELECT expense_id, feed_name, quantity, price, [date] 
        //      FROM Expense 
        //      WHERE user_id = @userId AND expense_name = @ExpenseName 
        //      AND [date] BETWEEN @FromDate AND @ToDate
        //      ORDER BY [date] ASC";

        //    using (SqlCommand sql = new SqlCommand(query, con))
        //    {
        //        sql.Parameters.AddWithValue("@userId", Session["userId"]);
        //        sql.Parameters.AddWithValue("@ExpenseName", recordType);
        //        sql.Parameters.AddWithValue("@FromDate", fromDate);
        //        sql.Parameters.AddWithValue("@ToDate", toDate);

        //        SqlDataAdapter adapter = new SqlDataAdapter(sql);
        //        DataSet ds = new DataSet();

        //        con.Open();
        //        adapter.Fill(ds);
        //        con.Close();

        //        return ds;
        //    }
        //}

        //protected DataSet gvDocMedi(string recordType, DateTime fromDate, DateTime toDate)
        //{
        //    string query = @"SELECT expense_id, animal_name, reason, price, [date]
        //      FROM Expense 
        //      WHERE user_id = @userId AND expense_name = @ExpenseName 
        //      AND [date] BETWEEN @FromDate AND @ToDate
        //      ORDER BY [date] ASC";

        //    using (SqlCommand sql = new SqlCommand(query, con))
        //    {
        //        sql.Parameters.AddWithValue("@userId", Session["userId"]);
        //        sql.Parameters.AddWithValue("@ExpenseName", recordType);
        //        sql.Parameters.AddWithValue("@FromDate", fromDate);
        //        sql.Parameters.AddWithValue("@ToDate", toDate);

        //        SqlDataAdapter adapter = new SqlDataAdapter(sql);
        //        DataSet ds = new DataSet();

        //        con.Open();
        //        adapter.Fill(ds);
        //        con.Close();

        //        return ds;
        //    }
        //}

        //private DataTable gvAllRecords(DateTime fromDate, DateTime toDate)
        //{
        //    DataTable dt = new DataTable();


        //    string connstr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;


        //    string query = @"
        //                SELECT date, 'Bill' AS record_name, price
        //                FROM Bill 
        //                WHERE user_id = @userId AND date BETWEEN @fromDate AND @toDate
        //                UNION ALL
        //                SELECT date, expense_name AS record_name, price
        //                FROM Expense
        //                WHERE user_id = @userId AND date BETWEEN @fromDate AND @toDate
        //                ORDER BY date ASC";

        //    using (SqlConnection con = new SqlConnection(connstr))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(query, con))
        //        {

        //            cmd.Parameters.AddWithValue("@userId", Session["userId"]);
        //            cmd.Parameters.AddWithValue("@fromDate", fromDate);
        //            cmd.Parameters.AddWithValue("@toDate", toDate);

        //            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //            {
        //                sda.Fill(dt);
        //            }
        //        }
        //    }

        //    return dt;
        //}


        //protected void gridBill_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    gridBill.EditIndex = e.NewEditIndex;
        //    RebindGridBill();
        //}

        //protected void gridBill_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    GridViewRow row = gridBill.Rows[e.RowIndex];
        //    string billId = gridBill.DataKeys[e.RowIndex].Value.ToString();
        //    string animalType = ((TextBox)row.FindControl("txtAT")).Text;
        //    string price = ((TextBox)row.FindControl("txtprice")).Text;

        //    SqlCommand cmd = new SqlCommand("UPDATE Bill SET animal_type = @animalType, price = @price WHERE bill_id = @billId", con);
        //    cmd.Parameters.AddWithValue("@animalType", animalType);
        //    cmd.Parameters.AddWithValue("@price", price);
        //    cmd.Parameters.AddWithValue("@billId", billId);

        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();

        //    gridBill.EditIndex = -1;
        //    RebindGridBill();
        //}

        //protected void gridBill_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    gridBill.EditIndex = -1;
        //    RebindGridBill();
        //}

        //protected void gridBill_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    string billId = gridBill.DataKeys[e.RowIndex].Value.ToString();
        //    SqlCommand cmd = new SqlCommand("DELETE FROM Bill WHERE bill_id = @billId", con);
        //    cmd.Parameters.AddWithValue("@billId", billId);

        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();

        //    RebindGridBill();
        //}

        //protected void GridFeedOtherFeed_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    GridFeedOtherFeed.EditIndex = e.NewEditIndex;
        //    RebindGridFeedOtherFeed();
        //}

        //protected void GridFeedOtherFeed_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    GridViewRow row = GridFeedOtherFeed.Rows[e.RowIndex];
        //    string expenseId = GridFeedOtherFeed.DataKeys[e.RowIndex].Value.ToString();
        //    string feedName = ((TextBox)row.FindControl("txtFeedN")).Text;
        //    string quantity = ((TextBox)row.FindControl("txtQty")).Text;
        //    string price = ((TextBox)row.FindControl("txtOFprice")).Text;

        //    SqlCommand cmd = new SqlCommand("UPDATE Expense SET feed_name = @feedName, quantity = @quantity, price = @price WHERE expense_id = @expenseId", con);
        //    cmd.Parameters.AddWithValue("@feedName", feedName);
        //    cmd.Parameters.AddWithValue("@quantity", quantity);
        //    cmd.Parameters.AddWithValue("@price", price);
        //    cmd.Parameters.AddWithValue("@expenseId", expenseId);

        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();

        //    GridFeedOtherFeed.EditIndex = -1;
        //    RebindGridFeedOtherFeed();
        //}

        //protected void GridFeedOtherFeed_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    GridFeedOtherFeed.EditIndex = -1;
        //    RebindGridFeedOtherFeed();
        //}

        //protected void GridFeedOtherFeed_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    string expenseId = GridFeedOtherFeed.DataKeys[e.RowIndex].Value.ToString();
        //    SqlCommand cmd = new SqlCommand("DELETE FROM Expense WHERE expense_id = @expenseId", con);
        //    cmd.Parameters.AddWithValue("@expenseId", expenseId);

        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();

        //    RebindGridFeedOtherFeed();
        //}

        //protected void GridDocMedi_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    GridDocMedi.EditIndex = e.NewEditIndex;
        //    RebindGridDocMedi();
        //}

        //protected void GridDocMedi_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    GridViewRow row = GridDocMedi.Rows[e.RowIndex];
        //    string expenseId = GridDocMedi.DataKeys[e.RowIndex].Value.ToString();
        //    string animalName = ((TextBox)row.FindControl("txtAnimalN")).Text;
        //    string reason = ((TextBox)row.FindControl("txtRsn")).Text;
        //    string price = ((TextBox)row.FindControl("txtDMprice")).Text;

        //    SqlCommand cmd = new SqlCommand("UPDATE Expense SET animal_name = @animalName, reason = @reason, price = @price WHERE expense_id = @expenseId", con);
        //    cmd.Parameters.AddWithValue("@animalName", animalName);
        //    cmd.Parameters.AddWithValue("@reason", reason);
        //    cmd.Parameters.AddWithValue("@price", price);
        //    cmd.Parameters.AddWithValue("@expenseId", expenseId);

        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();

        //    GridDocMedi.EditIndex = -1;
        //    RebindGridDocMedi();
        //}

        //protected void GridDocMedi_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    GridDocMedi.EditIndex = -1;
        //    RebindGridDocMedi();
        //}

        //protected void GridDocMedi_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    string expenseId = GridDocMedi.DataKeys[e.RowIndex].Value.ToString();
        //    SqlCommand cmd = new SqlCommand("DELETE FROM Expense WHERE expense_id = @expenseId", con);
        //    cmd.Parameters.AddWithValue("@expenseId", expenseId);

        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();

        //    RebindGridDocMedi();
        //}

        //private void RebindGridBill()
        //{
        //    string selectedValue = ddlRecordType.SelectedValue;
        //    DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
        //    DateTime toDate = Convert.ToDateTime(txtToDate.Text);
        //    gridBill.DataSource = gvBill("Bill", fromDate, toDate);
        //    gridBill.DataBind();
        //}

        //private void RebindGridFeedOtherFeed()
        //{
        //    string selectedValue = ddlRecordType.SelectedValue;
        //    DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
        //    DateTime toDate = Convert.ToDateTime(txtToDate.Text);
        //    GridFeedOtherFeed.DataSource = gvFeedOtherFeed(selectedValue, fromDate, toDate);
        //    GridFeedOtherFeed.DataBind();
        //}

        //private void RebindGridDocMedi()
        //{
        //    string selectedValue = ddlRecordType.SelectedValue;
        //    DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
        //    DateTime toDate = Convert.ToDateTime(txtToDate.Text);
        //    GridDocMedi.DataSource = gvDocMedi(selectedValue, fromDate, toDate);
        //    GridDocMedi.DataBind();
        //}
    }
}
