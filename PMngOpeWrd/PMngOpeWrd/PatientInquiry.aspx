<%@ Page Title="" Language="C#" MasterPageFile="~/PMng.Master" AutoEventWireup="true" CodeBehind="PatientInquiry.aspx.cs" Inherits="PMngOpeWrd.PatientInquiry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formHeader" runat="server">
    <h1>Patient Inquery</h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
            <div class="form-group">
                <asp:HiddenField ID="hdnPatientId" runat="server" />
                <div class="gridview-margin">
                    <div class="col-md-11">
                        <asp:GridView ID="gridViewPatientData" CssClass="table table-striped table-bordered table-hover" PageSize="10" AllowPaging="true" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="PatientView_SelectedIndexChanged" OnPageIndexChanging="gridViewPatientData_PageIndexChanging">
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
                    <div class="col-md-1"></div>
                    <%--<div class="col-md-3"></div>--%>
                </div>
            </div>
</asp:Content>
