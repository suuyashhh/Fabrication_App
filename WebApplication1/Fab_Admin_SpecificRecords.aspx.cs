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
    public partial class Fab_Admin_SpecificRecords : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminId"] == null)
            {
                Response.Redirect("Fab_Admin_Login.aspx?type=Fab_Admin_SpecificRecords");
            }

            if (!IsPostBack)
            {
                gridBill.Visible = false;
                GridGoodExpance.Visible = false;
                GridSalarySlip.Visible = false;
                GridTransport.Visible = false;
                lblGetTotalBill.Visible = false;
                lblGetTotalGoodExpance.Visible = false;
                lblGetTotalSalarySlip.Visible = false;
                lblgetTransport.Visible = false;
                GridViewAttendance.Visible=false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime fromDate = DateTime.MinValue;
            DateTime toDate = DateTime.MaxValue;

            if (!string.IsNullOrEmpty(txtFromDate.Text))
            {
                fromDate = Convert.ToDateTime(txtFromDate.Text);
            }

            if (!string.IsNullOrEmpty(txtToDate.Text))
            {
                toDate = Convert.ToDateTime(txtToDate.Text);
            }

            string selectedValue = ddlRecordType.SelectedValue;

            if (selectedValue == "Fab_Profit")
            {
                DataSet ds = gvBill("Fab_Profit", fromDate, toDate);
                gridBill.DataSource = ds;
                gridBill.DataBind();
                gridBill.Visible = true;
                lblGetTotalBill.Visible = true;
                GridGoodExpance.Visible = false;
                GridSalarySlip.Visible = false;
                GridTransport.Visible = false;
                lblGetTotalGoodExpance.Visible = false;
                lblGetTotalSalarySlip.Visible = false;
                lblgetTransport.Visible = false;
                GridViewAttendance.Visible = false;

                lblGetTotalBill.Text = string.Format("Total Bill: ₹ {0:N0}", GetTotalPrice(ds));
            }
            else if (selectedValue == "Fab_Expanse")
            {
                DataSet ds = gvExpanse(selectedValue, fromDate, toDate);
                GridGoodExpance.DataSource = ds;
                GridGoodExpance.DataBind();
                gridBill.Visible = false;
                GridGoodExpance.Visible = true;
                GridSalarySlip.Visible = false;
                GridTransport.Visible = false;
                lblGetTotalBill.Visible = false;
                lblGetTotalGoodExpance.Visible = true;
                lblGetTotalSalarySlip.Visible = false;
                lblgetTransport.Visible = false;
                GridViewAttendance.Visible = false;

                lblGetTotalGoodExpance.Text = string.Format("Total Goods Expanse: ₹ {0:N0}", GetTotalPriceGoodsExpanse(ds));
            }
            else if (selectedValue == "Transport")
            {
                DataSet ds = gvGridTransport(selectedValue, fromDate, toDate);
                GridTransport.DataSource = ds;
                GridTransport.DataBind();
                gridBill.Visible = false;
                GridGoodExpance.Visible = false;
                GridSalarySlip.Visible = false;
                GridTransport.Visible = true;
                lblGetTotalBill.Visible = false;
                lblGetTotalGoodExpance.Visible = false;
                lblGetTotalSalarySlip.Visible = false;
                lblgetTransport.Visible = true;
                GridViewAttendance.Visible = false;

                lblgetTransport.Text = string.Format("Total Transport : ₹ {0:N0}", GetTotalPriceTransport(ds));
            }
            else if (selectedValue == "HelperAttendance")
            {
                DataSet ds = gvGridHelperAttendance(selectedValue, fromDate, toDate);
                GridViewAttendance.DataSource = ds;
                GridViewAttendance.DataBind();
                gridBill.Visible = false;
                GridGoodExpance.Visible = false;
                GridSalarySlip.Visible = false;
                GridViewAttendance.Visible = true;
                lblGetTotalBill.Visible = false;
                lblGetTotalGoodExpance.Visible = false;
                lblGetTotalSalarySlip.Visible = false;
                GridTransport.Visible = false;
            }
            else if (selectedValue == "Salary_Slip")
            {
                DataSet ds = gvSalary_slip(selectedValue, fromDate, toDate);
                GridSalarySlip.DataSource = ds;
                GridSalarySlip.DataBind();
                gridBill.Visible = false;
                GridGoodExpance.Visible = false;
                GridSalarySlip.Visible = true;
                GridTransport.Visible = false;
                lblGetTotalBill.Visible = false;
                lblGetTotalGoodExpance.Visible = false;
                lblGetTotalSalarySlip.Visible = true;
                lblgetTransport.Visible = false;
                GridViewAttendance.Visible = false;

                lblGetTotalSalarySlip.Text = string.Format("Total Salary: ₹ {0:N0}", GetTotalPriceSalarySlip(ds));
            }
            else
            {
                gridBill.DataSource = null;
                gridBill.DataBind();
                GridGoodExpance.DataSource = null;
                GridGoodExpance.DataBind();
                GridSalarySlip.DataSource = null;
                GridSalarySlip.DataBind();
                lblGetTotalBill.Visible = false;
                lblGetTotalGoodExpance.Visible = false;
                lblGetTotalSalarySlip.Visible = false;
                GridViewAttendance.Visible = false;
            }
        }

        protected decimal GetTotalPrice(DataSet ds)
        {
            decimal total = 0;

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["Pro_price"] != DBNull.Value)
                    {
                        total += Convert.ToDecimal(row["Pro_price"]);
                    }
                }
            }
            return total;
        }
        protected decimal GetTotalPriceGoodsExpanse(DataSet ds)
        {
            decimal total = 0;

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["Exp_price"] != DBNull.Value)
                    {
                        total += Convert.ToDecimal(row["Exp_price"]);
                    }
                }
            }
            return total;
        }
        protected decimal GetTotalPriceTransport(DataSet ds)
        {
            decimal total = 0;

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["Exp_price"] != DBNull.Value)
                    {
                        total += Convert.ToDecimal(row["Exp_price"]);
                    }
                }
            }
            return total;
        }

        protected decimal GetTotalPriceSalarySlip(DataSet ds)
        {
            decimal total = 0;

            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (row["Grand_Total"] != DBNull.Value)
                    {
                        total += Convert.ToDecimal(row["Grand_Total"]);
                    }
                }
            }
            return total;
        }

        protected DataSet gvBill(string recordType, DateTime fromDate, DateTime toDate)
        {
            SqlCommand sql = new SqlCommand
            {
                Connection = con,
                CommandText = @"SELECT * FROM " + recordType + @" WHERE [date] BETWEEN @FromDate AND @ToDate ORDER BY [date] ASC"
            };
            sql.Parameters.AddWithValue("@FromDate", fromDate);
            sql.Parameters.AddWithValue("@ToDate", toDate);

            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sql);
            adapter.Fill(ds);
            con.Close();

            return ds;
        }

        protected DataSet gvExpanse(string recordType, DateTime fromDate, DateTime toDate)
        {
            string query = @"SELECT Exp_id, Exp_name, Exp_price, [date] 
              FROM " + recordType + @" 
              WHERE User_id IS NULL 
              AND [date] BETWEEN @FromDate AND @ToDate
              ORDER BY [date] ASC";

            using (SqlCommand sql = new SqlCommand(query, con))
            {
                sql.Parameters.AddWithValue("@FromDate", fromDate);
                sql.Parameters.AddWithValue("@ToDate", toDate);

                SqlDataAdapter adapter = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();

                con.Open();
                adapter.Fill(ds);
                con.Close();

                return ds;
            }
        }
        protected DataSet gvSalary_slip(string recordType, DateTime fromDate, DateTime toDate)
        {
            string query = @" select 
                 SS.User_id,
                 FU.User_name,
                 SS.Grand_Total,
                 SS.Slip_Day

                 from Salary_Slip SS left join Fab_Users FU on SS.User_id = FU.User_id 
               WHERE [Slip_Day] BETWEEN @FromDate AND @ToDate
              ORDER BY [Slip_Day] ASC";

            using (SqlCommand sql = new SqlCommand(query, con))
            {
                sql.Parameters.AddWithValue("@FromDate", fromDate);
                sql.Parameters.AddWithValue("@ToDate", toDate);

                SqlDataAdapter adapter = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();

                con.Open();
                adapter.Fill(ds);
                con.Close();

                return ds;
            }
        }
        protected DataSet gvGridTransport(string recordType, DateTime fromDate, DateTime toDate)
        {
            string query = @"SELECT date,Exp_id, Exp_name, Exp_price FROM Fab_Expanse 
            WHERE User_id = 20203 AND [date] BETWEEN @FromDate AND @ToDate
              ORDER BY [date] ASC";

            using (SqlCommand sql = new SqlCommand(query, con))
            {
                sql.Parameters.AddWithValue("@FromDate", fromDate);
                sql.Parameters.AddWithValue("@ToDate", toDate);

                SqlDataAdapter adapter = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();

                con.Open();
                adapter.Fill(ds);
                con.Close();

                return ds;
            }
        }
        
        protected DataSet gvGridHelperAttendance(string recordType, DateTime fromDate, DateTime toDate)
        {
            string query = @"SELECT CAST(date as DATE) as DATE,H_id, User_name, User_day FROM Fab_Helper_Att 
            WHERE CAST([date] as DATE) BETWEEN @FromDate AND @ToDate
              ORDER BY CAST([date] AS DATE) ASC";

            using (SqlCommand sql = new SqlCommand(query, con))
            {
                sql.Parameters.AddWithValue("@FromDate", fromDate);
                sql.Parameters.AddWithValue("@ToDate", toDate);

                SqlDataAdapter adapter = new SqlDataAdapter(sql);
                DataSet ds = new DataSet();

                con.Open();
                adapter.Fill(ds);
                con.Close();

                return ds;
            }
        }
        protected void gridBill_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridBill.EditIndex = e.NewEditIndex;
            RebindGridBill();
        }
        protected void gridBill_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridBill.Rows[e.RowIndex];
            string Pro_id = gridBill.DataKeys[e.RowIndex].Value.ToString();
            string Pro_name = ((TextBox)row.FindControl("txtAT")).Text;
            string Pro_price = ((TextBox)row.FindControl("txtprice")).Text;

            SqlCommand cmd = new SqlCommand("UPDATE Fab_Profit SET Pro_name = @Pro_name, Pro_price = @Pro_price WHERE Pro_id = @Pro_id", con);
            cmd.Parameters.AddWithValue("@Pro_name", Pro_name);
            cmd.Parameters.AddWithValue("@Pro_price", Pro_price);
            cmd.Parameters.AddWithValue("@Pro_id", Pro_id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            gridBill.EditIndex = -1;
            RebindGridBill();
        }
        protected void gridBill_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridBill.EditIndex = -1;
            RebindGridBill();
        }
        protected void gridBill_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Pro_id = gridBill.DataKeys[e.RowIndex].Value.ToString();
            SqlCommand cmd = new SqlCommand("DELETE FROM Fab_Profit WHERE Pro_id = @Pro_id", con);
            cmd.Parameters.AddWithValue("@Pro_id", Pro_id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            RebindGridBill();
        }
        protected void GridGoodExpance_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridGoodExpance.EditIndex = e.NewEditIndex;
            RebindGoodExpanse();
        }

        protected void GridGoodExpance_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridGoodExpance.EditIndex = -1;
            RebindGoodExpanse();
        }
        protected void GridGoodExpance_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridGoodExpance.Rows[e.RowIndex];
            string Exp_id = GridGoodExpance.DataKeys[e.RowIndex].Value.ToString();
            string Exp_name = ((TextBox)row.FindControl("txtFeedN")).Text;
            string Exp_price = ((TextBox)row.FindControl("txtOFprice")).Text;

            SqlCommand cmd = new SqlCommand("UPDATE Fab_Expanse SET Exp_name = @Exp_name, Exp_price = @Exp_price WHERE Exp_id = @Exp_id", con);
            cmd.Parameters.AddWithValue("@Exp_name", Exp_name);
            cmd.Parameters.AddWithValue("@Exp_price", Exp_price);
            cmd.Parameters.AddWithValue("@Exp_id", Exp_id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            GridGoodExpance.EditIndex = -1;
            RebindGoodExpanse();
        }
        protected void GridGoodExpance_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Exp_id = GridGoodExpance.DataKeys[e.RowIndex].Value.ToString();
            SqlCommand cmd = new SqlCommand("DELETE FROM Fab_Expanse WHERE Exp_id = @Exp_id", con);
            cmd.Parameters.AddWithValue("@Exp_id", Exp_id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            RebindGoodExpanse();
        }
        protected void GridTransport_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridTransport.EditIndex = e.NewEditIndex;
            RebindTransport();
        }
        protected void GridTransport_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridTransport.EditIndex = -1;
            RebindTransport();
        }
        protected void GridTransport_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridTransport.Rows[e.RowIndex];
            string Exp_id = GridTransport.DataKeys[e.RowIndex].Value.ToString();
            string Exp_name = ((TextBox)row.FindControl("txtTranNAme")).Text;
            string Exp_price = ((TextBox)row.FindControl("txtTranPrice")).Text;

            SqlCommand cmd = new SqlCommand("UPDATE Fab_Expanse SET Exp_name = @Exp_name, Exp_price = @Exp_price WHERE Exp_id = @Exp_id", con);
            cmd.Parameters.AddWithValue("@Exp_name", Exp_name);
            cmd.Parameters.AddWithValue("@Exp_price", Exp_price);
            cmd.Parameters.AddWithValue("@Exp_id", Exp_id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            GridTransport.EditIndex = -1;
            RebindTransport();
        }
        protected void GridTransport_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Exp_id = GridTransport.DataKeys[e.RowIndex].Value.ToString();
            SqlCommand cmd = new SqlCommand("DELETE FROM Fab_Expanse WHERE Exp_id = @Exp_id", con);
            cmd.Parameters.AddWithValue("@Exp_id", Exp_id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            RebindTransport();
        }
        private void RebindGridBill()
        {
            string selectedValue = ddlRecordType.SelectedValue;
            DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime toDate = Convert.ToDateTime(txtToDate.Text);
            gridBill.DataSource = gvBill("Fab_Profit", fromDate, toDate);
            gridBill.DataBind();
        }
        private void RebindGoodExpanse()
        {
            string selectedValue = ddlRecordType.SelectedValue;
            DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime toDate = Convert.ToDateTime(txtToDate.Text);
            GridGoodExpance.DataSource = gvExpanse(selectedValue, fromDate, toDate);
            GridGoodExpance.DataBind();
        }
        private void RebindTransport()
        {
            string selectedValue = ddlRecordType.SelectedValue;
            DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime toDate = Convert.ToDateTime(txtToDate.Text);
            GridTransport.DataSource = gvGridTransport(selectedValue, fromDate, toDate);
            GridTransport.DataBind();
        }
        
        private void RebindHelperAttendance()
        {
            string selectedValue = ddlRecordType.SelectedValue;
            DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime toDate = Convert.ToDateTime(txtToDate.Text);
            GridViewAttendance.DataSource = gvGridHelperAttendance(selectedValue, fromDate, toDate);
            GridViewAttendance.DataBind();
        }

        protected void GridViewAttendance_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewAttendance.EditIndex = e.NewEditIndex;
            RebindHelperAttendance();
        }

        protected void GridViewAttendance_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewAttendance.EditIndex = -1;
            RebindHelperAttendance();
        }

        protected void GridViewAttendance_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewAttendance.Rows[e.RowIndex];
            string H_id = GridViewAttendance.DataKeys[e.RowIndex].Value.ToString();
            string User_day = ((TextBox)row.FindControl("txtahelperDay")).Text;

            SqlCommand cmd = new SqlCommand("UPDATE Fab_Helper_Att SET User_day = @User_day WHERE H_id = @H_id", con);
            cmd.Parameters.AddWithValue("@User_day", User_day);
            cmd.Parameters.AddWithValue("@H_id", H_id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            GridViewAttendance.EditIndex = -1;
            RebindHelperAttendance();
        }

        protected void GridViewAttendance_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string H_id = GridViewAttendance.DataKeys[e.RowIndex].Value.ToString();
            SqlCommand cmd = new SqlCommand("DELETE FROM Fab_Helper_Att WHERE H_id = @H_id", con);
            cmd.Parameters.AddWithValue("@H_id", H_id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            RebindHelperAttendance();
        }
    }
}