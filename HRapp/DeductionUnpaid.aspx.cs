using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HRapp
{
    public partial class DeductionUnpaid : System.Web.UI.Page
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
                    // Using the stored procedure Deduction_unpaid from Section 2.4 (g)
                    SqlCommand cmd = new SqlCommand("Deduction_unpaid", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters:
                    // @employee_ID
                    if (!string.IsNullOrEmpty(txtEmpID.Text))
                    {
                        cmd.Parameters.Add(new SqlParameter("@employee_ID", Int32.Parse(txtEmpID.Text)));
                    }
                    else
                    {
                        throw new Exception("Employee ID is required.");
                    }

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    lblMessage.Text = "Success: Unpaid leave deduction calculated and applied.";
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