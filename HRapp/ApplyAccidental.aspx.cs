using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HRapp
{
    public partial class ApplyAccidental : System.Web.UI.Page
    {
        string connStr = WebConfigurationManager.ConnectionStrings["HRsystem"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("AcademicLogin.aspx");
        }

        protected void submitLeave(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Using the stored procedure Submit_accidental from Section 2.5 (j)
                    SqlCommand cmd = new SqlCommand("Submit_accidental", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters:
                    // @employee_ID (from Session)
                    cmd.Parameters.Add(new SqlParameter("@employee_ID", Session["user"]));

                    // @start_date
                    cmd.Parameters.Add(new SqlParameter("@start_date", DateTime.Parse(txtStart.Text)));

                    // @end_date
                    cmd.Parameters.Add(new SqlParameter("@end_date", DateTime.Parse(txtEnd.Text)));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    lblMessage.Text = "Success: Accidental leave application submitted.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void goHome(object sender, EventArgs e) => Response.Redirect("AcademicHome.aspx");
    }
}