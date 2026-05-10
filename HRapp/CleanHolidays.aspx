<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CleanHolidays.aspx.cs" Inherits="HRapp.CleanHolidays" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Clean Holiday Attendance</title>
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
            font-style: italic;
            color: #6E6E73;
            margin-bottom: 20px;
        }
        .message-label {
            font-weight: bold;
            display: block;
            margin-bottom: 20px;
            padding: 10px;
            border-radius: 4px;
        }
        .message-success {
            color: #27AE60;
            background-color: rgba(39, 174, 96, 0.1);
        }
        .message-error {
            color: #EB5757;
            background-color: rgba(235, 87, 87, 0.1);
        }
        .btn-clean {
            background-color: #EB5757;
            color: white;
            border: none;
            padding: 15px 30px;
            font-size: 16px;
            font-weight: bold;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s;
            width: 250px;
            height: 50px;
        }
        .btn-clean:hover {
            background-color: #D94A4A;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-container">
            <asp:Button ID="btnHome" runat="server" Text="Back to Home" OnClick="goHome" CssClass="btn-home" />
            
            <h2>Clean Holiday Attendance</h2>
            <hr />
            
            <p class="description">
                This action will delete any attendance records that were incorrectly logged during official holidays.
            </p>

            <asp:Label ID="lblMessage" runat="server" CssClass="message-label"></asp:Label>

            <asp:Button ID="btnClean" runat="server" Text="Clean Holiday Records" OnClick="cleanHolidays" CssClass="btn-clean" />
        </div>
    </form>
</body>
</html>
