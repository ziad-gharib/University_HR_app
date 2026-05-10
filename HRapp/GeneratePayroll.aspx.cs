using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HRapp
{
    public partial class GeneratePayroll : System.Web.UI.Page
    {
        string connStr = WebConfigurationManager.ConnectionStrings["HRsystem"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("HRLogin.aspx");
        }

        protected void generatePayroll(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Using the stored procedure Add_Payroll from Section 2.4 (i)
                    SqlCommand cmd = new SqlCommand("Add_Payroll", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters:
                    // @employee_ID
                    if (!string.IsNullOrEmpty(txtEmpID.Text))
                        cmd.Parameters.Add(new SqlParameter("@employee_ID", Int32.Parse(txtEmpID.Text)));
                    else
                        throw new Exception("Employee ID is required.");

                    // @from (Start Date)
                    cmd.Parameters.Add(new SqlParameter("@from", DateTime.Parse(txtFrom.Text)));

                    // @to (End Date)
                    cmd.Parameters.Add(new SqlParameter("@to", DateTime.Parse(txtTo.Text)));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    lblMessage.Text = "Success: Payroll generated and deductions finalized.";
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