using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HRapp
{
    public partial class AcademicHome : System.Web.UI.Page
    {
        string connStr = WebConfigurationManager.ConnectionStrings["HRsystem"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("LOGIN.aspx");
            lblUser.Text = Session["user"].ToString();

            // Check role-based visibility for Management Actions section
            // Only Upper Board members (President, Vice President, Dean, Vice Dean) should see this section
            if (!IsPostBack)
            {
                CheckManagementActionsVisibility();
            }
        }

        /// <summary>
        /// Checks if the logged-in employee has Upper Board roles and sets visibility of Management Actions section accordingly.
        /// Upper Board roles: President, Vice President, Dean, Vice Dean
        /// If employee has any of these roles, the Management Actions panel will be visible.
        /// </summary>
        private void CheckManagementActionsVisibility()
        {
            try
            {
                // Get employee ID from session
                string userId = Session["user"]?.ToString();
                if (string.IsNullOrEmpty(userId))
                {
                    // No user session - hide Management Actions for security
                    ManagementActionsPanel.Visible = false;
                    return;
                }

                // Parse employee ID to integer
                if (!int.TryParse(userId, out int employeeId))
                {
                    // Invalid employee ID - hide Management Actions
                    ManagementActionsPanel.Visible = false;
                    return;
                }

                // Query database to check if employee has any Upper Board role
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    
                    // Query to get employee roles and check for Upper Board membership
                    // Using JOIN with Role table as specified in requirements
                    string query = @"
                        SELECT COUNT(*) 
                        FROM Employee_Role er
                        JOIN Role r ON er.role_name = r.role_name
                        WHERE er.emp_ID = @EmpID
                        AND (er.role_name = 'President' 
                             OR er.role_name = 'Vice President' 
                             OR er.role_name = 'Dean' 
                             OR er.role_name = 'Vice Dean')";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EmpID", employeeId);

                    int roleCount = Convert.ToInt32(cmd.ExecuteScalar());

                    // Show Management Actions section only if employee has at least one Upper Board role
                    // If roleCount > 0, employee is Upper Board member
                    ManagementActionsPanel.Visible = (roleCount > 0);
                }
            }
            catch (Exception ex)
            {
                // On error, hide the section for security (fail-safe approach)
                // This ensures that if there's any database issue, unauthorized users won't see the section
                ManagementActionsPanel.Visible = false;
                // Optionally log the error for debugging
                // System.Diagnostics.Debug.WriteLine($"Error checking role visibility: {ex.Message}");
            }
        }

        protected void logout(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("LOGIN.aspx");
        }

        // Part 1 Navigation
        protected void goToPerformance(object sender, EventArgs e) => Response.Redirect("EmployeePerformance.aspx");
        protected void goToAttendance(object sender, EventArgs e) => Response.Redirect("EmployeeAttendance.aspx");
        protected void goToPayroll(object sender, EventArgs e) => Response.Redirect("ViewPayroll.aspx");
        protected void goToDeductions(object sender, EventArgs e) => Response.Redirect("ViewDeductions.aspx");
        protected void goToApplyAnnual(object sender, EventArgs e) => Response.Redirect("ApplyAnnual.aspx");
        protected void goToLeaveStatus(object sender, EventArgs e) => Response.Redirect("ViewLeaveStatus.aspx");

        // Part 2 Navigation
        protected void goToApplyAccidental(object sender, EventArgs e) => Response.Redirect("ApplyAccidental.aspx");
        protected void goToApplyMedical(object sender, EventArgs e) => Response.Redirect("ApplyMedical.aspx");
        protected void goToApplyUnpaid(object sender, EventArgs e) => Response.Redirect("ApplyUnpaid.aspx");
        protected void goToApplyComp(object sender, EventArgs e) => Response.Redirect("ApplyCompensation.aspx");
        protected void goToManageUnpaid(object sender, EventArgs e) => Response.Redirect("ManageUnpaid.aspx");
        protected void goToManageAnnual(object sender, EventArgs e) => Response.Redirect("ManageAnnual.aspx");
        protected void goToEvaluate(object sender, EventArgs e) => Response.Redirect("EvaluateEmployee.aspx");
    }
}