using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HRapp
{
    public partial class ViewPayroll : System.Web.UI.Page
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
                    // Using the table-valued function Last_month_payroll from Section 2.5 (d)
                    string query = "SELECT * FROM dbo.Last_month_payroll(@id)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    // @id comes from the logged-in Session
                    cmd.Parameters.Add(new SqlParameter("@id", Session["user"]));

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gridPayroll.DataSource = dt;
                    gridPayroll.DataBind();
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