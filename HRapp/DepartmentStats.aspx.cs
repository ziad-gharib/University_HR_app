using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HRapp
{
    public partial class DepartmentStats : System.Web.UI.Page
    {
        // Using the connection string name "HRsystem" as requested
        string connStr = WebConfigurationManager.ConnectionStrings["HRsystem"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Security check: Redirect to login if not logged in
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadStats();
            }
        }

        private void LoadStats()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Querying the specific View created in your SQL script (2.2 b)
                    string query = "SELECT * FROM NoEmployeeDept";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gridDeptStats.DataSource = dt;
                    gridDeptStats.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Simple error handling in case the View doesn't exist or DB is down
                Response.Write($"<script>alert('Error fetching data: {ex.Message}');</script>");
            }
        }

        protected void goHome(object sender, EventArgs e)
        {
            Response.Redirect("AdminHome.aspx");
        }
    }
}