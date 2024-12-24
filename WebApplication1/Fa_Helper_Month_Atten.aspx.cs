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
    public partial class Doctor : System.Web.UI.Page
    {
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["userId"] == null)
            //{
            //    Response.Redirect("Login.aspx?type=Doctor");
            //}

            //if (!IsPostBack)
            //{
            //    BindDoctordata();
            //}
        }

        //private void BindDoctordata()
        //{
        //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("SELECT animal_id, animal_name FROM AnimalsName where user_id= @userId", con))
        //        {

        //            cmd.CommandType = CommandType.Text;
        //            cmd.Parameters.AddWithValue("@userId", Session["userId"]);
        //            con.Open();
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                ddldoctorname.DataSource = reader;
        //                ddldoctorname.DataTextField = "animal_name";
        //                ddldoctorname.DataValueField = "animal_name";
        //                ddldoctorname.DataBind();
        //            }
        //        }
        //    }
        //    ddldoctorname.Items.Insert(0, new ListItem("--Select Cattle--", ""));
        //}
        protected void btnSubmitdoctor_Click(object sender, EventArgs e)
        {
            //con.Close();
            //SqlCommand cmd = new SqlCommand("insert into Expense (user_id,expense_name,animal_name,reason,price,date) values (@id,@exname,@animal,@reason,@rs,@dt)", con);


            //cmd.Parameters.AddWithValue("@id", Session["userId"]);
            //cmd.Parameters.AddWithValue("@exname", "Doctor");
            //cmd.Parameters.AddWithValue("@animal", ddldoctorname.Text);
            //cmd.Parameters.AddWithValue("@reason", doctorrsn.Text);
            //cmd.Parameters.AddWithValue("@rs", doctorPrice.Text);


            //DateTime selectedDate;
            //if (DateTime.TryParse(doctorDate.Text, out selectedDate))
            //{
            //    cmd.Parameters.AddWithValue("@dt", selectedDate);
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "SweetAlert", "swal('Invalid date format!','','warning');", true);
            //    return;
            //}



            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();

            //doctorPrice.Text = "";
            //doctorrsn.Text = "";
            //doctorDate.Text = "";
            //BindDoctordata();
            //this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Record saved successfully','','success');", true);

        }
    }
}