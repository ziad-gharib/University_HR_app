<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoveDeductions.aspx.cs" Inherits="HRapp.RemoveDeductions" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Remove Deductions</title>
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
        .btn-remove {
            background-color: #F2C94C;
            color: #1D1D1F;
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
        .btn-remove:hover {
            background-color: #E6B93D;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-container">
            <asp:Button ID="btnHome" runat="server" Text="Back to Home" OnClick="goHome" CssClass="btn-home" />
            
            <h2>Remove Resigned Employee Deductions</h2>
            <hr />
            
            <p class="description">
                This action will permanently delete pending deductions for all employees with status 'resigned'.
            </p>

            <asp:Label ID="lblMessage" runat="server" CssClass="message-label"></asp:Label>

            <asp:Button ID="btnRemove" runat="server" Text="Remove Deductions" OnClick="removeDeductions" CssClass="btn-remove" />
        </div>
    </form>
</body>
</html>