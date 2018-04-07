<%@ Page Title="" Language="C#" MasterPageFile="~/PMng.Master" AutoEventWireup="true" CodeBehind="EmployeeInquiry.aspx.cs" Inherits="PMngOpeWrd.EmployeeInquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/employeeInquiry.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="formHeader" runat="server">
     <h1>Employee Inquiry</h1>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="formleftnav" runat="server">
    <div class="employee-inq-formleftnav"></div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="formleftcolumn" runat="server">
        <div class="employee-ing-formleft"></div>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="formrightcolumn" runat="server">
     <div class="employee-inq-formright"></div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="body" runat="server">
    <div class="form-group">
        <asp:HiddenField ID="hdnEmployeeId" runat="server" />
        <div class="gridview-search-margin">
            <div class="row">
                <div class="form-group">
                    <div class="col-md-3">
                        <asp:DropDownList ID="ddlEmployeeFilter" runat="server" CssClass="form-control">
                            <asp:ListItem Value="employeeId">Employee Id</asp:ListItem>
                            <asp:ListItem Value="nic">NIC</asp:ListItem>
                            <asp:ListItem Value="firstName">First Name</asp:ListItem>
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
                    <asp:GridView ID="gridViewEmployeeData" CssClass="table table-striped table-bordered table-hover" PageSize="10" AllowPaging="true" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="gridViewEmployeeData_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="EmployeeId" HeaderText="Employee Id" />
                            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                            <asp:BoundField DataField="NIC" HeaderText="NIC" />
                            <asp:BoundField DataField="EmployeeType" HeaderText="Employee Type" />
                            <asp:BoundField DataField="IsActive" HeaderText="Is Active" />
                            <asp:BoundField DataField="MobilePhone" HeaderText="Mobile Phone" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:HyperLinkField DataNavigateUrlFields="EmployeeId, EmployeeType" DataNavigateUrlFormatString="EmployeeRegistration.aspx?empid={0}&emptyp={1}" Text="View" />
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


