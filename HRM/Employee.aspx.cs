using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HRM
{
    public partial class Employee : System.Web.UI.Page
    {
        SqlConnection cn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
                disDept();
                DisDes();
            }
            }
        private void DisDes()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Designation", cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Designation");
            DrpDesignatgion.DataSource = ds.Tables[0].DefaultView;
            DrpDesignatgion.DataTextField = "DesignationName";
            DrpDesignatgion.DataValueField = "DesignationId";
            DrpDesignatgion.DataBind();
        }
        private void disDept()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Department", cn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Department");
            dept.DataSource = ds.Tables[0].DefaultView;
            dept.DataTextField = "DepName";
            dept.DataValueField = "DepId";
            dept.DataBind();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("spInsertEmployee", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpName", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                cmd.Parameters.AddWithValue("@Phone", txtphone.Text);
                cmd.Parameters.AddWithValue("@DeptId",Convert.ToInt32(dept.SelectedValue));
                cmd.Parameters.AddWithValue("@DesignationId",Convert.ToInt32(DrpDesignatgion.SelectedValue));
                cmd.Parameters.AddWithValue("@BasicSalary",Convert.ToDouble(txtsalary.Text));
                cmd.ExecuteNonQuery();
                Response.Redirect("Studentlist.aspx");
                cn.Close();
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
        }
    }
}