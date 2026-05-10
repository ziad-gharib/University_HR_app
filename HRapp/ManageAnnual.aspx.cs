using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HRapp
{
    public partial class ManageAnnual : System.Web.UI.Page
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
                    // Using the stored procedure Upperboard_approve_annual from Section 2.5 (i)
                    SqlCommand cmd = new SqlCommand("Upperboard_approve_annual", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // @request_ID
                    if (!string.IsNullOrEmpty(txtRequestID.Text))
                        cmd.Parameters.Add(new SqlParameter("@request_ID", Int32.Parse(txtRequestID.Text)));
                    else
                        throw new Exception("Request ID is required.");

                    // @Upperboard_ID (The approver, from Session)
                    cmd.Parameters.Add(new SqlParameter("@Upperboard_ID", Session["user"]));

                    // @replacement_ID
                    if (!string.IsNullOrEmpty(txtReplacementID.Text))
                        cmd.Parameters.Add(new SqlParameter("@replacement_ID", Int32.Parse(txtReplacementID.Text)));
                    else
                        throw new Exception("Replacement Employee ID is required.");

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    lblMessage.Text = "Success: Request processed (Status updated based on replacement validity).";
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