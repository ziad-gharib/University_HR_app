using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HRapp
{
    public partial class ManageUnpaid : System.Web.UI.Page
    {
        string connStr = WebConfigurationManager.ConnectionStrings["HRsystem"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("AcademicLogin.aspx");
        }

        protected void processRequest(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Using the stored procedure Upperboard_approve_unpaids from Section 2.5 (m)
                    SqlCommand cmd = new SqlCommand("Upperboard_approve_unpaids", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // @request_ID (from Input)
                    if (!string.IsNullOrEmpty(txtRequestID.Text))
                    {
                        cmd.Parameters.Add(new SqlParameter("@request_ID", Int32.Parse(txtRequestID.Text)));
                    }
                    else
                    {
                        throw new Exception("Request ID is required.");
                    }

                    // @upperboard_ID (The ID of the Dean/President approving, from Session)
                    cmd.Parameters.Add(new SqlParameter("@upperboard_ID", Session["user"]));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    lblMessage.Text = "Success: Request has been processed (Approved/Rejected based on policy).";
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