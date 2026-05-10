<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="HRapp.AdminHome" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Home</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="Content/site.css" rel="stylesheet" type="text/css" />
    <style>
        /* Page-specific overrides if needed */
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="dashboard-layout">
            <!-- Top Bar -->
            <div class="top-bar">
                <h1 class="top-bar-title">Admin Dashboard</h1>
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="logout" CssClass="btn-logout" />
            </div>

            <!-- Main Content -->
            <div class="main-content">
                <!-- Welcome Header -->
                <div class="welcome-header">
                    <h2 class="welcome-title">Welcome Admin</h2>
                    <p class="welcome-subtitle">Please select a task:</p>
                </div>

                <!-- Sections Grid -->
                <div class="sections-grid">
                    <!-- Maintenance Actions - Grid of Action Cards -->
                    <div class="card">
                        <div class="card-header">
                            <h3 class="card-title">Maintenance Actions</h3>
                        </div>
                        <div class="action-cards-grid">
                            <div class="action-card">
                                <asp:Button ID="btnInit" runat="server" Text="Initiate Daily Attendance" OnClick="goToInit" CssClass="action-card-button" />
                            </div>
                            <div class="action-card">
                                <asp:Button ID="btnRemResignedDed" runat="server" Text="Remove Resigned Deductions" OnClick="goToRemoveResignedDeductions" CssClass="action-card-button" />
                            </div>
                            <div class="action-card">
                                <asp:Button ID="btnCleanHolidays" runat="server" Text="Clean Holiday Attendance" OnClick="goToCleanHolidays" CssClass="action-card-button" />
                            </div>
                            <div class="action-card">
                                <asp:Button ID="btnRemDayOff" runat="server" Text="Remove Day-Off Attendance" OnClick="goToRemoveDayOff" CssClass="action-card-button" />
                            </div>
                            <div class="action-card">
                                <asp:Button ID="btnRemLeaves" runat="server" Text="Remove Approved Leaves" OnClick="goToRemoveApprovedLeaves" CssClass="action-card-button" />
                            </div>
                            <div class="action-card">
                                <asp:Button ID="btnUpdateStatus" runat="server" Text="Update Employment Status" OnClick="goToUpdateStatus" CssClass="action-card-button" />
                            </div>
                        </div>
                    </div>

                    <!-- Bottom Sections - Two Columns -->
                    <div class="sections-grid-bottom">
                        <!-- View Data Card -->
                        <div class="card">
                            <div class="card-header card-header-violet">
                                <h3 class="card-title">View Data</h3>
                            </div>
                            <div class="action-buttons">
                                <asp:Button ID="btnProfiles" runat="server" Text="View All Employee Profiles" OnClick="goToProfiles" CssClass="action-button" />
                                <asp:Button ID="btnDeptStats" runat="server" Text="Department Statistics" OnClick="goToDeptStats" CssClass="action-button" />
                                <asp:Button ID="btnRejected" runat="server" Text="View Rejected Medical Leaves" OnClick="goToRejected" CssClass="action-button" />
                                <asp:Button ID="btnViewAtt" runat="server" Text="View Yesterday's Attendance" OnClick="goToViewAttendance" CssClass="action-button" />
                                <asp:Button ID="btnPerf" runat="server" Text="View Employee Performance" OnClick="goToPerformance" CssClass="action-button" />
                            </div>
                        </div>

                        <!-- Manage Operations Card -->
                        <div class="card">
                            <div class="card-header">
                                <h3 class="card-title">Manage Operations</h3>
                            </div>
                            <div class="action-buttons">
                                <asp:Button ID="btnAddHoliday" runat="server" Text="Add New Holiday" OnClick="goToAddHoliday" CssClass="action-button" />
                                <asp:Button ID="btnUpdAtt" runat="server" Text="Update Attendance Record" OnClick="goToUpdateAttendance" CssClass="action-button" />
                                <asp:Button ID="btnReplace" runat="server" Text="Replace Employee" OnClick="goToReplace" CssClass="action-button" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
