﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PMng.Master" AutoEventWireup="true" CodeBehind="PatientRegistration.aspx.cs" Inherits="PMngOpeWrd.PatientRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/bootstrap-datepicker.css" rel="stylesheet" />
<link href="css/main.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="ContentFormHeader" ContentPlaceHolderID="formHeader" runat="server">
    <div runat="server" id="divPatientRegistration"><h1>Patient Registration</h1></div>
     <div runat="server" visible="false" id="divPatientUpdate"><h1>Patient Update</h1></div>
</asp:Content>

<asp:Content ID="patientregLeftnav" ContentPlaceHolderID="formleftnav" runat="server">
   <div class="patirnt-reg-formleftnav"></div>
</asp:Content>

<asp:Content ID="patientLeftColumn" ContentPlaceHolderID="formleftcolumn" runat="server">
    <div class="patirnt-reg-formleft"></div>
</asp:Content>

<asp:Content ID="patientRightColumn" ContentPlaceHolderID="formrightcolumn" runat="server">
    <div class="patirnt-reg-formright"></div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="row form-body">
        <div class="col-md-9">
            <div class="form-horizontal">
                <asp:HiddenField ID="hdnIsNewPatient" runat="server" />

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4 col-xm-12">
                        <asp:Label ID="lblPatientId" CssClass="control-label" runat="server" for="txtPatientId" Text="Patient ID"></asp:Label>
                    </div>
                    <div class="col-md-7 col-xm-12">
                        <asp:TextBox ID="txtPatientId" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4 col-xm-12">
                        <asp:Label ID="lblFirstName" CssClass="control-label" runat="server" for="txtFirstName" Text="Fist Name"></asp:Label>
                        <span class="required-field-star">*</span>
                    </div>
                    <div class="col-md-7 col-xm-12">
                        <asp:TextBox ID="txtFirstName" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="This field is required" ControlToValidate="txtFirstName" ValidationGroup="patientRegistration" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4">
                        <asp:Label ID="lblLastName" CssClass="control-label" runat="server" for="txtLastName" Text="Last Name"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4">
                        <asp:Label ID="lblNIC" CssClass="control-label" runat="server" for="txtNIC" Text="NIC"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtNIC" CssClass="form-control" MaxLength="10" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid NIC Format" ControlToValidate="txtNIC" ValidationGroup="patientRegistration" ForeColor="Red" ValidationExpression="\d{9}[v|V]"></asp:RegularExpressionValidator>
                        <br/>
                        <asp:Label ID="lblNICInValid" runat="server" ForeColor="Red"></asp:Label><br />
                    </div>
                </div>

                 <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4">
                        <asp:Label ID="lblGender" CssClass="control-label" runat="server" for="ddlGender" Text="Gender"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                            <asp:ListItem Value="male">Male</asp:ListItem>
                            <asp:ListItem Value="female">Female</asp:ListItem>
                            <asp:ListItem Value="other">Other</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4">
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
                    <div class="col-md-2"></div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4">
                        <asp:Label ID="Label4" CssClass="control-label" runat="server" for="txtDateofBirth" Text="Date of Birth"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <div class="input-group date">
                            <asp:TextBox ID="txtDateofBirth" MaxLength="10" ClientIDMode="Static" runat="server" CssClass="m-wrap span12 date form_datetime form-control"></asp:TextBox><span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4">
                        <asp:Label ID="lblBloodGroup" CssClass="control-label" runat="server" for="ddlBloodGroup" Text="Blood Group"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="ddlBloodGroup" runat="server" CssClass="form-control">
                            <asp:ListItem Value="default">-- Please Select --</asp:ListItem>
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
                </div>
                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4">
                        <asp:Label ID="lblAddress" CssClass="control-label" runat="server" for="txtAddress" Text="Address"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtAddress" MaxLength="200" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4">
                        <asp:Label ID="lblMobilePhone" CssClass="control-label" runat="server" for="txtMobilePhone" Text="Mobile Phone"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtMobilePhone" MaxLength="10" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rxvMobilePhone" runat="server" ErrorMessage="Invalid Phone Number" ControlToValidate="txtMobilePhone" ValidationGroup="patientRegistration" ForeColor="Red" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4">
                        <asp:Label ID="lblLandPhone" CssClass="control-label" runat="server" for="txtLandPhone" Text="Land Phone"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtLandPhone" MaxLength="10" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rexLandPhone" runat="server" ErrorMessage="Invalid Phone Number" ControlToValidate="txtLandPhone" ValidationGroup="patientRegistration" ForeColor="Red" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4">
                        <asp:Label ID="lblEmail" CssClass="control-label" runat="server" for="txtEmail" Text="Email"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtEmail" MaxLength="100" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="refEmail" runat="server" ControlToValidate="txtEmail" ValidationGroup="patientRegistration" ForeColor="Red" ErrorMessage="Invalid Email format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                </div>

               

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4">
                        <asp:Label ID="lblgardianName" CssClass="control-label" runat="server" for="txtGardianName" Text="Name of the Guardian"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtGardianName" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4">
                        <asp:Label ID="Label1" CssClass="control-label" runat="server" for="txtGardianAddress" Text="Address of the Guardian "></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtGardianAddress" MaxLength="250" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4">
                        <asp:Label ID="lblEmergencyContact" CssClass="control-label" runat="server" for="txtEmergencyContact" Text="Contact of the Guardian"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtEmergencyContact" MaxLength="20" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Phone Number" ControlToValidate="txtEmergencyContact" ValidationGroup="patientRegistration" ForeColor="Red" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                    </div>
                </div>

            </div>
            <div class="form-group">
                <div class="col-md-1"></div>
                <div class="col-md-4"></div>
                <div class="col-md-7 button-group">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary primary-button-style" runat="server" Text="Register" OnClick="btnSubmit_Click" ValidationGroup="patientRegistration" />
                    <asp:Button ID="btnDelete" CssClass="btn btn-primary primary-button-style" runat="server" Visible="false" Text="Delete" OnClick="btnDelete_Click" />
                    <asp:Button ID="btnClear" CssClass="btn btn-primary primary-button-style" runat="server" Text="Clear" OnClick="btnClear_Click" />
                </div>

            </div>
            <div class="form-group">
                <div class="col-md-4"></div>
                <div class="col-md-8    ">
                    <div class="button-status">
                        <asp:Label ID="lblSuccess" runat="server" ForeColor="Green" Text=""></asp:Label>
                        <asp:Label ID="lblFail" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-3"></div>
    </div>

    <div class="row"></div>
    <div class="row"></div>


    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <!-- Boostrap DatePciker JS  -->
    <script src="js/bootstrap-datepicker.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('.input-group.date').datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                language: "tr",
                endDate: '+0d'
            }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });
        });
    </script>

</asp:Content>
