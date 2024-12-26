using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace WebApplication1
{
    public partial class Fab_Admin_Master : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindHelperDropdown();
            }
            if (!IsPostBack)
            {
                gridAdvance.DataSource = gvuser();
                gridAdvance.DataBind();
            }
            if (!IsPostBack)
            {
                gridHelper.DataSource = gvuserDetails();
                gridHelper.DataBind();
            }
        }

        private void BindHelperDropdown()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT User_id, User_name FROM Fab_Users", con))
                {
                   
                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        ddlHelpername.DataSource = reader;
                        ddlHelpername.DataTextField = "User_name";
                        ddlHelpername.DataValueField = "User_id";
                        ddlHelpername.DataBind();
                    }
                }
            }

            ddlHelpername.Items.Insert(0, new ListItem("--Select Helper--", ""));
        }

        protected DataSet gvuser()
        {
            con.Close();
            SqlCommand sql = new SqlCommand(" SELECT FE.Exp_id,FE.date AS ExpenseDate,FE.User_advance,FE.User_id,FU.User_name FROM Fab_Expanse FE INNER JOIN  Fab_Users FU ON FE.User_id = FU.User_id", con);
     
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sql);
            adapter.Fill(ds);
            return ds;
        }


        protected DataSet gvuserDetails()
        {
            con.Close();
            SqlCommand sql = new SqlCommand(" SELECT * FROM Fab_Users FE", con);

            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sql);
            adapter.Fill(ds);
            return ds;
        }


        protected void btnSubmitAdvance_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Fab_Expanse (User_id, User_advance, date) VALUES (@id, @Advance, @dt)", con))
                {
                    cmd.Parameters.AddWithValue("@Advance", AdvanceMoney.Text.Trim()); 
                    cmd.Parameters.AddWithValue("@id", ddlHelpername.SelectedValue); 
                    cmd.Parameters.AddWithValue("@dt", DateTime.Now); 

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            AdvanceMoney.Text = "";
            BindHelperDropdown();
            gridAdvance.DataSource = gvuser();
            gridAdvance.DataBind();

            this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Record saved successfully','','success');", true);

        }

        protected void gridAdvance_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridAdvance.EditIndex = e.NewEditIndex;                       
            gridAdvance.DataSource = gvuser();
            gridAdvance.DataBind();
        }

        protected void gridAdvance_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            gridAdvance.EditIndex = -1;
            gridAdvance.DataSource = gvuser();
            gridAdvance.DataBind();
        }

        protected void gridAdvance_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridAdvance.Rows[e.RowIndex];

            string expenseDate = (row.FindControl("txtDate") as TextBox)?.Text;
            string userName = (row.FindControl("txtname") as TextBox)?.Text;
            string advanceMoney = (row.FindControl("txtAdv") as TextBox)?.Text;

            int expenseId = Convert.ToInt32(gridAdvance.DataKeys[e.RowIndex].Value);

            string updateQuery = @"
        UPDATE FE
        SET FE.date = @ExpenseDate,
            FE.User_advance = @AdvanceMoney,
            FE.User_id = (SELECT User_id FROM Fab_Users WHERE User_name = @UserName)
        FROM Fab_Expanse FE
        WHERE FE.Exp_id = @ExpenseId";

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@ExpenseDate", DateTime.ParseExact(expenseDate, "dd-MMM-yyyy", null));
                    cmd.Parameters.AddWithValue("@AdvanceMoney", decimal.Parse(advanceMoney));
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.Parameters.AddWithValue("@ExpenseId", expenseId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            gridAdvance.EditIndex = -1;

            gridAdvance.DataSource = gvuser();
            gridAdvance.DataBind();
        }

        protected void gridAdvance_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int expenseId = Convert.ToInt32(gridAdvance.DataKeys[e.RowIndex].Value);

            string deleteQuery = "DELETE FROM Fab_Expanse WHERE Exp_id = @ExpenseId";

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@ExpenseId", expenseId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            gridAdvance.DataSource = gvuser();
            gridAdvance.DataBind();
        }

        protected void gridHelper_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            con.Close();
            SqlCommand sql = new SqlCommand("delete from AnimalsName where User_id='" + gridHelper.DataKeys[e.RowIndex].Value + "' ", con);
            con.Open();
            sql.ExecuteNonQuery();
            gridHelper.EditIndex = -1;
            gridHelper.DataSource = gvuserDetails();
            gridHelper.DataBind();
        }

        protected void gridHelper_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridHelper.Rows[e.RowIndex];

            string userId = gridHelper.DataKeys[e.RowIndex].Value.ToString();
            string name = (row.FindControl("txtname") as TextBox).Text;
            string contact = (row.FindControl("txtContact") as TextBox).Text;
            string password = (row.FindControl("txtpass") as TextBox).Text;
            string salary = (row.FindControl("txtsalary") as TextBox).Text;

            string updateQuery = @"
        UPDATE Fab_Users 
        SET User_name = @name, 
            User_contact = @contact, 
            User_pass = @password, 
            User_salary = @salary
        WHERE User_id = @userId";

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@contact", contact);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@salary", salary);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            gridHelper.EditIndex = -1;

            gridHelper.DataSource = gvuserDetails();
            gridHelper.DataBind();
        }

        protected void gridHelper_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridHelper.EditIndex = -1;
            gridHelper.DataSource = gvuserDetails();
            gridHelper.DataBind();
        }

        protected void gridHelper_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridHelper.EditIndex = e.NewEditIndex;
            gridHelper.DataSource = gvuserDetails();
            gridHelper.DataBind();
        }
    }
}