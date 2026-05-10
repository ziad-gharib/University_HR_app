<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyUnpaid.aspx.cs" Inherits="HRapp.ApplyUnpaid" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Apply for Unpaid Leave</title>
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
        .form-card {
            display: inline-block;
            text-align: left;
            border: 1px solid #E1E5EB;
            background-color: #FFFFFF;
            border-radius: 8px;
            padding: 30px;
            box-shadow: 0 2px 8px rgba(0,0,0,0.05);
            min-width: 300px;
        }
        label {
            display: block;
            color: #1D1D1F;
            margin-bottom: 8px;
            font-weight: 500;
        }
        input[type="text"], input[type="date"] {
            width: 250px;
            padding: 10px;
            border: 1px solid #E1E5EB;
            border-radius: 4px;
            font-size: 14px;
            margin-bottom: 20px;
            box-sizing: border-box;
        }
        input[type="text"]:focus, input[type="date"]:focus {
            outline: none;
            border-color: #2A66F0;
            box-shadow: 0 0 0 2px rgba(42, 102, 240, 0.1);
        }
        .btn-submit {
            background-color: #27AE60;
            color: white;
            border: none;
            padding: 12px 30px;
            font-size: 16px;
            font-weight: bold;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s;
            width: 200px;
        }
        .btn-submit:hover {
            background-color: #219A52;
        }
        .button-center {
            text-align: center;
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-container">
            <asp:Button ID="btnHome" runat="server" Text="Back to Home" OnClick="goHome" CssClass="btn-home" />
            
            <h2>Apply for Unpaid Leave</h2>
            <hr />
            
            <p class="description">Please provide the dates and attach a memo explaining the reason.</p>

            <asp:Label ID="lblMessage" runat="server" CssClass="message-label"></asp:Label>

            <div class="form-card">
                <label>Start Date:</label>
                <asp:TextBox ID="txtStart" runat="server" TextMode="Date"></asp:TextBox>

                <label>End Date:</label>
                <asp:TextBox ID="txtEnd" runat="server" TextMode="Date"></asp:TextBox>

                <label>Document Description (Memo):</label>
                <asp:TextBox ID="txtDocDesc" runat="server"></asp:TextBox>

                <label>File Name:</label>
                <asp:TextBox ID="txtFileName" runat="server"></asp:TextBox>

                <div class="button-center">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit Application" OnClick="submitLeave" CssClass="btn-submit" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
