﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PMng.Master" AutoEventWireup="true" CodeBehind="PatientInquiry.aspx.cs" Inherits="PMngOpeWrd.PatientInquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="formHeader" runat="server">
    <h1>Patient Inquiry</h1>
</asp:Content>

<asp:Content ID="patientregLeftnav" ContentPlaceHolderID="formleftnav" runat="server">
    <div class="patirnt-inq-formleftnav"></div>
</asp:Content>

<asp:Content ID="patientLeftColumn" ContentPlaceHolderID="formleftcolumn" runat="server">
    <div class="patirnt-ing-formleft"></div>
</asp:Content>

<asp:Content ID="patientRightColumn" ContentPlaceHolderID="formrightcolumn" runat="server">
    <div class="patirnt-inq-formright"></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="form-group">
                <asp:HiddenField ID="hdnPatientId" runat="server" />
                <div class="gridview-search-margin">
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddlPatientFilter" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="patientId">Patient Id</asp:ListItem>
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
                        <div class="col-md-12">
                            <div style="width: 100%; overflow-x: scroll">
                                <asp:GridView ID="gridViewPatientData" CssClass="table table-striped table-bordered table-hover" PageSize="15" AllowPaging="true" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="PatientView_SelectedIndexChanged" OnPageIndexChanging="gridViewPatientData_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField DataField="PatientId" HeaderText="Patient Id" />
                                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                        <asp:BoundField DataField="NIC" HeaderText="NIC" />
                                        <%--<asp:BoundField DataField="Address" HeaderText="Address" />--%>
                                        <asp:BoundField DataField="MobilePhone" HeaderText="Mobile Phone" />
                                        <%--<asp:BoundField DataField="LandPhone" HeaderText="Land Phone" />--%>
                                        <asp:BoundField DataField="Email" HeaderText="Email" />
                                        <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                        <asp:BoundField DataField="MaritalStatus" HeaderText="Marital Status" />
                                        <asp:BoundField DataField="EmergencyContact" HeaderText="Emergency Contact" />
                                        <asp:BoundField DataField="DateOfBirth" HeaderText="Date Of Birth" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="linkView" runat="server" CommandArgument='<%# Eval("PatientId") %>' OnClick="GridViewPatient_onClick">View</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>

                        </div>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
