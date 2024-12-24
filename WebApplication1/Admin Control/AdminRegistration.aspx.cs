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
    public partial class AdminRegistration : System.Web.UI.Page
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
                gridv.DataSource = gvuser();
                gridv.DataBind();
            }
        }
        protected DataSet gvuser()
        {
            con.Close();
            SqlCommand sql = new SqlCommand("select * from Admin", con);
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sql);
            adapter.Fill(ds);
            return ds;
        }


        protected void gridv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridv.EditIndex = e.NewEditIndex;
            gridv.DataSource = gvuser();
            gridv.DataBind();
        }

        protected void gridv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridv.EditIndex = -1;
            gridv.DataSource = gvuser();
            gridv.DataBind();
        }

        protected void gridv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridv.Rows[e.RowIndex];
            string name = (row.FindControl("txtname") as TextBox).Text;           
            string password = (row.FindControl("txtpass") as TextBox).Text;

            con.Close();
            SqlCommand cmd = new SqlCommand("update Admin set admin_id=@name,password=@password where srno =@srno", con);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@srno", gridv.DataKeys[e.RowIndex].Value);
            con.Open();
            cmd.ExecuteNonQuery();
            gridv.EditIndex = -1;
            gridv.DataSource = gvuser();
            gridv.DataBind();
        }

        protected void gridv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            con.Close();
            SqlCommand sql = new SqlCommand("delete from Admin where srno='" + gridv.DataKeys[e.RowIndex].Value + "' ", con);
            con.Open();
            sql.ExecuteNonQuery();
            gridv.EditIndex = -1;
            gridv.DataSource = gvuser();
            gridv.DataBind();
        }
    }
}