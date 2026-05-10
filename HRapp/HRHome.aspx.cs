using System;
namespace HRapp
{
    public partial class HRHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null) Response.Redirect("LOGIN.aspx");
            lblUser.Text = Session["user"].ToString();
        }

        protected void logout(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("LOGIN.aspx");
        }

        // Navigation Redirects
        protected void goToApproveAnnual(object sender, EventArgs e) => Response.Redirect("ApproveLeaves.aspx");
        protected void goToApproveUnpaid(object sender, EventArgs e) => Response.Redirect("ApproveUnpaid.aspx");
        protected void goToApproveComp(object sender, EventArgs e) => Response.Redirect("ApproveCompensation.aspx");

        protected void goToDedHours(object sender, EventArgs e) => Response.Redirect("DeductionMissingHours.aspx");
        protected void goToDedDays(object sender, EventArgs e) => Response.Redirect("DeductionMissingDays.aspx");
        protected void goToDedUnpaid(object sender, EventArgs e) => Response.Redirect("DeductionUnpaid.aspx");

        protected void goToGeneratePayroll(object sender, EventArgs e) => Response.Redirect("GeneratePayroll.aspx");
    }
}