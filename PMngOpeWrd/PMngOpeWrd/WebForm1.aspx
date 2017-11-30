<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PMngOpeWrd.WebForm1" MasterPageFile="~/PMng.Master" %>


    <asp:Content ID="content1" ContentPlaceHolderID="body" runat="server">
        <asp:Login ID="Login1" runat="server"></asp:Login>
        <asp:ChangePassword ID="ChangePassword1" runat="server"></asp:ChangePassword>
        <asp:LoginView ID="LoginView1" runat="server"></asp:LoginView>
    <div>
        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server"></asp:PasswordRecovery>
        <asp:LoginStatus ID="LoginStatus1" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </div>
           <script src="js/jquery-3.2.1.min.js"></script>
    </asp:Content>



