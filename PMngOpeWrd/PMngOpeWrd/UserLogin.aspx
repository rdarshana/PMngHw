<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="PMngOpeWrd.UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log-in</title>
    <link href="css/userlogin.css" rel="stylesheet" />
</head>
<body>

    <div class="login-card">
        <img class="login-logo" src="images/logoLH.png" />
        <h1>Log-in</h1>
        <br />
        <form runat="server">
            <label class="context">Sign in with your organizational account</label>
            <asp:TextBox ID="txtUserName" name="user" runat="server" placeholder="Username"></asp:TextBox>
            <asp:TextBox ID="txtPassword" name="pass" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Button ID="txtLogin" name="login" CssClass="login login-submit" runat="server" Text="Log in" value="login" OnClick="txtLogin_Click" />
            <asp:Label ID="lblErrorMessage" CssClass="error-message" runat="server" Text="Invalid login, please try again"></asp:Label>
        </form>

        <div id="errorLogin" runat="server" class="login-help">
           <a href="#">Forgotten your username or password? Please Contact Administrator</a>
        </div>

    </div>

    <script src="js/jquery-3.2.1.min.js"></script>

</body>
</html>
