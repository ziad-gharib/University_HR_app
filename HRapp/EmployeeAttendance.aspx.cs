using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HRapp
{
    public partial class EmployeeAttendance : System.Web.UI.Page
    {
        string connStr = WebConfigurationManager.ConnectionStrings["HRsystem"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("AcademicLogin.aspx");

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
                    // Using the table-valued function MyAttendance from Section 2.5 (c)
                    // This function automatically filters for Current Month and handles the Day Off exclusion logic
                    string query = "SELECT * FROM dbo.MyAttendance(@id)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    // @id comes from the logged-in Session
                    cmd.Parameters.Add(new SqlParameter("@id", Session["user"]));

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gridAtt.DataSource = dt;
                    gridAtt.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        protected void goHome(object sender, EventArgs e) => Response.Redirect("AcademicHome.aspx");
    }
}