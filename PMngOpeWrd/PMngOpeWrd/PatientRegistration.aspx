<%@ Page Title="" Language="C#" MasterPageFile="~/PMng.Master" AutoEventWireup="true" CodeBehind="PatientRegistration.aspx.cs" Inherits="PMngOpeWrd.PatientRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-md-8">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Label ID="lblFirstName" CssClass="control-label" runat="server" for="txtFirstName" Text="Fist Name"></asp:Label>
                    </div>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3"></div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Label ID="lblLastName" CssClass="control-label" runat="server" for="txtLastName" Text="Last Name"></asp:Label>
                    </div>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3"></div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Label ID="lblNIC" CssClass="control-label" runat="server" for="txtNIC" Text="NIC"></asp:Label>
                    </div>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtNIC" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3"></div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Label ID="lblAddress" CssClass="control-label" runat="server" for="txtAddress" Text="Address"></asp:Label>
                    </div>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3"></div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Label ID="lblMobilePhone" CssClass="control-label" runat="server" for="txtMobilePhone" Text="Mobile Phone"></asp:Label>
                    </div>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtMobilePhone" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3"></div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Label ID="lblLandPhone" CssClass="control-label" runat="server" for="txtLandPhone" Text="Land Phone"></asp:Label>
                    </div>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtLandPhone" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3"></div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Label ID="lblEmail" CssClass="control-label" runat="server" for="txtEmail" Text="Email"></asp:Label>
                    </div>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3"></div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Label ID="lblGender" CssClass="control-label" runat="server" for="ddlGender" Text="Gender"></asp:Label>
                    </div>
                    <div class="col-md-5">
                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                            <asp:ListItem Value="male">Male</asp:ListItem>
                            <asp:ListItem Value="female">Female</asp:ListItem>
                            <asp:ListItem Value="other">Other</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-3"></div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Label ID="lblBloodGroup" CssClass="control-label" runat="server" for="ddlBloodGroup" Text="Blood Group"></asp:Label>
                    </div>
                    <div class="col-md-5">
                        <asp:DropDownList ID="ddlBloodGroup" runat="server" CssClass="form-control">
                            <asp:ListItem Value="O+">O +</asp:ListItem>
                            <asp:ListItem Value="O-">O -</asp:ListItem>
                            <asp:ListItem Value="A+">A +</asp:ListItem>
                            <asp:ListItem Value="A-">A -</asp:ListItem>
                            <asp:ListItem Value="B+">B +</asp:ListItem>
                            <asp:ListItem Value="B-">B -</asp:ListItem>
                            <asp:ListItem Value="AB+">AB +</asp:ListItem>
                            <asp:ListItem Value="AB-">AB -</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-3"></div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Label ID="lblMaritalStatus" CssClass="control-label" runat="server" Text="Marital Status"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:Label ID="lblSingle" runat="server" for="radioStatusSingle" Text="Single"></asp:Label>
                        <asp:RadioButton ID="radioStatusSingle" runat="server" GroupName="maritalStatus" Checked="True" />
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="lblMarried" runat="server" for="radioStatusMarried" Text="Married"></asp:Label>
                        <asp:RadioButton ID="radioStatusMarried" runat="server" GroupName="maritalStatus" />
                    </div>
                    <div class="col-md-3"></div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Label ID="Label3" CssClass="control-label" runat="server" for="txtEmail" Text="Email"></asp:Label>
                    </div>
                    <div class="col-md-5">
                        <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3"></div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Label ID="lblEmergencyContact" CssClass="control-label" runat="server" for="txtEmergencyContact" Text="Emergency Contact"></asp:Label>
                    </div>
                    <div class="col-md-5">
                        <asp:TextBox ID="txtEmergencyContact" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-3"></div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-3">
                        <asp:Label ID="Label4" CssClass="control-label" runat="server" for="calenderDOB" Text="Date of Birth"></asp:Label>
                    </div>
                    <div class="col-md-5">
                        <asp:Calendar ID="calenderDOB" runat="server"></asp:Calendar>
                    </div>
                    <div class="col-md-3"></div>
                </div>
            </div>


            <div class="form-group">
                <div class="col-md-1"></div>
                <div class="col-md-3"></div>
                <div class="col-md-5">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" Text="Submit" />
                </div>
                <div class="col-md-3"></div>
            </div>
        </div>
    </div>
    <div class="col-md-4"></div>

    <div class="row"></div>
    <div class="row"></div>
</asp:Content>
