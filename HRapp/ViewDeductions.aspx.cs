using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HRapp
{
    public partial class ViewDeductions : System.Web.UI.Page
    {
        string connStr = WebConfigurationManager.ConnectionStrings["HRsystem"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("AcademicLogin.aspx");
        }

        protected void viewDeductions(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Using the table-valued function Deductions_Attendance from Section 2.5 (e)
                    string query = "SELECT * FROM dbo.Deductions_Attendance(@id, @month)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    // @id comes from the logged-in Session
                    cmd.Parameters.Add(new SqlParameter("@id", Session["user"]));

                    // @month comes from user input
                    if (!string.IsNullOrEmpty(txtMonth.Text))
                    {
                        cmd.Parameters.Add(new SqlParameter("@month", Int32.Parse(txtMonth.Text)));

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        gridDed.DataSource = dt;
                        gridDed.DataBind();
                    }
                    else
                    {
                        lblMessage.Text = "Please enter a valid month.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        protected void goHome(object sender, EventArgs e) => Response.Redirect("AcademicHome.aspx");
    }
}