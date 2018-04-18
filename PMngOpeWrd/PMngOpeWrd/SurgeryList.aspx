<%@ Page Title="" Language="C#" MasterPageFile="~/PMng.Master" AutoEventWireup="true" CodeBehind="SurgeryList.aspx.cs" Inherits="PMngOpeWrd.SurgeryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/surgery-list.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="formleftnav" runat="server">
    <div class="surgery-list-formleftnav"></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="formHeader" runat="server">
    <h1>Surgery List</h1>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="formleftcolumn" runat="server">
    <div class="surgery-list-formleft"></div>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="formrightcolumn" runat="server">
    <div class="surgery-list-formright"></div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="body" runat="server">
    <div class="form-group">
        <asp:HiddenField ID="hdnEmployeeId" runat="server" />
        <div class="gridview-search-margin">
            <div class="row">
                <div class="form-horizontal">
                    <div class="form-group">
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlPatientFilter" runat="server" CssClass="form-control">
                                <asp:ListItem Value="patientId">Patient Id</asp:ListItem>
                                <asp:ListItem Value="surgeryId">Surgery Id</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-5 search-left-margin">
                            <asp:TextBox ID="txtSearchId" CssClass="form-control" MaxLength="20" placeholder="Search Value..." runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="lblSurgeryIdInValid" runat="server" ForeColor="Red"></asp:Label><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-3">
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnSearch" CssClass="btn btn-default" runat="server" style="width: 150px;" Text="Search" OnClick="btnSearch_Click" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="btnClear" CssClass="btn btn-default" runat="server" style="width: 150px;"  Text="Clear" OnClick="btnClearFilter_Click" />
                        </div>
                        <div class="col-md-4">
                        </div>
                    </div>
                </div>
            </div>
            <div class="row gridview-margin">
                <div class="col-md-11">
                    <asp:GridView ID="gridViewSurgeryList" CssClass="table table-striped table-bordered table-hover" PageSize="10" AllowPaging="true" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="gridViewSurgeryList_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="SurgeryId" HeaderText="Surgery Id" />
                            <asp:BoundField DataField="PatientId" HeaderText="Patient Id" />
                            <asp:BoundField DataField="Patient" HeaderText="Patient Name" />
                            <asp:BoundField DataField="SurgeryStart" HeaderText="Surgery Start" />
                            <asp:BoundField DataField="TheatorId" HeaderText="Theator Id" />
                            <asp:HyperLinkField DataNavigateUrlFields="SurgeryId" DataNavigateUrlFormatString="SurgeryRegistration.aspx?sid={0}&frm=lst" Text="Approval" />
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
                There are no marching records
            </div>
        </div>
        <div class="col-md-2"></div>
    </div>
</asp:Content>


