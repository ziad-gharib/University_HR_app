<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AcademicHome.aspx.cs" Inherits="HRapp.AcademicHome" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Academic Home</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="Content/site.css" rel="stylesheet" type="text/css" />
    <style>
        /* Page-specific styles if needed */
        .welcome-text asp\:label {
            color: #1B2954;
            font-weight: 600;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="dashboard-layout">
            <!-- Top Bar -->
            <div class="top-bar">
                <h1 class="top-bar-title">Academic Dashboard</h1>
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="logout" CssClass="btn-logout" />
            </div>

            <!-- Main Content -->
            <div class="main-content">
                <!-- Welcome Header -->
                <div class="welcome-header">
                    <h2 class="welcome-title">Academic Employee Dashboard</h2>
                    <p class="welcome-subtitle">Welcome, ID: <asp:Label ID="lblUser" runat="server"></asp:Label></p>
                </div>

                <!-- Sections Grid -->
                <div class="sections-grid">
                    <!-- My Data - Full Width -->
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title">My Data</h3>
                        </div>
                        <div class="action-buttons">
                            <asp:Button ID="btnPerf" runat="server" Text="View Performance" OnClick="goToPerformance" CssClass="action-button" />
                            <asp:Button ID="btnAtt" runat="server" Text="View Attendance" OnClick="goToAttendance" CssClass="action-button" />
                            <asp:Button ID="btnPayroll" runat="server" Text="View Payroll" OnClick="goToPayroll" CssClass="action-button" />
                            <asp:Button ID="btnDed" runat="server" Text="View Deductions" OnClick="goToDeductions" CssClass="action-button" />
                            <asp:Button ID="btnLeaveStatus" runat="server" Text="View Leave Status" OnClick="goToLeaveStatus" CssClass="action-button" />
                        </div>
                    </div>

                    <!-- Bottom Sections - Two Columns -->
                    <div class="sections-grid-bottom">
                        <!-- Submit Requests Card -->
                        <div class="card">
                            <div class="card-header card-header-violet">
                                <h3 class="card-title">Submit Requests</h3>
                            </div>
                            <div class="action-buttons">
                                <asp:Button ID="btnAnnual" runat="server" Text="Apply for Annual Leave" OnClick="goToApplyAnnual" CssClass="action-button btn-success" />
                                <asp:Button ID="btnAccidental" runat="server" Text="Apply for Accidental Leave" OnClick="goToApplyAccidental" CssClass="action-button" />
                                <asp:Button ID="btnMedical" runat="server" Text="Apply for Medical Leave" OnClick="goToApplyMedical" CssClass="action-button" />
                                <asp:Button ID="btnUnpaid" runat="server" Text="Apply for Unpaid Leave" OnClick="goToApplyUnpaid" CssClass="action-button" />
                                <asp:Button ID="btnComp" runat="server" Text="Apply for Compensation" OnClick="goToApplyComp" CssClass="action-button" />
                            </div>
                        </div>

                        <!-- Management Actions Card - Visible only to Upper Board Members -->
                        <asp:Panel ID="ManagementActionsPanel" runat="server">
                            <div class="card">
                                <div class="card-header">
                                    <h3 class="card-title">Management Actions</h3>
                                </div>
                                <div class="action-buttons">
                                    <asp:Button ID="btnMngUnpaid" runat="server" Text="Manage Unpaid Leaves" OnClick="goToManageUnpaid" CssClass="action-button btn-warning" />
                                    <asp:Button ID="btnMngAnnual" runat="server" Text="Manage Annual Leaves" OnClick="goToManageAnnual" CssClass="action-button btn-warning" />
                                    <asp:Button ID="btnEval" runat="server" Text="Evaluate Employees" OnClick="goToEvaluate" CssClass="action-button btn-warning" />
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
