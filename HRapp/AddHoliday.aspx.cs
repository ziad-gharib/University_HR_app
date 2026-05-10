using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HRapp
{
    public partial class AddHoliday : System.Web.UI.Page
    {
        string connStr = WebConfigurationManager.ConnectionStrings["HRsystem"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("Login.aspx");
        }

        protected void addHoliday(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Using the stored procedure from your SQL script (2.3 d)
                    SqlCommand cmd = new SqlCommand("Add_Holiday", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Adding parameters
                    // Note: If inputs are empty, the procedure handles validation logic
                    cmd.Parameters.Add(new SqlParameter("@holiday_name", txtName.Text));
                    cmd.Parameters.Add(new SqlParameter("@from_date", DateTime.Parse(txtFrom.Text)));
                    cmd.Parameters.Add(new SqlParameter("@to_date", DateTime.Parse(txtTo.Text)));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    lblMessage.Text = "Success: Holiday has been added.";
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