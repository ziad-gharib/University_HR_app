using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HRapp
{
    public partial class EvaluateEmployee : System.Web.UI.Page
    {
        string connStr = WebConfigurationManager.ConnectionStrings["HRsystem"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("AcademicLogin.aspx");
        }

        protected void submitEvaluation(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Using the stored procedure Dean_andHR_Evaluation from Section 2.5 (o)
                    SqlCommand cmd = new SqlCommand("Dean_andHR_Evaluation", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parameters:
                    // @employee_ID
                    if (!string.IsNullOrEmpty(txtEmpID.Text))
                        cmd.Parameters.Add(new SqlParameter("@employee_ID", Int32.Parse(txtEmpID.Text)));
                    else
                        throw new Exception("Employee ID is required.");

                    // @rating (Taken from DropDownList)
                    cmd.Parameters.Add(new SqlParameter("@rating", Int32.Parse(ddlRating.SelectedValue)));

                    // @comment
                    cmd.Parameters.Add(new SqlParameter("@comment", txtComment.Text));

                    // @semester
                    cmd.Parameters.Add(new SqlParameter("@semester", txtSemester.Text));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    lblMessage.Text = "Success: Employee evaluation submitted.";
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