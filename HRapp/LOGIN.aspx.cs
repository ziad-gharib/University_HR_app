using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;

namespace HRapp
{
    public partial class LOGIN : System.Web.UI.Page
    {
        string connStr = WebConfigurationManager.ConnectionStrings["HRsystem"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear any existing session
            Session.Clear();
        }

        protected void login(object sender, EventArgs e)
        {
            try
            {
                string id = txtID.Text.Trim();
                string password = txtPassword.Text.Trim();

                // Check Admin login first
                if (id == "admin" && password == "admin")
                {
                    Session["user"] = "admin";
                    Response.Redirect("AdminHome.aspx");
                    return;
                }

                // Validate ID is a number
                int parsedId;
                if (!Int32.TryParse(id, out parsedId))
                {
                    lblMessage.Text = "Invalid ID format. ID must be a number.";
                    return;
                }

                // Check HR login using SQL function
                bool hrLoginSuccess = false;
                try
                {
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("SELECT dbo.HRLoginValidation(@id, @pass)", conn);
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = parsedId;
                        SqlParameter passParam = new SqlParameter("@pass", SqlDbType.NVarChar);
                        passParam.Size = 100;
                        passParam.Value = password ?? string.Empty;
                        cmd.Parameters.Add(passParam);
                        cmd.CommandType = System.Data.CommandType.Text;

                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            hrLoginSuccess = Convert.ToBoolean(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // If function fails, try direct query as fallback for HR
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connStr))
                        {
                            conn.Open();
                            // Check if employee is HR by checking roles
                            SqlCommand cmd = new SqlCommand(@"
                                SELECT COUNT(*) 
                                FROM Employee e
                                INNER JOIN Employee_Role er ON e.employee_id = er.emp_ID
                                WHERE e.employee_id = @id 
                                AND e.password = @pass
                                AND (er.role_name LIKE 'HR%' OR er.role_name = 'HR Manager')", conn);
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = parsedId;
                            SqlParameter passParam = new SqlParameter("@pass", SqlDbType.NVarChar);
                            passParam.Size = 100;
                            passParam.Value = password ?? string.Empty;
                            cmd.Parameters.Add(passParam);
                            
                            int count = Convert.ToInt32(cmd.ExecuteScalar());
                            hrLoginSuccess = (count > 0);
                        }
                    }
                    catch
                    {
                        // Continue to Academic check if HR validation fails
                    }
                }

                if (hrLoginSuccess)
                {
                    Session["user"] = id;
                    Response.Redirect("HRHome.aspx");
                    return;
                }

                // Check Academic/Employee login using SQL function
                bool academicLoginSuccess = false;
                try
                {
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("SELECT dbo.EmployeeLoginValidation(@id, @pass)", conn);
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = parsedId;
                        SqlParameter passParam = new SqlParameter("@pass", SqlDbType.NVarChar);
                        passParam.Size = 100;
                        passParam.Value = password ?? string.Empty;
                        cmd.Parameters.Add(passParam);
                        cmd.CommandType = System.Data.CommandType.Text;

                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            academicLoginSuccess = Convert.ToBoolean(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // If function fails, try direct query as fallback
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connStr))
                        {
                            conn.Open();
                            // Check if employee is Academic by checking roles (Dean, Vice Dean, Lecturer, Teaching Assistant)
                            SqlCommand cmd = new SqlCommand(@"
                                SELECT COUNT(*) 
                                FROM Employee e
                                INNER JOIN Employee_Role er ON e.employee_id = er.emp_ID
                                WHERE e.employee_id = @id 
                                AND e.password = @pass
                                AND er.role_name IN ('Dean', 'Vice Dean', 'Lecturer', 'Teaching Assistant', 'President', 'Vice President')", conn);
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = parsedId;
                            SqlParameter passParam = new SqlParameter("@pass", SqlDbType.NVarChar);
                            passParam.Size = 100;
                            passParam.Value = password ?? string.Empty;
                            cmd.Parameters.Add(passParam);
                            
                            int count = Convert.ToInt32(cmd.ExecuteScalar());
                            academicLoginSuccess = (count > 0);
                        }
                    }
                    catch (Exception ex2)
                    {
                        // Show detailed error for debugging
                        lblMessage.Text = "Login failed. Function Error: " + ex.Message + " | Direct Query Error: " + ex2.Message;
                        return;
                    }
                }

                if (academicLoginSuccess)
                {
                    Session["user"] = id;
                    Response.Redirect("AcademicHome.aspx");
                    return;
                }

                // If none of the checks succeeded, show error message
                lblMessage.Text = "Invalid ID or password. Please check your credentials and try again.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}
