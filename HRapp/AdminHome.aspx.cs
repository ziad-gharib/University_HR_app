using System;
namespace HRapp
{
    public partial class AdminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("LOGIN.aspx");
        }

        protected void logout(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("LOGIN.aspx");
        }

        // Navigation Redirects
        protected void goToProfiles(object sender, EventArgs e) => Response.Redirect("ViewProfiles.aspx");
        protected void goToDeptStats(object sender, EventArgs e) => Response.Redirect("DepartmentStats.aspx");
        protected void goToRejected(object sender, EventArgs e) => Response.Redirect("RejectedLeaves.aspx");
        protected void goToViewAttendance(object sender, EventArgs e) => Response.Redirect("ViewAttendance.aspx");
        protected void goToPerformance(object sender, EventArgs e) => Response.Redirect("ViewPerformance.aspx");
        protected void goToAddHoliday(object sender, EventArgs e) => Response.Redirect("AddHoliday.aspx");
        protected void goToUpdateAttendance(object sender, EventArgs e) => Response.Redirect("UpdateAttendance.aspx");
        protected void goToReplace(object sender, EventArgs e) => Response.Redirect("ReplaceEmployee.aspx");
        protected void goToInit(object sender, EventArgs e) => Response.Redirect("InitiateAttendance.aspx");
        // --- NEW REDIRECTS FOR MISSING TASKS ---
        // Part 1 #5
        protected void goToRemoveResignedDeductions(object sender, EventArgs e) => Response.Redirect("RemoveDeductions.aspx");

        // Part 2 #3
        protected void goToCleanHolidays(object sender, EventArgs e) => Response.Redirect("CleanHolidays.aspx");

        // Part 2 #4
        protected void goToRemoveDayOff(object sender, EventArgs e) => Response.Redirect("RemoveDayOff.aspx");

        // Part 2 #5
        protected void goToRemoveApprovedLeaves(object sender, EventArgs e) => Response.Redirect("RemoveApprovedLeaves.aspx");

        // Part 2 #7
        protected void goToUpdateStatus(object sender, EventArgs e) => Response.Redirect("UpdateStatus.aspx");
    }
}

