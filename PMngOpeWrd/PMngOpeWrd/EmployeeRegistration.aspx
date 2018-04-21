<%@ Page Title="" Language="C#" MasterPageFile="~/PMng.Master" AutoEventWireup="true" CodeBehind="EmployeeRegistration.aspx.cs" Inherits="PMngOpeWrd.EmployeeRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/main.css" rel="stylesheet" />
    <link href="css/employee.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="employeeRegLeftNav" ContentPlaceHolderID="formleftnav" runat="server">
    <div class="employee-reg-formleftnav"></div>
</asp:Content>


<asp:Content ID="employeeRegHeader" ContentPlaceHolderID="formHeader" runat="server">
    <div runat="server" id="divEmployeeRegistration">
        <h1>Employee Registration</h1>
    </div>
    <div runat="server" visible="false" id="divEmployeeUpdate">
        <h1>Employee Update</h1>
    </div>
</asp:Content>

<asp:Content ID="employeeRegLefttCol" ContentPlaceHolderID="formleftcolumn" runat="server">
    <div class="employee-reg-formleft"></div>
</asp:Content>

<asp:Content ID="employeeRegbody" ContentPlaceHolderID="body" runat="server">
    <div class="row form-body">
        <div class="col-md-9">
            <div class="form-horizontal">
                <asp:HiddenField ID="hdnIsNewEmployee" runat="server" />

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4">
                        <asp:Label ID="lblEmployeeType" CssClass="control-label" runat="server" for="ddlEmployeeType" Text="Employee Type"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="ddlEmployeeType" runat="server" CssClass="form-control">
                            <asp:ListItem Value="administrator">Administrator</asp:ListItem>
                            <asp:ListItem Value="anesthetist">Anesthetist</asp:ListItem>
                            <asp:ListItem Value="director">Director</asp:ListItem>
                            <asp:ListItem Value="doctor">Doctor</asp:ListItem>
                          <%--  <asp:ListItem Value="mlt">MLT</asp:ListItem>--%>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4 col-xm-12">
                        <asp:Label ID="lblEmployeeId" CssClass="control-label" runat="server" for="txtEmployeeId" Text="Employee ID"></asp:Label>
                    </div>
                    <div class="col-md-7 col-xm-12">
                        <asp:TextBox ID="txtEmployeeId" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4 col-xm-12">
                        <asp:Label ID="lblFirstName" CssClass="control-label" runat="server" for="txtFirstName" Text="Fist Name"></asp:Label>
                        <span class="required-field-star">*</span>
                    </div>
                    <div class="col-md-7 col-xm-12">
                        <asp:TextBox ID="txtFirstName" CssClass="form-control" MaxLength="50" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="This field is required" ControlToValidate="txtFirstName" ValidationGroup="employeeRegistration" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4">
                        <asp:Label ID="lblLastName" CssClass="control-label" runat="server" for="txtLastName" Text="Last Name"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtLastName" CssClass="form-control" MaxLength="50" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4 col-xm-12">
                        <asp:Label ID="lblPassword" CssClass="control-label" runat="server" for="pwdPassword" Text="Password"></asp:Label>
                    </div>
                    <div class="col-md-7 col-xm-12">
                        <asp:TextBox ID="pwdPassword" TextMode="Password" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4 col-xm-12">
                        <asp:Label ID="lblConfirmPassword" CssClass="control-label" runat="server" for="pwdConfirmPassword" Text="Confirm Password"></asp:Label>
                    </div>
                    <div class="col-md-7 col-xm-12">
                        <asp:TextBox ID="pwdConfirmPassword" TextMode="Password" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="passwordCompareValidator" runat="server" ValidationGroup="employeeRegistration" ForeColor="Red" ErrorMessage="The Password you entered do not matched. Please Re-enteryour Password" ControlToValidate="pwdConfirmPassword" ControlToCompare="pwdPassword"></asp:CompareValidator>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4">
                        <asp:Label ID="lblNIC" CssClass="control-label" runat="server" for="txtNIC" Text="NIC"></asp:Label>
                        <span class="required-field-star">*</span>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtNIC" CssClass="form-control" MaxLength="10" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNIC" runat="server" ErrorMessage="This field is required" ControlToValidate="txtNIC" ValidationGroup="employeeRegistration" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid NIC Format" ControlToValidate="txtNIC" ValidationGroup="employeeRegistration" ForeColor="Red" ValidationExpression="\d{9}[v|V]"></asp:RegularExpressionValidator>
                        <br/>
                        <asp:Label ID="lblNICInValid" runat="server" ForeColor="Red"></asp:Label><br />
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4">
                        <asp:Label ID="lblAddress" CssClass="control-label" runat="server" for="txtAddress" Text="Address"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtAddress" CssClass="form-control" MaxLength="200" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4">
                        <asp:Label ID="lblMobilePhone" CssClass="control-label" runat="server" for="txtMobilePhone" Text="Mobile Phone"></asp:Label>

                         <span class="required-field-star">*</span>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtMobilePhone" MaxLength="10" CssClass="form-control" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="reqMobilePhone" runat="server" ErrorMessage="This field is required" ControlToValidate="txtMobilePhone" ValidationGroup="employeeRegistration" ForeColor="Red"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="rxvMobilePhone" runat="server" ErrorMessage="Invalid Phone Number" ControlToValidate="txtMobilePhone" ValidationGroup="employeeRegistration" ForeColor="Red" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4">
                        <asp:Label ID="lblLandPhone" CssClass="control-label" runat="server" for="txtLandPhone" Text="Land Phone"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtLandPhone" MaxLength="10" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rexLandPhone" runat="server" ErrorMessage="Invalid Phone Number" ControlToValidate="txtLandPhone" ValidationGroup="employeeRegistration" ForeColor="Red" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4">
                        <asp:Label ID="lblEmail" CssClass="control-label" runat="server" for="txtEmail" Text="Email"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtEmail" MaxLength="100" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="refEmail" runat="server" ControlToValidate="txtEmail" ValidationGroup="employeeRegistration" ForeColor="Red" ErrorMessage="Invalid Email format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4">
                        <asp:Label ID="lblIsActive" CssClass="control-label" runat="server" for="chkIsActive" Text="Is Active"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:CheckBox ID="chkIsActive" CssClass="form-check-input" runat="server" Checked="True" />
                    </div>
                </div>

            </div>

            <div class="form-group">
                <div class="col-md-1"></div>
                <div class="col-md-4"></div>
                <div class="col-md-7 button-group">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary primary-button-style" runat="server" Text="Register" OnClick="btnSubmit_Click" ValidationGroup="employeeRegistration" />
                    <asp:Button ID="btnDelete" CssClass="btn btn-primary primary-button-style" Visible="false" runat="server" Text="Delete" OnClick="btnDelete_Click" />
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
</asp:Content>

<asp:Content ID="employeeRegRightCol" ContentPlaceHolderID="formrightcolumn" runat="server">
    <div class="employee-reg-formright"></div>
</asp:Content>
