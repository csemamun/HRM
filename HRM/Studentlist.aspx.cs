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
    public partial class Studentlist : System.Web.UI.Page
    {
        SqlConnection cn;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
                DisplayStudent();
            }
        }
            private void DisplayStudent()
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from ViewEmp", cn);
                DataSet ds = new DataSet();
                da.Fill(ds, "ViewEmp");
                GridView1.DataSource = ds.Tables[0].DefaultView;
               
                GridView1.DataBind();
            }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Mycon"].ConnectionString);
            cn.Open();
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "del")
            {
                try
                {

                    SqlCommand cmd = new SqlCommand("delete from Employee where employeeid=" + Convert.ToInt32(id) + "", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    DisplayStudent();
                }
                catch(Exception ex)
                {
                    Response.Redirect("Studentlist.aspx");
                }
            }
            else
            {
                Response.Redirect("Updateemployee.aspx?id=" + id);
            }
        }

        protected void lnk_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employee.aspx");
        }
    }
    }