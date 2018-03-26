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
      <h1>Log-in</h1><br/>
      <form>
        <label class="context">Sign in with your organizational account</label>
        <input type="text" name="user" placeholder="Username"/>
        <input type="password" name="pass" placeholder="Password"/>
        <input type="submit" name="login" class="login login-submit" value="login"/>
      </form>
    
      <div class="login-help">
<%--        <a href="#">Register</a> • <a href="#">Forgot Password</a>--%>
      </div>

    </div>
        
    <script src="js/jquery-3.2.1.min.js"></script>

</body>
</html>
