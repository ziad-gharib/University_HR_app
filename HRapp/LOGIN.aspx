<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LOGIN.aspx.cs" Inherits="HRapp.LOGIN" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HR System Login</title>
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
        .login-container {
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            padding: 40px 20px;
        }
        .login-card {
            background-color: #FFFFFF;
            border: 1px solid rgba(225, 229, 235, 0.6);
            border-radius: 12px;
            padding: 48px 40px;
            box-shadow: 0 1px 3px rgba(0, 0, 0, 0.08), 0 1px 2px rgba(0, 0, 0, 0.06);
            width: 100%;
            max-width: 420px;
        }
        h2 {
            color: #1B2954;
            margin: 0 0 32px 0;
            font-size: 32px;
            font-weight: 700;
            letter-spacing: -0.5px;
            text-align: center;
        }
        label {
            display: block;
            text-align: left;
            color: #1D1D1F;
            margin-bottom: 8px;
            font-weight: 500;
            font-size: 14px;
        }
        input[type="text"], input[type="password"] {
            width: 100%;
            padding: 12px 16px;
            border: 1px solid #E1E5EB;
            border-radius: 8px;
            font-size: 15px;
            box-sizing: border-box;
            margin-bottom: 24px;
            transition: all 0.2s ease;
            font-family: inherit;
        }
        input[type="text"]:focus, input[type="password"]:focus {
            outline: none;
            border-color: #2A66F0;
            box-shadow: 0 0 0 3px rgba(42, 102, 240, 0.1);
        }
        .btn-login {
            background-color: #2A66F0;
            color: #FFFFFF;
            border: none;
            padding: 14px 32px;
            font-size: 16px;
            font-weight: 600;
            border-radius: 8px;
            cursor: pointer;
            transition: all 0.2s ease;
            width: 100%;
            letter-spacing: 0.2px;
            box-shadow: 0 1px 2px rgba(42, 102, 240, 0.2);
        }
        .btn-login:hover {
            background-color: #1F52C6;
            box-shadow: 0 2px 4px rgba(42, 102, 240, 0.3);
            transform: translateY(-1px);
        }
        .btn-login:active {
            transform: translateY(0);
        }
        .error-message {
            color: #EB5757;
            margin-bottom: 24px;
            display: block;
            font-size: 14px;
            padding: 12px;
            background-color: rgba(235, 87, 87, 0.1);
            border-radius: 8px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <div class="login-card">
                <h2>HR System Login</h2>
                <asp:Label ID="lblMessage" runat="server" CssClass="error-message"></asp:Label>
                
                <label>ID:</label>
                <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                
                <label>Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="login" CssClass="btn-login" />
            </div>
        </div>
    </form>
</body>
</html>
