<%@ Page Title="" Language="C#" MasterPageFile="~/PMng.Master" AutoEventWireup="true" CodeBehind="PatientRegistration.aspx.cs" Inherits="PMngOpeWrd.PatientRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/bootstrap-datepicker.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-md-8">
            <div class="form-horizontal">
                <asp:HiddenField ID="hdnPatientId" runat="server" />
                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-3 col-xm-12">
                        <asp:Label ID="lblFirstName" CssClass="control-label" runat="server" for="txtFirstName" Text="Fist Name"></asp:Label>
                    </div>
                    <div class="col-md-5 col-xm-12">
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
                            <asp:TextBox ID="txtDateofBirth" ClientIDMode="Static" runat="server" CssClass="m-wrap span12 date form_datetime form-control"></asp:TextBox><span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                        </div>
                    </div>
                    <div class="col-md-3"></div>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-1"></div>
                <div class="col-md-3"></div>
                <div class="col-md-5">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" Text="Register" OnClick="btnSubmit_Click" />
                    <asp:Button ID="btnDelete" CssClass="btn btn-primary" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                    <asp:Button ID="btnClear" CssClass="btn btn-primary" runat="server" Text="Clear" OnClick="btnClear_Click" />
                </div>
                <div class="col-md-3"></div>
            </div>
            <div class="form-group">
                <div class="gridview-margin">
                    <div class="col-md-1"></div>
                    <div class="col-md-11">
                        <asp:GridView ID="gridViewPatientData" CssClass="table table-striped table-bordered table-hover" PageSize="10" AllowPaging="true" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="PatientView_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                <asp:BoundField DataField="LastName" HeaderText="LastName" />
                                <%--   <asp:BoundField DataField="NIC" HeaderText="NIC" />
                                <asp:BoundField DataField="Address" HeaderText="Address" />--%>
                                <asp:BoundField DataField="MobilePhone" HeaderText="Mobile Phone" />
                                <%--<asp:BoundField DataField="LandPhone" HeaderText="Land Phone" />--%>
                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                <asp:BoundField DataField="MaritalStatus" HeaderText="Marital Status" />
                                <asp:BoundField DataField="EmergencyContact" HeaderText="Emergency Contact" />
                                <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkView" runat="server" CommandArgument='<%# Eval("PatientId") %>' OnClick="GridViewPatient_onClick">View</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <%--<div class="col-md-3"></div>--%>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-4"></div>

    <div class="row"></div>
    <div class="row"></div>


    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <!-- Boostrap DatePciker JS  -->
    <script src="js/bootstrap-datepicker.js"></script>

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
