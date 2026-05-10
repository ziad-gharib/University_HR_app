<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewLeaveStatus.aspx.cs" Inherits="HRapp.ViewLeaveStatus" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Leave Status</title>
    <style>
        * {
            box-sizing: border-box;
        }
        body {
            font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', 'Roboto', 'Helvetica Neue', Arial, sans-serif;
            background-color: #F5F7FA;
            margin: 0;
            padding: 0;
            color: #1D1D1F;
            line-height: 1.6;
            -webkit-font-smoothing: antialiased;
            -moz-osx-font-smoothing: grayscale;
        }
        .page-container {
            max-width: 1400px;
            margin: 0 auto;
            padding: 40px 32px;
        }
        .header-actions {
            margin-bottom: 32px;
        }
        .btn-home {
            background-color: #6A5BE2;
            color: #FFFFFF;
            border: none;
            padding: 12px 24px;
            border-radius: 8px;
            cursor: pointer;
            font-weight: 500;
            font-size: 15px;
            transition: all 0.2s ease;
            letter-spacing: 0.2px;
            box-shadow: 0 1px 2px rgba(106, 91, 226, 0.2);
        }
        .btn-home:hover {
            background-color: #5A4BD2;
            box-shadow: 0 2px 4px rgba(106, 91, 226, 0.3);
            transform: translateY(-1px);
        }
        .btn-home:active {
            transform: translateY(0);
        }
        .header-section {
            text-align: center;
            margin-bottom: 32px;
        }
        h2 {
            color: #1B2954;
            margin: 0 0 12px 0;
            font-size: 32px;
            font-weight: 700;
            letter-spacing: -0.5px;
        }
        hr {
            width: 80px;
            border: none;
            border-top: 3px solid #39C4E8;
            margin: 24px auto;
        }
        .description {
            font-style: italic;
            color: #6E6E73;
            margin: 0 0 32px 0;
            font-size: 16px;
        }
        .message-label {
            color: #EB5757;
            display: block;
            margin: 0 auto 32px auto;
            padding: 14px 20px;
            border-radius: 8px;
            background-color: rgba(235, 87, 87, 0.1);
            max-width: 600px;
            font-size: 15px;
            font-weight: 600;
        }
        .grid-container {
            display: flex;
            justify-content: center;
            margin-top: 32px;
        }
        .grid-view {
            border: 1px solid rgba(225, 229, 235, 0.6);
            border-radius: 12px;
            overflow: hidden;
            background-color: #FFFFFF;
            box-shadow: 0 1px 3px rgba(0, 0, 0, 0.08), 0 1px 2px rgba(0, 0, 0, 0.06);
            width: 100%;
            max-width: 1200px;
        }
        .grid-view th {
            background-color: #1B2954;
            color: #FFFFFF;
            padding: 16px;
            font-weight: 600;
            text-align: left;
            font-size: 14px;
            letter-spacing: 0.3px;
        }
        .grid-view td {
            padding: 14px 16px;
            border-bottom: 1px solid #E1E5EB;
            font-size: 14px;
        }
        .grid-view tr:last-child td {
            border-bottom: none;
        }
        .grid-view tr:nth-child(even) {
            background-color: #F5F7FA;
        }
        .grid-view tr:hover {
            background-color: rgba(57, 196, 232, 0.08);
        }
        @media (max-width: 768px) {
            .page-container {
                padding: 32px 20px;
            }
            h2 {
                font-size: 28px;
            }
            .grid-view {
                font-size: 13px;
            }
            .grid-view th,
            .grid-view td {
                padding: 12px;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-container">
            <div class="header-actions">
                <asp:Button ID="btnHome" runat="server" Text="Back to Home" OnClick="goHome" CssClass="btn-home" />
            </div>
            
            <div class="header-section">
                <h2>My Leave Requests Status</h2>
                <hr />
                <p class="description">
                    Showing Annual and Accidental leave requests submitted in the current month.
                </p>
            </div>

            <asp:Label ID="lblMessage" runat="server" CssClass="message-label"></asp:Label>

            <div class="grid-container">
                <asp:GridView ID="gridLeaves" runat="server" 
                    AutoGenerateColumns="true" 
                    EmptyDataText="No leave requests found for this month."
                    CellPadding="0" 
                    GridLines="None"
                    CssClass="grid-view">
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>