<%@ Page Title="" Language="C#" MasterPageFile="~/PMng.Master" AutoEventWireup="true" CodeBehind="SurgeryApproval.aspx.cs" Inherits="PMngOpeWrd.SurgeryApproval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/surgery-approval.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="formleftnav" runat="server">
     <div class="surgery-approval-formleftnav"></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="formHeader" runat="server">
       <h1>Surgery Approval</h1>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="formleftcolumn" runat="server">
         <div class="surgery-approval-formleft"></div>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="formrightcolumn" runat="server">
    <div class="surgery-approval-formright"></div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="body" runat="server">
     <div class="form-group">
        <asp:HiddenField ID="hdnEmployeeId" runat="server" />
        <div class="gridview-search-margin">
            <div class="row">
                <div class="form-group">
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlEmployeeFilter" runat="server" CssClass="form-control">
                            <asp:ListItem Value="patientId">Patient Id</asp:ListItem>
                            <asp:ListItem Value="surgeryId">Surgery Id</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-5 search-left-margin">
                        <asp:TextBox ID="txtSearchId" CssClass="form-control" placeholder="Search Value..." runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-1">
                        <span class="input-group-btn">
                            <asp:Button ID="btnSearch" CssClass="btn btn-default" runat="server" Text="Search" OnClick="btnSearch_Click" /><span class="glyphicon glyphicon-search"></span>
                        </span>
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnClearFilter" CssClass="btn btn-default primary-button-style" runat="server" Text="Clear Filter" OnClick="btnClearFilter_Click" />
                    </div>
                </div>
            </div>
            <div class="row gridview-margin">
                <div class="col-md-11">
                    <asp:GridView ID="gridViewSurgeryData" CssClass="table table-striped table-bordered table-hover" PageSize="10" AllowPaging="true" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="gridViewSurgeryData_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="SurgeryId" HeaderText="Surgery Id" />
                            <asp:BoundField DataField="PatientId" HeaderText="Patient Id" />
                            <asp:BoundField DataField="Patient" HeaderText="Patient Name" />
                            <asp:BoundField DataField="SurgeryStart" HeaderText="Surgery Start" />
                            <asp:BoundField DataField="NIC" HeaderText="NIC" />
                            <asp:BoundField DataField="TheatorId" HeaderText="Theator Id" />
                            <asp:HyperLinkField DataNavigateUrlFields="SurgeryId" DataNavigateUrlFormatString="SurgeryRegistration.aspx?surid={0}" Text="Approval" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-md-1"></div>
            </div>
            <%--<div class="col-md-3"></div>--%>
        </div>
    </div>

    <div class="row">
        <div class="col-md-10 info-mzg">
        
        <div id="grdDisplayMessage" class="alert alert-info" style="display:none" runat="server">
            There are no matching records
        </div>
            </div>
        <div class="col-md-2"></div>
    </div>
</asp:Content>


