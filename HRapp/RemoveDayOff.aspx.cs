using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HRapp
{
    public partial class RemoveDayOff : System.Web.UI.Page
    {
        string connStr = WebConfigurationManager.ConnectionStrings["HRsystem"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("Login.aspx");
        }

        protected void removeDayOff(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Using the stored procedure from Requirement 2.3 i of your SQL script
                    SqlCommand cmd = new SqlCommand("Remove_DayOff", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Adding the required parameter
                    // This checks if the text box is not empty before parsing
                    if (!string.IsNullOrEmpty(txtEmpID.Text))
                    {
                        cmd.Parameters.Add(new SqlParameter("@employee_ID", Int32.Parse(txtEmpID.Text)));

                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        conn.Close();

                        lblMessage.Text = "Success: Unattended day-off records removed.";
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