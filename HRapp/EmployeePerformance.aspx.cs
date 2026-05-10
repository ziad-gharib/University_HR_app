using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HRapp
{
    public partial class EmployeePerformance : System.Web.UI.Page
    {
        string connStr = WebConfigurationManager.ConnectionStrings["HRsystem"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("AcademicLogin.aspx");
        }

        protected void viewPerformance(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Using the table-valued function MyPerformance from Section 2.5 (b) of your script
                    // This function takes EmployeeID and Semester as inputs
                    string query = "SELECT * FROM dbo.MyPerformance(@id, @sem)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    // @id comes from the logged-in Session
                    cmd.Parameters.Add(new SqlParameter("@id", Session["user"]));

                    // @sem comes from the user input
                    cmd.Parameters.Add(new SqlParameter("@sem", txtSemester.Text));

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gridPerf.DataSource = dt;
                    gridPerf.DataBind();
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