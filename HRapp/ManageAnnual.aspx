<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageAnnual.aspx.cs" Inherits="HRapp.ManageAnnual" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Annual Leaves</title>
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
            max-width: 1200px;
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
            margin: 0 0 8px 0;
            font-size: 16px;
        }
        .description-text {
            color: #6E6E73;
            margin: 0 0 32px 0;
            font-size: 16px;
        }
        .message-label {
            font-weight: 600;
            display: block;
            margin: 0 auto 32px auto;
            padding: 14px 20px;
            border-radius: 8px;
            max-width: 600px;
            font-size: 15px;
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
            border: 1px solid rgba(225, 229, 235, 0.6);
            background-color: #FFFFFF;
            border-radius: 12px;
            padding: 40px 32px;
            box-shadow: 0 1px 3px rgba(0, 0, 0, 0.08), 0 1px 2px rgba(0, 0, 0, 0.06);
            min-width: 400px;
            max-width: 500px;
        }
        label {
            display: block;
            color: #1D1D1F;
            margin-bottom: 8px;
            font-weight: 500;
            font-size: 14px;
        }
        input[type="text"], input[type="date"], input[type="time"], input[type="number"], textarea, select {
            width: 100%;
            padding: 12px 16px;
            border: 1px solid #E1E5EB;
            border-radius: 8px;
            font-size: 15px;
            margin-bottom: 24px;
            transition: all 0.2s ease;
            font-family: inherit;
            box-sizing: border-box;
        }
        input[type="text"]:focus, input[type="date"]:focus, input[type="time"]:focus, input[type="number"]:focus, textarea:focus, select:focus {
            outline: none;
            border-color: #2A66F0;
            box-shadow: 0 0 0 3px rgba(42, 102, 240, 0.1);
        }
        textarea {
            resize: vertical;
            min-height: 80px;
        }
        select {
            height: 48px;
        }
        .btn-process {
            background-color: #F2C94C;
            color: #1D1D1F;
            border: none;
            padding: 14px 32px;
            font-size: 16px;
            font-weight: 600;
            border-radius: 8px;
            cursor: pointer;
            transition: all 0.2s ease;
            width: 100%;
            letter-spacing: 0.2px;
            box-shadow: 0 1px 2px rgba(242, 201, 76, 0.2);
        }
        .btn-process:hover {
            background-color: #E6B93D;
            box-shadow: 0 2px 4px rgba(242, 201, 76, 0.3);
            transform: translateY(-1px);
        }
        .btn-process:active {
            transform: translateY(0);
        }
        .button-center {
            text-align: center;
            margin-top: 8px;
        }
        @media (max-width: 768px) {
            .page-container {
                padding: 32px 20px;
            }
            h2 {
                font-size: 28px;
            }
            .form-card {
                min-width: 100%;
                padding: 32px 24px;
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
                <h2>Manage Annual Leave Requests</h2>
                <hr />
                <p class="description">
                    (For Deans, Vice-Deans, and Presidents)
                </p>
                <p class="description-text">Input the Request ID and the Replacement ID to validate and process the approval.</p>
            </div>

            <asp:Label ID="lblMessage" runat="server" CssClass="message-label"></asp:Label>

            <div style="text-align: center;">
                <div class="form-card">
                    <label>Leave Request ID:</label>
                    <asp:TextBox ID="txtRequestID" runat="server"></asp:TextBox>

                    <label>Replacement Employee ID:</label>
                    <asp:TextBox ID="txtReplacementID" runat="server"></asp:TextBox>

                    <div class="button-center">
                        <asp:Button ID="btnProcess" runat="server" Text="Process Request" OnClick="processRequest" CssClass="btn-process" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
