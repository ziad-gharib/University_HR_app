using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HRapp
{
    public partial class RemoveDeductions : System.Web.UI.Page
    {
        string connStr = WebConfigurationManager.ConnectionStrings["HRsystem"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("Login.aspx");
        }

        protected void removeDeductions(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Using the stored procedure from Requirement 2.3 b of your SQL script
                    SqlCommand cmd = new SqlCommand("Remove_Deductions", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // No parameters required for this procedure

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();

                    lblMessage.Text = "Success: Deductions for resigned employees have been removed.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                // Consistent Error Handling
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void goHome(object sender, EventArgs e) => Response.Redirect("AdminHome.aspx");
    }
}