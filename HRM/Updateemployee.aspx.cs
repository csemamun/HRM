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
    public partial class Updateemployee : System.Web.UI.Page
    {
        SqlConnection cn;
        protected void Page_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(  ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            if(!IsPostBack)
            {
                int id =Convert.ToInt32( Request.QueryString["id"]);
                EmpDisbyId(id);
                DisDes();
                disDept();
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
        public void EmpDisbyId(int id)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from employee where EmployeeId=" + id + "", cn);
            SqlDataReader dr = cmd.ExecuteReader();
           
            while (dr.Read())
            {
                hid.Value = dr["Employeeid"].ToString();
                txtName.Text = dr["EmpName"].ToString();
                txtemail.Text = dr["Email"].ToString();
                txtphone.Text = dr["Phone"].ToString();
                txtsalary.Text = dr["BasicSalary"].ToString();
                DrpDesignatgion.SelectedValue = dr["DesignationId"].ToString();
                dept.SelectedValue = dr["Deptid"].ToString();

            }
            cn.Close();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            { 
            cn.Open();
            SqlCommand cmd = new SqlCommand("SPUpdateEmployee", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeId", Convert.ToInt32(hid.Value));
            cmd.Parameters.AddWithValue("@Empname", txtName.Text);
            cmd.Parameters.AddWithValue("@Email", txtemail.Text);
            cmd.Parameters.AddWithValue("@Phone", txtphone.Text);
            cmd.Parameters.AddWithValue("@DeptId",Convert.ToInt32( dept.SelectedValue));
            cmd.Parameters.AddWithValue("@DesignationId", Convert.ToInt32(DrpDesignatgion.SelectedValue));
            cmd.Parameters.AddWithValue("@BasicSalary", Convert.ToDouble(txtsalary.Text));
            cmd.ExecuteNonQuery();
            hid.Value = "";
            Response.Redirect("Studentlist.aspx");
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }
        }
    }
}