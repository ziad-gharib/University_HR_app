using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HRapp
{
    public partial class ViewProfiles : System.Web.UI.Page
    {
        string connStr = WebConfigurationManager.ConnectionStrings["HRsystem"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // 1. Declare the query variable for readability
                    string query = "SELECT * FROM allEmployeeProfiles";

                    // 2. Pass the variable to the adapter
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gridProfiles.DataSource = dt;
                    gridProfiles.DataBind();
                }
            }
            catch (Exception ex)
            {
                // 3. Consistent error handling
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }

        protected void goHome(object sender, EventArgs e) => Response.Redirect("AdminHome.aspx");
    }
}