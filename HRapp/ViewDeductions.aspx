<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewDeductions.aspx.cs" Inherits="HRapp.ViewDeductions" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Deductions</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #F5F7FA;
            margin: 0;
            padding: 0;
            color: #1D1D1F;
        }
        .page-container {
            text-align: center;
            margin-top: 30px;
            padding: 20px;
        }
        .btn-home {
            background-color: #6A5BE2;
            color: white;
            border: none;
            padding: 10px 20px;
            border-radius: 4px;
            cursor: pointer;
            font-weight: 500;
            margin-bottom: 30px;
            transition: background-color 0.3s;
        }
        .btn-home:hover {
            background-color: #5A4BD2;
        }
        h2 {
            color: #1B2954;
            margin-bottom: 10px;
            font-size: 28px;
        }
        hr {
            width: 50%;
            border: none;
            border-top: 2px solid #E1E5EB;
            margin: 20px auto;
        }
        .description {
            color: #6E6E73;
            margin-bottom: 20px;
        }
        .form-section {
            margin: 20px 0;
        }
        label {
            display: inline-block;
            color: #1D1D1F;
            margin-right: 10px;
            font-weight: 500;
        }
        input[type="number"] {
            padding: 10px;
            border: 1px solid #E1E5EB;
            border-radius: 4px;
            font-size: 14px;
            width: 80px;
            margin-right: 10px;
        }
        input[type="number"]:focus {
            outline: none;
            border-color: #2A66F0;
            box-shadow: 0 0 0 2px rgba(42, 102, 240, 0.1);
        }
        .btn-view {
            background-color: #2A66F0;
            color: white;
            border: none;
            padding: 10px 20px;
            border-radius: 4px;
            cursor: pointer;
            font-weight: 500;
            transition: background-color 0.3s;
        }
        .btn-view:hover {
            background-color: #1F52C6;
        }
        .message-label {
            color: #EB5757;
            display: block;
            margin: 20px 0;
            padding: 10px;
            border-radius: 4px;
            background-color: rgba(235, 87, 87, 0.1);
        }
        .grid-container {
            display: inline-block;
            margin-top: 20px;
        }
        .grid-view {
            border: 1px solid #E1E5EB;
            border-radius: 8px;
            overflow: hidden;
            background-color: #FFFFFF;
            box-shadow: 0 2px 8px rgba(0,0,0,0.05);
        }
        .grid-view th {
            background-color: #1B2954;
            color: white;
            padding: 12px;
            font-weight: 600;
            text-align: left;
        }
        .grid-view td {
            padding: 10px;
            border-bottom: 1px solid #E1E5EB;
        }
        .grid-view tr:nth-child(even) {
            background-color: #F5F7FA;
        }
        .grid-view tr:hover {
            background-color: rgba(57, 196, 232, 0.1);
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-container">
            <asp:Button ID="btnHome" runat="server" Text="Back to Home" OnClick="goHome" CssClass="btn-home" />
            
            <h2>Attendance Deductions</h2>
            <hr />
            
            <p class="description">Please enter the month number (1-12) to view deductions caused by attendance issues.</p>

            <div class="form-section">
                <label>Month:</label>
                <asp:TextBox ID="txtMonth" runat="server" TextMode="Number" min="1" max="12"></asp:TextBox>
                <asp:Button ID="btnView" runat="server" Text="View Deductions" OnClick="viewDeductions" CssClass="btn-view" />
            </div>
            
            <asp:Label ID="lblMessage" runat="server" CssClass="message-label"></asp:Label>

            <div class="grid-container">
                <asp:GridView ID="gridDed" runat="server" 
                    AutoGenerateColumns="true" 
                    EmptyDataText="No attendance deductions found for this month."
                    CellPadding="10" 
                    GridLines="None"
                    CssClass="grid-view">
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>