using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HRapp
{
    public partial class UpdateAttendance : System.Web.UI.Page
    {
        string connStr = WebConfigurationManager.ConnectionStrings["HRsystem"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("Login.aspx");
        }

        protected void updateRecord(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Using the stored procedure from your SQL script (2.3 g)
                    SqlCommand cmd = new SqlCommand("Update_Attendance", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Adding parameters
                    // Parsing ID as integer
                    cmd.Parameters.Add(new SqlParameter("@Employee_id", Int32.Parse(txtID.Text)));
                    cmd.Parameters.Add(new SqlParameter("@check_in_time", txtIn.Text));
                    cmd.Parameters.Add(new SqlParameter("@check_out_time", txtOut.Text));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    lblMessage.Text = "Success: Attendance record updated.";
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