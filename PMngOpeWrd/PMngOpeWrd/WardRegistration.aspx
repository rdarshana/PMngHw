<%@ Page Title="" Language="C#" MasterPageFile="~/PMng.Master" AutoEventWireup="true" CodeBehind="WardRegistration.aspx.cs" Inherits="PMngOpeWrd.WardRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/theator.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="formleftnav" runat="server">
    <div class="theator-formleftnav"></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="formHeader" runat="server">
    <h1>Ward Registration</h1>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="formleftcolumn" runat="server">
    <div class="theator-formleft"></div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="body" runat="server">
    <div class="row form-body">
        <div class="col-md-9">

            <div class="form-horizontal">
                <asp:HiddenField ID="hdnIsNewWard" runat="server" />
                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4 col-xm-12">
                        <asp:Label ID="lblWardNo" CssClass="control-label" runat="server" for="txtWardNo" Text="Ward No"></asp:Label>
                    </div>
                    <div class="col-md-7 col-xm-12">
                        <asp:TextBox ID="txtWardNo" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4 col-xm-12">
                        <asp:Label ID="lblOwner" CssClass="control-label" runat="server" for="ddlOwner" Text="Ward Owner"></asp:Label>
                    </div>
                    <div class="col-md-7 col-xm-12">
                        <asp:DropDownList ID="ddlOwner" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4 col-xm-12">
                        <asp:Label ID="lblType" CssClass="control-label" runat="server" for="ddlType" Text="Ward Type"></asp:Label>
                    </div>
                    <div class="col-md-7 col-xm-12">
                        <asp:DropDownList ID="ddlType" CssClass="form-control" runat="server">
                            <asp:ListItem Value="general">General</asp:ListItem>
                            <asp:ListItem Value="director">Director</asp:ListItem>
                            <asp:ListItem Value="doctor">Doctor</asp:ListItem>
                            <asp:ListItem Value="mlt">MLT</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4 col-xm-12">
                        <asp:Label ID="lblNoOfBeds" CssClass="control-label" runat="server" for="txtNoOfBeds" Text="Number Of Beds"></asp:Label>
                        <span class="required-field-star">*</span>
                    </div>
                    <div class="col-md-7 col-xm-12">
                        <asp:TextBox ID="txtNoOfBeds" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNoOfBeds" runat="server" ErrorMessage="This field is required" ControlToValidate="txtNoOfBeds" ValidationGroup="wardRegistration" ForeColor="Red"></asp:RequiredFieldValidator>
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
                            <asp:GridView ID="gridViewWardData" CssClass="table table-striped table-bordered table-hover" PageSize="10" AllowPaging="true" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="gridViewTheaterData_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="WardNo" HeaderText="Theater Id" />
                                    <asp:BoundField DataField="Owner" HeaderText="Word Owner" />
                                    <asp:BoundField DataField="WardType" HeaderText="Ward Type" />
                                    <asp:BoundField DataField="NoOfBeds" HeaderText="Beds" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="linkView" runat="server" CommandArgument='<%# Eval("WardNo") %>' OnClick="GridViewTheator_onClick">View</asp:LinkButton>
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
    <div class="theator-formright"></div>
</asp:Content>
