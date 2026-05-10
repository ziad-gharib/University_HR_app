using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HRapp
{
    public partial class RejectedLeaves : System.Web.UI.Page
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
                    // Standard: Declaring variable 'query'
                    string query = "SELECT * FROM allRejectedMedicals";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gridRejected.DataSource = dt;
                    gridRejected.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Standard: Try-Catch block
                Response.Write($"<script>alert('Error fetching data: {ex.Message}');</script>");
            }
        }

        protected void goHome(object sender, EventArgs e) => Response.Redirect("AdminHome.aspx");
    }
}