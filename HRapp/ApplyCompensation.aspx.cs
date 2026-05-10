using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HRapp
{
    public partial class ApplyCompensation : System.Web.UI.Page
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
                    // Using the stored procedure Submit_compensation from Section 2.5 (n)
                    SqlCommand cmd = new SqlCommand("Submit_compensation", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters:
                    // @employee_ID (from Session)
                    cmd.Parameters.Add(new SqlParameter("@employee_ID", Session["user"]));

                    // @compensation_date (The day off requested)
                    cmd.Parameters.Add(new SqlParameter("@compensation_date", DateTime.Parse(txtCompDate.Text)));

                    // @reason
                    cmd.Parameters.Add(new SqlParameter("@reason", txtReason.Text));

                    // @date_of_original_workday (The day they worked extra)
                    cmd.Parameters.Add(new SqlParameter("@date_of_original_workday", DateTime.Parse(txtWorkDate.Text)));

                    // @rep_emp_id
                    if (!string.IsNullOrEmpty(txtReplacement.Text))
                    {
                        cmd.Parameters.Add(new SqlParameter("@rep_emp_id", Int32.Parse(txtReplacement.Text)));
                    }
                    else
                    {
                        throw new Exception("Replacement Employee ID is required.");
                    }

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    lblMessage.Text = "Success: Compensation leave application submitted.";
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