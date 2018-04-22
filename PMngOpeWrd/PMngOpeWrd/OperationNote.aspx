<%@ Page Title="" Language="C#" MasterPageFile="~/PMng.Master" AutoEventWireup="true" CodeBehind="OperationNote.aspx.cs" Inherits="PMngOpeWrd.OperationNote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/operationNote.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="formleftnav" runat="server">
    <div class="opnote-formleftnav"></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="formHeader" runat="server">
    <h1>Surgery Note</h1>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="formleftcolumn" runat="server">
    <div class="opnote-formleft"></div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="body" runat="server">
    <div class="form-body">
        <div class="row">
            <div class="col-md-9">
                <div class="form-horizontal">
                    <asp:HiddenField ID="hdnIsNewSurgery" runat="server" />
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblSurgeryId" CssClass="control-label" runat="server" for="txtSurgeryId" Text="Surgery Id"></asp:Label>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:TextBox ID="txtSurgeryId" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblPatientId" CssClass="control-label" runat="server" for="txtPatientId" Text="Patient Id"></asp:Label>
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
                            <asp:Label ID="lblDoctor" CssClass="control-label" runat="server" for="txtDoctor" Text="Doctor"></asp:Label>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:TextBox ID="txtDoctor" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblDescription" CssClass="control-label" runat="server" for="txtDescription" Text="Surgery Description"></asp:Label>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:TextBox ID="txtDescription" Enabled="false" CssClass="form-control" runat="server" MaxLength="500" TextMode="MultiLine" Rows="4"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblNote" CssClass="control-label" runat="server" for="txtNote" Text="Surgery Note"></asp:Label>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:TextBox ID="txtNote" CssClass="form-control" MaxLength="500" TextMode="MultiLine" Rows="4" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblDirectorApproval" CssClass="control-label" runat="server" for="ddlDirectorApprove" Text="Approval"></asp:Label>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:DropDownList ID="ddlSurgeryStatus" Enabled="true" CssClass="form-control" runat="server">
                                <asp:ListItem Value="completed">Completed</asp:ListItem>
                                <asp:ListItem Value="pending" Selected="True">Pending</asp:ListItem>
                                <asp:ListItem Value="postpone">Postpone</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4"></div>
                    <div class="col-md-7 button-group">
                        <asp:Button ID="btnSubmit" Enabled="true" CssClass="btn btn-primary primary-button-style" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="opNote" />
                        <asp:Button ID="btnCancel" Enabled="true" CssClass="btn btn-primary primary-button-style" runat="server" Text="Cancel" OnClick="btnCancel_Click" ValidationGroup="opNote" />
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
    <div class="opnote-formright"></div>
</asp:Content>
