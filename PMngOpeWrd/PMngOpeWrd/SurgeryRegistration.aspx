<%@ Page Title="" Language="C#" MasterPageFile="~/PMng.Master" AutoEventWireup="true" CodeBehind="SurgeryRegistration.aspx.cs" Inherits="PMngOpeWrd.SurgeryRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/surgery-registration.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formleftnav" runat="server">
    <div class="surgery-formleftnav"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="formHeader" runat="server">
    <h1>Surgery Registration</h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="formleftcolumn" runat="server">
    <div class="surgey-formleft"></div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="body" runat="server">
    <div class="form-body">

        <div class="row examination-search">
            <div class="form-group">
                <div class="col-md-1"></div>
                <div class="col-md-3 examination-searchfield">
                    <asp:Label ID="lblpatietId" CssClass="control-label" runat="server" for="txtPatientId" Text="PatientId"></asp:Label>
                </div>
                <div class="col-md-5 examination-searchbox">
                    <asp:TextBox ID="txtPatientId" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Label ID="lblNoPatientRecord" runat="server" ForeColor="Red"></asp:Label><br />
                </div>
                <div class="col-md-1 examination-searchbutton">
                    <span class="input-group-btn">
                        <asp:Button ID="btnSearch" CssClass="btn btn-default" runat="server" ValidationGroup="SearchPatientID" Text="Search" OnClick="btnSearch_Click" /><span class="glyphicon glyphicon-search"></span>
                    </span>
                </div>
                <div class="col-md-2">
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-9">
                <div class="form-horizontal">
                    <asp:HiddenField ID="hdnIsNewExamine" runat="server" />
                    <asp:HiddenField ID="hdnExamineId" runat="server" />
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblNIC" CssClass="control-label" runat="server" for="txtNIC" Text="NIC"></asp:Label>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:TextBox ID="txtNIC" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblFirstName" CssClass="control-label" runat="server" for="txtFirstName" Text="First Name"></asp:Label>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:TextBox ID="txtFirstName" Enabled="false" CssClass="form-control" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblLastName" CssClass="control-label" runat="server" for="txtLastName" Text="Last Name"></asp:Label>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:TextBox ID="txtLastName" Enabled="false" CssClass="form-control" MaxLength="50" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblDoctor" CssClass="control-label" runat="server" for="ddlDoctors" Text="Doctorr"></asp:Label>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:DropDownList ID="ddlDoctors" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblWardNo" CssClass="control-label" runat="server" for="ddlWardNo" Text="Ward No"></asp:Label>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:DropDownList ID="ddlWardNo" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblAdmissionDate" CssClass="control-label" runat="server" for="txtAdmissionDate" Text="Admission Date"></asp:Label>
                            <span class="required-field-star">*</span>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:TextBox ID="txtAdmissionDate" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAdmissionDate" runat="server" ErrorMessage="This field is required" ControlToValidate="txtAdmissionDate" ValidationGroup="patientAdmission" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblSurgeryDescription" CssClass="control-label" runat="server" for="txtSurgeryDescription" Text="Surgery Description"></asp:Label>
                            <span class="required-field-star">*</span>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:TextBox ID="txtSurgeryDescription" CssClass="form-control" runat="server" MaxLength="500" TextMode="MultiLine" Rows="4"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblDiagnosis" CssClass="control-label" runat="server" for="txtSurgeryDate" Text="Surgery Date"></asp:Label>
                            <span class="required-field-star">*</span>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:TextBox ID="txtSurgeryDate" CssClass="form-control" MaxLength="10" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblTheators" CssClass="control-label" runat="server" for="ddlTheators" Text="Thetors"></asp:Label>
                        </div>
                        <div class="col-md-5 col-xm-12">
                            <asp:DropDownList ID="ddlTheators" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnSearchTheator" Width="25px" CssClass="form-control" runat="server" Text="Search Availability" />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="gridview-search-margin">
                            <div class="row gridview-margin">
                                <div class="col-md-1"></div>
                                <div class="col-md-11">
                                    <asp:GridView ID="gridViewPatientRegistration" CssClass="table table-striped table-bordered table-hover" PageSize="10" AllowPaging="true" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="gridViewSurgeryRegistration_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="SurgeryID" HeaderText="Surgery ID" />
                                            <asp:BoundField DataField="SurgeryDate" HeaderText="Surgery Date" />
                                            <asp:BoundField DataField="Doctor" HeaderText="Doctor" />
                                            <asp:TemplateField HeaderText="Desctiption">
                                                <ItemTemplate>
                                                    <%# ((string)Eval("Complain")).Length < 20? Eval("Complain") :((string)Eval("Description")).Substring(0,20) + "..."%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="linkView" runat="server" CommandArgument='<%# Eval("SurgeryID") %>' OnClick="gridViewSurgeryData_onClick">View</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9 info-mzg">
                            <div id="grdDisplayMessage" class="alert alert-info" style="display: none" runat="server">
                                There are no records to show
                            </div>
                        </div>
                        <div class="col-md-2"></div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4"></div>
                    <div class="col-md-7 button-group">
                        <asp:Button ID="btnSubmit" Enabled="false" CssClass="btn btn-primary primary-button-style" runat="server" Text="Add" OnClick="btnSubmit_Click" ValidationGroup="patientExamination" />
                        <asp:Button ID="btnClear" CssClass="btn btn-primary primary-button-style" runat="server" Text="Clear" OnClick="btnClear_Click" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-5"></div>
                    <div class="col-md-7">
                        <div class="button-status">
                            <asp:Label ID="lblSuccess" runat="server" ForeColor="Green" Text=""></asp:Label>
                            <asp:Label ID="lblFail" runat="server" ForeColor="Red" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-3"></div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="formrightcolumn" runat="server">
    <div class="surgery-formright"></div>
</asp:Content>
