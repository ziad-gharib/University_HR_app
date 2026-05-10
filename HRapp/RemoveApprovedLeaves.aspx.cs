using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HRapp
{
    public partial class RemoveApprovedLeaves : System.Web.UI.Page
    {
        string connStr = WebConfigurationManager.ConnectionStrings["HRsystem"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("Login.aspx");
        }

        protected void removeLeaves(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Using the stored procedure from Requirement 2.3 j of your SQL script
                    SqlCommand cmd = new SqlCommand("Remove_Approved_Leaves", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Adding the required parameter
                    if (!string.IsNullOrEmpty(txtEmpID.Text))
                    {
                        cmd.Parameters.Add(new SqlParameter("@employee_id", Int32.Parse(txtEmpID.Text)));

                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        conn.Close();

                        lblMessage.Text = "Success: Approved leave attendance records removed.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMessage.Text = "Please enter an Employee ID.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
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