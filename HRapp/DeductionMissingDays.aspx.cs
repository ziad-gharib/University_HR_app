using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HRapp
{
    public partial class DeductionMissingDays : System.Web.UI.Page
    {
        string connStr = WebConfigurationManager.ConnectionStrings["HRsystem"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("HRLogin.aspx");
        }

        protected void applyDeduction(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Using the stored procedure Deduction_days from Section 2.4 (f)
                    SqlCommand cmd = new SqlCommand("Deduction_days", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters:
                    // @employee_id
                    if (!string.IsNullOrEmpty(txtEmpID.Text))
                    {
                        cmd.Parameters.Add(new SqlParameter("@employee_id", Int32.Parse(txtEmpID.Text)));
                    }
                    else
                    {
                        throw new Exception("Employee ID is required.");
                    }

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    lblMessage.Text = "Success: Deduction calculation complete (Record added if unauthorized absences found).";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void goHome(object sender, EventArgs e) => Response.Redirect("HRHome.aspx");
    }
}