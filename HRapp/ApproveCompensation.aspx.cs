using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HRapp
{
    public partial class ApproveCompensation : System.Web.UI.Page
    {
        string connStr = WebConfigurationManager.ConnectionStrings["HRsystem"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("HRLogin.aspx");
        }

        protected void processRequest(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Using the stored procedure HR_approval_comp from Section 2.4 (d)
                    SqlCommand cmd = new SqlCommand("HR_approval_comp", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters:
                    // @request_ID (from Input)
                    if (!string.IsNullOrEmpty(txtRequestID.Text))
                    {
                        cmd.Parameters.Add(new SqlParameter("@request_ID", Int32.Parse(txtRequestID.Text)));
                    }
                    else
                    {
                        throw new Exception("Request ID is required.");
                    }

                    // @HR_ID (The approver, from Session)
                    cmd.Parameters.Add(new SqlParameter("@HR_ID", Session["user"]));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    lblMessage.Text = "Success: Compensation request processed.";
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