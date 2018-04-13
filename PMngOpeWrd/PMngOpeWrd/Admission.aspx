<%@ Page Title="" Language="C#" MasterPageFile="~/PMng.Master" AutoEventWireup="true" CodeBehind="Admission.aspx.cs" Inherits="PMngOpeWrd.Admission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/patientExamination.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="formleftnav" runat="server">
    <div class="examination-formleftnav"></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="formHeader" runat="server">
    <h1>Patient Admission</h1>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="formleftcolumn" runat="server">
    <div class="examination-formleft"></div>
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
                    <asp:HiddenField ID="hdnIsNewAdmission" runat="server" />
                    <asp:HiddenField ID="hdnAdmissionId" runat="server" />
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
                            <asp:Label ID="lblWardNo" CssClass="control-label" runat="server" for="ddlWardNo" Text="Ward No"></asp:Label>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:DropDownList ID="ddlWardNo" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblAvailableBeds" CssClass="control-label" runat="server" for="txtAvailableBeds" Text="Available Beds"></asp:Label>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:Label ID="txtAvailableBeds" CssClass="form-control" Text="" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:Label ID="lblSurgeryNotification" Visible="true" CssClass="control-label" runat="server" for="txtComplain" Text="This Patient Registered for Surgery" ForeColor="#00CC00"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblAdmission" CssClass="control-label" runat="server" for="txtAdmission" Text="Admission Description"></asp:Label>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:TextBox ID="txtAdmission" CssClass="form-control" runat="server" MaxLength="500" TextMode="MultiLine" Rows="4"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblDischarge" CssClass="control-label" runat="server" for="txtDischarge" Text="Discharge Description"></asp:Label>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:TextBox ID="txtDischarge" CssClass="form-control" MaxLength="500" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4"></div>
                    <div class="col-md-7 button-group">
                        <asp:Button ID="btnSubmit" Enabled="false" CssClass="btn btn-primary primary-button-style" runat="server" Text="Submit Admission" OnClick="btnSubmit_Click" ValidationGroup="patientExamination" />
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
    <div class="examination-formright"></div>
</asp:Content>
