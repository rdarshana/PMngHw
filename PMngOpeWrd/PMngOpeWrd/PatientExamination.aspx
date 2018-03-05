<%@ Page Title="" Language="C#" MasterPageFile="~/PMng.Master" AutoEventWireup="true" CodeBehind="PatientExamination.aspx.cs" Inherits="PMngOpeWrd.PatientExamination" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/patientExamination.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="formleftnav" runat="server">
     <div class="examination-formleftnav"></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="formHeader" runat="server">
    <h1>Patient Examintion</h1>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="formleftcolumn" runat="server">
        <div class="examination-formleft"></div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="body" runat="server">
      <div class="row form-body">
        <div class="col-md-9">

            <div class="form-horizontal">
                <asp:HiddenField ID="hdnIsxamine" runat="server" />
                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4 col-xm-12">
                        <asp:Label ID="lblPatinetId" CssClass="control-label" runat="server" for="txtPatientId" Text="PatientId"></asp:Label>
                    </div>
                    <div class="col-md-7 col-xm-12">
                        <asp:TextBox ID="txtPatientId" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
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
                        <asp:Label ID="lblComplain" CssClass="control-label" runat="server" for="txtComplain" Text="Complain"></asp:Label>
                    </div>
                    <div class="col-md-7 col-xm-12">
                        <asp:TextBox ID="txtComplain" CssClass="form-control" runat="server" MaxLength="200" TextMode="MultiLine" Rows="4"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4 col-xm-12">
                        <asp:Label ID="lblExamination" CssClass="control-label" runat="server" for="txtExamination" Text="Examination"></asp:Label>
                    </div>
                    <div class="col-md-7 col-xm-12">
                        <asp:TextBox ID="txtExamination" CssClass="form-control" runat="server" MaxLength="200" TextMode="MultiLine" Rows="4"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4 col-xm-12">
                        <asp:Label ID="lblDiagnosis" CssClass="control-label" runat="server" for="txtDiagnosis" Text="Diagnosis"></asp:Label>
                    </div>
                    <div class="col-md-7 col-xm-12">
                        <asp:TextBox ID="txtDiagnosis" CssClass="form-control" MaxLength="100" runat="server"></asp:TextBox>

                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4 col-xm-12">
                        <asp:Label ID="lblDrugs" CssClass="control-label" runat="server" for="txtDrugs" Text="Drugs"></asp:Label>
                    </div>
                    <div class="col-md-7 col-xm-12">
                        <asp:TextBox ID="txtDrugs" CssClass="form-control" runat="server" MaxLength="500" TextMode="MultiLine" Rows="4"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-1"></div>
                <div class="col-md-4"></div>
                <div class="col-md-7 button-group">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary primary-button-style" runat="server" Text="Register" OnClick="btnSubmit_Click" ValidationGroup="wardRegistration" />
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

            <div class="form-group">
                <div class="gridview-search-margin">
                    <div class="row gridview-margin">
                        <div class="col-md-1"></div>
                        <div class="col-md-10">
                            <asp:GridView ID="gridViewWardData" CssClass="table table-striped table-bordered table-hover" PageSize="10" AllowPaging="true" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="gridViewExaminationData_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="ExmID" HeaderText="No" />
                                    <asp:BoundField DataField="Complain" HeaderText="Complain" />
                                    <asp:BoundField DataField="Diagnosis" HeaderText="Diagnosis" />
                                    <asp:BoundField DataField="Doctor" HeaderText="Doctor" />
                                    <asp:BoundField DataField="Date" HeaderText="Date" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="linkView" runat="server" CommandArgument='<%# Eval("WardNo") %>' OnClick="gridViewExaminationData_onClick">View</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="col-md-1"></div>
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

        <div class="col-md-3"></div>
    </div>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="formrightcolumn" runat="server">
    <div class="examination-formright"></div>
</asp:Content>
