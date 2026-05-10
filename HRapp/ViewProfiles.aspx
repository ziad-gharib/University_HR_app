<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewProfiles.aspx.cs" Inherits="HRapp.ViewProfiles" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Profiles</title>
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
            max-width: 100%;
            margin: 0 auto;
            padding: 20px 16px;
        }
        .header-actions {
            margin-bottom: 20px;
        }
        .btn-home {
            background-color: #6A5BE2;
            color: #FFFFFF;
            border: none;
            padding: 10px 20px;
            border-radius: 8px;
            cursor: pointer;
            font-weight: 500;
            font-size: 14px;
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
            margin-bottom: 20px;
        }
        h2 {
            color: #1B2954;
            margin: 0 0 8px 0;
            font-size: 28px;
            font-weight: 700;
            letter-spacing: -0.5px;
        }
        hr {
            width: 80px;
            border: none;
            border-top: 3px solid #39C4E8;
            margin: 16px auto;
        }
        .grid-container {
            width: 100%;
            overflow-x: auto;
            margin-top: 20px;
        }
        .grid-view {
            border: 1px solid rgba(225, 229, 235, 0.6);
            border-radius: 12px;
            overflow: hidden;
            background-color: #FFFFFF;
            box-shadow: 0 1px 3px rgba(0, 0, 0, 0.08), 0 1px 2px rgba(0, 0, 0, 0.06);
            width: 100%;
            min-width: 100%;
            table-layout: fixed;
        }
        .grid-view th {
            background-color: #1B2954;
            color: #FFFFFF;
            padding: 10px 8px;
            font-weight: 600;
            text-align: left;
            font-size: 12px;
            letter-spacing: 0.2px;
            white-space: nowrap;
            overflow: hidden;
            text-overflow: ellipsis;
        }
        .grid-view td {
            padding: 10px 8px;
            border-bottom: 1px solid #E1E5EB;
            font-size: 12px;
            white-space: nowrap;
            overflow: hidden;
            text-overflow: ellipsis;
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
                padding: 16px 12px;
            }
            h2 {
                font-size: 24px;
            }
            .grid-view th,
            .grid-view td {
                padding: 8px 6px;
                font-size: 11px;
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
                <h2>All Employee Profiles</h2>
                <hr />
            </div>

            <div class="grid-container">
                <asp:GridView ID="gridProfiles" runat="server" AutoGenerateColumns="true" EmptyDataText="No records found" CssClass="grid-view" GridLines="None" CellPadding="0"></asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>