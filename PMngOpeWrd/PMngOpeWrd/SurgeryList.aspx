<%@ Page Title="" Language="C#" MasterPageFile="~/PMng.Master" AutoEventWireup="true" CodeBehind="SurgeryList.aspx.cs" Inherits="PMngOpeWrd.SurgeryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/surgery-list.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-datetimepicker.css" rel="stylesheet" />
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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
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
                                <div class="col-md-4 search-left-margin">
                                    <asp:TextBox ID="txtSearchId" CssClass="form-control" MaxLength="20" placeholder="Search Value..." runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-5">
                                    <asp:Label ID="lblSurgeryIdInValid" runat="server" ForeColor="Red"></asp:Label><br />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-3 col-xm-12">
                                    <asp:Label ID="lblDoctor" CssClass="control-label" runat="server" for="ddlDoctors" Text="Doctor"></asp:Label>
                                </div>
                                <div class="col-md-4 col-xm-12">
                                    <asp:DropDownList ID="ddlDoctors" CssClass="form-control" AutoPostBack="false" AppendDataBoundItems="true" runat="server">
                                        <asp:ListItem Value="default">Select a Doctor...</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-5"></div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-3">
                                    <asp:Label ID="lblSurgeryStatus" CssClass="control-label" runat="server" for="ddlSurgeryStatus" Text="Surgery Status"></asp:Label>
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlSurgeryStatus" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="default">Select a Status...</asp:ListItem>
                                        <asp:ListItem Value="pending">Pending</asp:ListItem>
                                        <asp:ListItem Value="completed">Completed</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-5"></div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-3">
                                    <asp:Label ID="lblFromSurgery" CssClass="control-label" runat="server" Text="Surgery Date"></asp:Label>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblSuFrom" CssClass="control-label" runat="server" for="txtSurgeryDateFrom" Text="From"></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <div class="input-group date" id='datetimepickerFrom'>
                                        <asp:TextBox ID="txtSurgeryDateFrom" CssClass="m-wrap span12 date form_datetime form-control" Style="pointer-events: none; background-color: #f2f2f2;" MaxLength="19" runat="server"></asp:TextBox>
                                        <span class="input-group-addon">
                                            <i class="glyphicon glyphicon-calendar"></i>
                                        </span>
                                    </div>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblSurgeryTo" CssClass="control-label" runat="server" for="txtSurgeryDateTo" Text="To"></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <div class="input-group date" id='datetimepickerTo'>
                                        <asp:TextBox ID="txtSurgeryDateTo" CssClass="m-wrap span12 date form_datetime form-control" Style="pointer-events: none; background-color: #f2f2f2;" MaxLength="19" runat="server"></asp:TextBox>
                                        <span class="input-group-addon">
                                            <i class="glyphicon glyphicon-calendar"></i>
                                        </span>
                                    </div>
                                </div>
                                <div class="col-md-1"></div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-3">
                                    <asp:Label ID="lblFromAdmissionDate" CssClass="control-label" runat="server" Text="Admission Date"></asp:Label>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblAdFrom" CssClass="control-label" runat="server" for="txtAdmissionDateFrom" Text="From"></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <div class="input-group date" id='admissionDateFrom'>
                                        <asp:TextBox ID="txtAdmissionDateFrom" Style="pointer-events: none; background-color: #f2f2f2;" ClientIDMode="Static" CssClass="m-wrap span12 date form_datetime form-control" MaxLength="10" runat="server"></asp:TextBox>
                                        <span class="input-group-addon">
                                            <i class="glyphicon glyphicon-calendar"></i>
                                        </span>
                                    </div>
                                </div>
                                <div class="col-md-1">
                                    <asp:Label ID="lblToAdmissionDate" CssClass="control-label" runat="server" for="txtAdmissionDateTo" Text="To"></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <div class="input-group date" id='admissionDateTo'>
                                        <asp:TextBox ID="txtAdmissionDateTo" Style="pointer-events: none; background-color: #f2f2f2;" ClientIDMode="Static" CssClass="m-wrap span12 date form_datetime form-control" MaxLength="10" runat="server"></asp:TextBox>
                                        <span class="input-group-addon">
                                            <i class="glyphicon glyphicon-calendar"></i>
                                        </span>
                                    </div>
                                </div>
                                <div class="col-md-1"></div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-3">
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btnSearch" CssClass="btn btn-default" runat="server" Style="width: 140px;" Text="Search" OnClick="btnSearch_Click" />
                                </div>
                                <div class="col-md-3">
                                    <asp:Button ID="btnClear" CssClass="btn btn-default" runat="server" Style="width: 127px;" Text="Clear" OnClick="btnClearFilter_Click" />
                                </div>
                                <div class="col-md-4">
                                </div>
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
                                <asp:BoundField DataField="WardNo" HeaderText="Ward No" />
                                <asp:BoundField DataField="AdmissionStatus" HeaderText="Admission Status" />
                                <asp:BoundField DataField="Status" HeaderText="Surgery Status" />
                                <%-- <asp:TemplateField  HeaderText="Admission Status">
                                        <ItemTemplate>
                                           <%# ((string)Eval("AdmissionStatus")).Length > 0? "Not Admitted" : Eval("AdmissionStatus")   %>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                <asp:HyperLinkField DataNavigateUrlFields="SurgeryId" DataNavigateUrlFormatString="SurgeryRegistration.aspx?sid={0}&frm=lst" Text="View" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="col-md-1"></div>
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
        </ContentTemplate>
    </asp:UpdatePanel>

    <%--  <script src="Scripts/jquery-1.9.1.min.js"></script>--%>
    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="Scripts/moment.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap-datetimepicker.js"></script>
    <script type="text/javascript">

        function pageLoad() {
            $('#datetimepickerFrom').datetimepicker({
                format: 'YYYY/MM/DD'
            });

            $('#datetimepickerTo').datetimepicker({
                format: 'YYYY/MM/DD'
            });

            $('#admissionDateFrom').datetimepicker({
                format: 'YYYY/MM/DD'
            });

            $('#admissionDateTo').datetimepicker({
               format: 'YYYY/MM/DD'
            });

            $("#datetimepickerFrom").on("dp.change", function (e) {
                $('#datetimepickerTo').data("DateTimePicker").minDate(e.date);
            });
            $("#datetimepickerTo").on("dp.change", function (e) {
                $('#datetimepickerFrom').data("DateTimePicker").maxDate(e.date);
            });

            $("#admissionDateFrom").on("dp.change", function (e) {
                $('#admissionDateTo').data("DateTimePicker").minDate(e.date);
            });
            $("#admissionDateTo").on("dp.change", function (e) {
                $('#admissionDateFrom').data("DateTimePicker").maxDate(e.date);
            });
        }

        $(document).ready(function () {

           
        });
    </script>
</asp:Content>


