﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PMng.Master" AutoEventWireup="true" CodeBehind="PatientRegistration.aspx.cs" Inherits="PMngOpeWrd.PatientRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Boostrap CSS -->
    <link rel="stylesheet" href="//netdna.bootstrapcdn.com/bootstrap/3.0.2/css/bootstrap.min.css" />
    <!-- Optional theme -->
    <link rel="stylesheet" href="//netdna.bootstrapcdn.com/bootstrap/3.0.2/css/bootstrap-theme.min.css" />

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" type="text/css" />
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
                        <asp:Label ID="Label4" CssClass="control-label" runat="server" for="txtDateofBirth" Text="Date of Birth"></asp:Label>
                    </div>
                    <div class="col-md-5">
                        <div class="input-group date">
                            <asp:TextBox ID="txtDateofBirth" ClientIDMode="Static" runat="server" CssClass="m-wrap span12 date form_datetime form-control" ></asp:TextBox><span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                        </div>

                    </div>
                    <div class="col-md-3"></div>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-1"></div>
                <div class="col-md-3"></div>
                <div class="col-md-5">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                </div>
                <div class="col-md-3"></div>
            </div>
        </div>
    </div>
    <div class="col-md-4"></div>

    <div class="row"></div>
    <div class="row"></div>


    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.js"></script>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.0.2/js/bootstrap.min.js"></script>
    <!-- Boostrap DatePciker JS  -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            <%--var dp = $('#<%=txtStartDate.ClientID%>');
            dp.datepicker({--%>
            $('.input-group.date').datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                language: "tr"
            }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });
        });
    </script>

</asp:Content>
