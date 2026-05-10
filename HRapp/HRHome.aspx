<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HRHome.aspx.cs" Inherits="HRapp.HRHome" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HR Dashboard</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="Content/site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="dashboard-layout">
            <!-- Top Bar -->
            <div class="top-bar">
                <h1 class="top-bar-title">HR Dashboard</h1>
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="logout" CssClass="btn-logout" />
            </div>

            <!-- Main Content -->
            <div class="main-content">
                <!-- Welcome Header -->
                <div class="welcome-header">
                    <h2 class="welcome-title">HR Employee Dashboard</h2>
                    <p class="welcome-subtitle">Welcome, HR ID: <asp:Label ID="lblUser" runat="server"></asp:Label></p>
                </div>

                <!-- Cards Container -->
                <div class="sections-grid-bottom">
                    <!-- Leave Management Card -->
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title">Leave Management</h3>
                        </div>
                        <div class="action-buttons">
                            <asp:Button ID="btnApproveAnnual" runat="server" Text="Approve Annual/Accidental" OnClick="goToApproveAnnual" CssClass="action-button" />
                            <asp:Button ID="btnApproveUnpaid" runat="server" Text="Approve Unpaid Leaves" OnClick="goToApproveUnpaid" CssClass="action-button" />
                            <asp:Button ID="btnApproveComp" runat="server" Text="Approve Compensation" OnClick="goToApproveComp" CssClass="action-button" />
                        </div>
                    </div>

                    <!-- Payroll & Deductions Card -->
                    <div class="card">
                        <div class="card-header card-header-violet">
                            <h3 class="card-title">Payroll & Deductions</h3>
                        </div>
                        <div class="action-buttons">
                            <asp:Button ID="btnDedHours" runat="server" Text="Deduction (Missing Hours)" OnClick="goToDedHours" CssClass="action-button" />
                            <asp:Button ID="btnDedDays" runat="server" Text="Deduction (Missing Days)" OnClick="goToDedDays" CssClass="action-button" />
                            <asp:Button ID="btnDedUnpaid" runat="server" Text="Deduction (Unpaid Leave)" OnClick="goToDedUnpaid" CssClass="action-button" />
                            <asp:Button ID="btnPayroll" runat="server" Text="Generate Monthly Payroll" OnClick="goToGeneratePayroll" CssClass="action-button btn-success" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>