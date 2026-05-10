using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HRapp
{
    public partial class ApplyAnnual : System.Web.UI.Page
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
                    // Using the stored procedure Submit_annual from Section 2.5 (g)
                    SqlCommand cmd = new SqlCommand("Submit_annual", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters required by the procedure:
                    // @employee_ID (from Session)
                    cmd.Parameters.Add(new SqlParameter("@employee_ID", Session["user"]));

                    // @replacement_emp (from Input)
                    if (!string.IsNullOrEmpty(txtReplacement.Text))
                        cmd.Parameters.Add(new SqlParameter("@replacement_emp", Int32.Parse(txtReplacement.Text)));
                    else
                        throw new Exception("Replacement Employee ID is required.");

                    // @start_date (from Input)
                    cmd.Parameters.Add(new SqlParameter("@start_date", DateTime.Parse(txtStart.Text)));

                    // @end_date (from Input)
                    cmd.Parameters.Add(new SqlParameter("@end_date", DateTime.Parse(txtEnd.Text)));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    lblMessage.Text = "Success: Annual leave application submitted.";
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