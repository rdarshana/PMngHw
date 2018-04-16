<%@ Page Title="" Language="C#" MasterPageFile="~/PMng.Master" AutoEventWireup="true" CodeBehind="AdmissionInquery.aspx.cs" Inherits="PMngOpeWrd.AdmissionInquery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/admission-inquiry.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="formleftnav" runat="server">
    <div class="admission-inquiry-formleftnav"></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="formHeader" runat="server">
    <h1>Admission Inquiry</h1>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="formleftcolumn" runat="server">
    <div class="admission-inquiry-formleft"></div>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="formrightcolumn" runat="server">
    <div class="admission-inquiry-formright"></div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="body" runat="server">
    <div class="form-group">
        <asp:HiddenField ID="hdnEmployeeId" runat="server" />
        <div class="gridview-search-margin">

            <div class="row">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-md-1">
                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="lblPatientId" CssClass="control-label" runat="server" for="txtPatientId" Text="Patient Id"></asp:Label>
                        </div>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPatientId" CssClass="form-control" placeholder="Search Value..." runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-1">
                        </div>
                        <div class="col-md-2">
                             <asp:Label ID="lblStatus" CssClass="control-label" runat="server" for="ddlStatus" Text="Status"></asp:Label>
                        </div>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                <asp:ListItem Value="admitted">Admitted</asp:ListItem>
                                <asp:ListItem Value="discharged">Discharged</asp:ListItem>
                                <asp:ListItem Value="all">All</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <asp:Button ID="btnSearch" CssClass="btn btn-default primary-button-style" runat="server" Text="Search" OnClick="btnSearchFilter_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="row gridview-margin">
                <div class="col-md-11">
                    <asp:GridView ID="gridViewAdmissionData" CssClass="table table-striped table-bordered table-hover" PageSize="15" AllowPaging="true" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="gridViewAdmissionData_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="AdmissionId" HeaderText="Admission Id" />
                            <asp:BoundField DataField="PatientId" HeaderText="Patient Id" />
                            <asp:BoundField DataField="Patient" HeaderText="Patient Name" />
                            <asp:BoundField DataField="WardNo" HeaderText="Ward No" />
                            <asp:BoundField DataField="AdmissionDate" HeaderText="Admission Date" DataFormatString="{0:yyyy/MM/dd}" />
                            <asp:BoundField DataField="DischageDate" HeaderText="Discharge Date" DataFormatString="{0:yyyy/MM/dd}"/>
                            <asp:BoundField DataField="AdmissionStatus" HeaderText="Admission Status" />
                            <asp:HyperLinkField DataNavigateUrlFields="AdmissionId" DataNavigateUrlFormatString="Admission.aspx?admid={0}" Text="View" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-md-1"></div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-10 info-mzg">

            <div id="grdDisplayMessage" class="alert alert-info" style="display: none" runat="server">
                There are no matching records
            </div>
        </div>
        <div class="col-md-2"></div>
    </div>
</asp:Content>
