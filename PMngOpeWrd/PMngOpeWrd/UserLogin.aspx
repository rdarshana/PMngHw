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
            <asp:TextBox ID="txtUserName" name="user" runat="server" placeholder="Username" MaxLength="20"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="Please Enter User Name" ControlToValidate="txtUserName" ForeColor="Red" ValidationGroup="userLoginValidate" Font-Size="Small"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtPassword" name="pass" placeholder="Password" runat="server" TextMode="Password" MaxLength="12"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Please Enter Password" ControlToValidate="txtPassword" ForeColor="Red" ValidationGroup="userLoginValidate" Font-Size="Small"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator CssClass="error-label" Display = "Dynamic" ControlToValidate = "txtPassword" ID="regexPaasswordLength" ForeColor="Red" ValidationExpression = "^[\s\S]{5,12}$" ValidationGroup="userLoginValidate" runat="server" ErrorMessage="Minimum 5 and Maximum 12 characters required." Font-Size="Small"></asp:RegularExpressionValidator>
            <asp:Button ID="txtLogin" name="login" CssClass="login login-submit" runat="server" Text="Log in" value="login" OnClick="txtLogin_Click" ValidationGroup="userLoginValidate" Font-Size="Small" />
            <asp:Label ID="lblErrorMessage" Visible="false" CssClass="error-message" runat="server" Text=""></asp:Label>
        </form>

        <div id="errorLogin" runat="server" class="login-help">
           <a href="#">Forgotten your username or password? Please Contact Administrator</a>
        </div>

    </div>

    <script src="js/jquery-3.2.1.min.js"></script>

</body>
</html>
