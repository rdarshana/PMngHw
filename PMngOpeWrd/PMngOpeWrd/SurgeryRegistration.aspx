<%@ Page Title="" Language="C#" MasterPageFile="~/PMng.Master" AutoEventWireup="true" CodeBehind="SurgeryRegistration.aspx.cs" Inherits="PMngOpeWrd.SurgeryRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/surgery-registration.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-datetimepicker.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="formleftnav" runat="server">
    <div class="surgery-formleftnav"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="formHeader" runat="server">
    <h1>Surgery Registration</h1>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="formleftcolumn" runat="server">
    <div class="surgey-formleft"></div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="body" runat="server">
    <div class="form-body">

        <div class="row examination-search">
            <div class="form-group">
                <div class="col-md-1"></div>
                <div class="col-md-3 examination-searchfield">
                    <asp:Label ID="lblpatietId" CssClass="control-label" runat="server" for="txtPatientId" Text="Patient Id"></asp:Label>
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
                    <asp:HiddenField ID="hdnIsNewSurgery" runat="server" />
                    <asp:HiddenField ID="hdnSurgeryId" runat="server" />
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
                            <asp:Label ID="lblDoctor" CssClass="control-label" runat="server" for="ddlDoctors" Text="Doctor"></asp:Label>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:DropDownList ID="ddlDoctors" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="SelectedDocorChanged"></asp:DropDownList>
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
                            <asp:Label ID="lblAdmissionDate" CssClass="control-label" runat="server" for="txtAdmissionDate" Text="Admission Date"></asp:Label>
                            <span class="required-field-star">*</span>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <div class="input-group date" id='admissionDate'>
                                <asp:TextBox ID="txtAdmissionDate" ClientIDMode="Static" CssClass="m-wrap span12 date form_datetime form-control" MaxLength="10" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="glyphicon glyphicon-calendar"></i>
                                </span>
                            </div>
                                 <asp:RequiredFieldValidator ID="reqAdmissionDate" runat="server" ErrorMessage="This field is required" ControlToValidate="txtAdmissionDate" ValidationGroup="surgeryRegistration" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblSurgeryDescription" CssClass="control-label" runat="server" for="txtSurgeryDescription" Text="Surgery Description"></asp:Label>
                            <span class="required-field-star">*</span>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:TextBox ID="txtSurgeryDescription" CssClass="form-control" runat="server" MaxLength="500" TextMode="MultiLine" Rows="4"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblFromSurgery" CssClass="control-label" runat="server" for="txtSurgeryDateFrom" Text="Surgery Start At"></asp:Label>
                            <span class="required-field-star">*</span>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <div class="input-group date" id='datetimepickerFrom'>
                                <asp:TextBox ID="txtSurgeryDateFrom" ClientIDMode="Static" CssClass="m-wrap span12 date form_datetime form-control" MaxLength="10" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="glyphicon glyphicon-calendar"></i>
                                </span>
                            </div>
                                 <asp:RequiredFieldValidator ID="reqDateFrom" runat="server" ErrorMessage="This field is required" ControlToValidate="txtSurgeryDateFrom" ValidationGroup="surgeryRegistration" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblSurgeryTo" CssClass="control-label" runat="server" for="txtSurgeryDateTo" Text="Surgery End At"></asp:Label>
                            <span class="required-field-star">*</span>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <div class="input-group date" id='datetimepickerTo'>
                                <asp:TextBox ID="txtSurgeryDateTo" ClientIDMode="Static" CssClass="m-wrap span12 date form_datetime form-control" MaxLength="10" runat="server"></asp:TextBox>
                                <span class="input-group-addon">
                                    <i class="glyphicon glyphicon-calendar"></i>
                                </span>
                            </div>
                                <asp:RequiredFieldValidator ID="reqToDate" runat="server" ErrorMessage="This field is required" ControlToValidate="txtSurgeryDateTo" ValidationGroup="surgeryRegistration" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblTheators" CssClass="control-label" runat="server" for="ddlTheators" Text="Theators"></asp:Label>
                        </div>
                        <div class="col-md-5 col-xm-12">
                            <asp:DropDownList ID="ddlTheators" Width="229px" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="btnSearchTheator" CssClass="form-control theater-search btn btn-default" runat="server" Text="Search Availability" />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="gridview-search-margin">
                            <div class="row gridview-margin">
                                <div class="col-md-1"></div>
                                <div class="col-md-11">
                                    <asp:GridView ID="gridViewTheators" CssClass="table table-striped table-bordered table-hover" PageSize="10" AllowPaging="true" runat="server" AutoGenerateColumns="false" OnPageIndexChanging="gridViewSurgeryRegistration_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="SurgeryID" HeaderText="Surgery ID" />
                                            <asp:BoundField DataField="SurgeryDate" HeaderText="Surgery Date" />
                                            <asp:BoundField DataField="Doctor" HeaderText="Doctor" />
                                            <asp:TemplateField HeaderText="Desctiption">
                                                <ItemTemplate>
                                                    <%# ((string)Eval("Complain")).Length < 20? Eval("Complain") :((string)Eval("Description")).Substring(0,20) + "..."%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="linkView" runat="server" CommandArgument='<%# Eval("SurgeryID") %>' OnClick="gridViewSurgeryData_onClick">View</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
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
                <div class="form-group">
                    <div class="col-md-1"></div>
                    <div class="col-md-4"></div>
                    <div class="col-md-7 button-group">
                        <asp:Button ID="btnSubmit" Enabled="false" CssClass="btn btn-primary primary-button-style" runat="server" Text="Register" OnClick="btnSubmit_Click" ValidationGroup="surgeryRegistration" />
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

        <div class="row">
            <div class="col-md-9">
                <div class="form-horizontal box box-primary">
                    <div class="form-group approval-box-header">
                        <asp:Label ID="lblSurgeonApproval" runat="server" Text="Surgeon Approval"></asp:Label>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="Label2" CssClass="control-label" runat="server" for="ddlSurgeonApprove" Text="Approval"></asp:Label>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:DropDownList ID="ddlSurgeonApprove" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblSurgeonDescription" CssClass="control-label" runat="server" for="txtSurgeonDescription" Text="Description"></asp:Label>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:TextBox ID="txtSurgeonDescription" CssClass="form-control" runat="server" MaxLength="200" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4"></div>
                        <div class="col-md-7 button-group">
                            <asp:Button ID="btnSurgeonApproval" Enabled="false" CssClass="btn btn-primary primary-button-style" runat="server" Text="Submit" />
                        </div>
                    </div>
                </div>
                <div class="col-md-3"></div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-9">
                <div class="form-horizontal box box-primary">
                    <div class="form-group approval-box-header">
                        <asp:Label ID="lblAnesthetistApproval" runat="server" Text="Anesthetist Approval"></asp:Label>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblApproved" CssClass="control-label" runat="server" for="ddlAnesthetistApprove" Text="Approval"></asp:Label>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:DropDownList ID="ddlAnesthetistApprove" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblProblems" CssClass="control-label" runat="server" for="txtAnestheticsProblems" Text="Problems"></asp:Label>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:TextBox ID="txtAnestheticsProblems" CssClass="form-control" runat="server" MaxLength="200" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblModeOfAnesthesia" CssClass="control-label" runat="server" for="txtModeOfAnesthesia" Text="Mode Of Anesthesia"></asp:Label>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:TextBox ID="txtModeOfAnesthesia" CssClass="form-control" MaxLength="100" runat="server" TextMode="SingleLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4"></div>
                        <div class="col-md-7 button-group">
                            <asp:Button ID="btnAnesthesiaOk" Enabled="false" CssClass="btn btn-primary primary-button-style" runat="server" Text="Submit" />
                        </div>
                    </div>
                </div>
                <div class="col-md-3"></div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-9">
                <div class="form-horizontal box box-primary">
                    <div class="form-group approval-box-header">
                        <asp:Label ID="lblDirector" runat="server" Text="Director Approval"></asp:Label>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="lblDirectorApproval" CssClass="control-label" runat="server" for="ddlDirectorApprove" Text="Approval"></asp:Label>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:DropDownList ID="ddlDirectorApprove" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4 col-xm-12">
                            <asp:Label ID="Label4" CssClass="control-label" runat="server" for="txtDirectorDescription" Text="Description"></asp:Label>
                        </div>
                        <div class="col-md-7 col-xm-12">
                            <asp:TextBox ID="txtDirectorDescription" CssClass="form-control" runat="server" MaxLength="200" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-1"></div>
                        <div class="col-md-4"></div>
                        <div class="col-md-7 button-group">
                            <asp:Button ID="Button1" Enabled="false" CssClass="btn btn-primary primary-button-style" runat="server" Text="Submit" />
                        </div>
                    </div>
                </div>
                <div class="col-md-3"></div>
            </div>
        </div>

    </div>

    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/moment.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap-datetimepicker.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $(function () {
                $('#datetimepickerFrom').datetimepicker({
                    format: 'YYYY/MM/DD hh:mm A',
                    minDate: moment()
                });
            });

            $(function () {
                $('#datetimepickerTo').datetimepicker({
                    format: 'YYYY/MM/DD hh:mm A',
                    minDate: moment()
                });
            });

            $(function () {
                $('#admissionDate').datetimepicker({
                    defaultDate: moment(),
                    format: 'YYYY/MM/DD',
                    minDate: moment()
                });
            });

            $("#admissionDate").on("dp.change", function (e) {
                //$('#datetimepickerFrom').data("DateTimePicker").minDate(e.date);
                //$('#datetimepickerTo').data("DateTimePicker").minDate(e.date);
            });

            $("#datetimepickerFrom").on("dp.change", function (e) {
                $('#datetimepickerTo').data("DateTimePicker").minDate(e.date);
            });
            $("#datetimepickerTo").on("dp.change", function (e) {
                $('#datetimepickerFrom').data("DateTimePicker").maxDate(e.date);
            });



            
        });
    </script>
    

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="formrightcolumn" runat="server">
    <div class="surgery-formright"></div>
</asp:Content>


