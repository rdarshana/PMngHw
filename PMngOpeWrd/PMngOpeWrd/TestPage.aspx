<%@ Page Title="" Language="C#" MasterPageFile="~/PMng.Master" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="PMngOpeWrd.TestPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/bootstrap-datepicker.css" rel="stylesheet" />
    <link href="css/main.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="formleftnav" runat="server">
    <div class="patirnt-reg-formleftnav"></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="formHeader" runat="server">
    <div runat="server" id="divPatientRegistration">
    </div>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="formleftcolumn" runat="server">
    <div class="patirnt-reg-formleft"></div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="body" runat="server">
    <div class="row form-body">
        <div class="col-md-12">
            <asp:HiddenField ID="hdnIsNewPatient" runat="server" />
         
            <div class="form-group">
                <div class="col-md-4">
                    <div class="box box-primary">
                        <div class="form-group">
                            <img src="images/vision.png" />
                            <h4 class="subheading">To be recognized leaders in rural health care</h4>
                        </div>
                    </div> 
                </div>

               <div class="col-md-4">
                    <div class="box box-primary">
                        <div class="form-group">
                            <img src="images/mission.png" />
                            <h4 class="subheading">To provide health care that enhance the quality of life </h4></div>
                    </div> 
                </div>
                
                <div class="col-md-4">
                    <div class="box box-primary">
                        <div class="form-group">
                            <img src="images/values.png" />
                            <h4 class="subheading">Caring, Excellence, Respect, Integrity & Fairness</h4></div>
                    </div> 
                </div>                
            </div>

            <div class="form-group">
                <div class="col-md-12">
                    <div class="box box-primary">
                        <div class="form-group">
                            <h6 class="main-content">Bendigo Health has moved to the new Bendigo Hospital located at 100 Barnard Street, Bendigo (access via Mercy Street). Please note phone numbers have not changed and if you wish to locate a Bendigo Health staff member call switchboard at 5454 6000. </h6>
                            <h6 class="main-content">The SeNT e-Referral solution allows GPs to send secure referrals electronically to Bendigo Health. SeNT integrates with GP Medical Director and Best Practice clinical software. Referrals can be send directly from a GP's desktop or from HealthPathways.
                                The SeNT e-Referral solution allows GPs to send secure referrals electronically to Bendigo Health. SeNT integrates with GP Medical Director and Best Practice clinical software. Referrals can be send directly from a GP's desktop or from HealthPathways.
                                The SeNT e-Referral solution allows GPs to send secure referrals electronically to Bendigo Health. SeNT integrates with GP Medical Director and Best Practice clinical software. Referrals can be send directly from a GP's desktop or from HealthPathways.
                                The SeNT e-Referral solution allows GPs to send secure referrals electronically to Bendigo Health. SeNT integrates with GP Medical Director and Best Practice clinical software. Referrals can be send directly from a GP's desktop or from HealthPathways.
                                The SeNT e-Referral solution allows GPs to send secure referrals electronically to Bendigo Health. SeNT integrates with GP Medical Director and Best Practice clinical software. Referrals can be send directly from a GP's desktop or from HealthPathways.
                            </h6>
                            <h6 class="main-content">Bendigo Health has moved to the new Bendigo Hospital located at 100 Barnard Street, Bendigo (access via Mercy Street). Please note phone numbers have not changed and if you wish to locate a Bendigo Health staff member call switchboard at 5454 6000. </h6>
                            <h6 class="main-content">The SeNT e-Referral solution allows GPs to send secure referrals electronically to Bendigo Health. SeNT integrates with GP Medical Director and Best Practice clinical software. Referrals can be send directly from a GP's desktop or from HealthPathways.
                                The SeNT e-Referral solution allows GPs to send secure referrals electronically to Bendigo Health. SeNT integrates with GP Medical Director and Best Practice clinical software. Referrals can be send directly from a GP's desktop or from HealthPathways.
                                The SeNT e-Referral solution allows GPs to send secure referrals electronically to Bendigo Health. SeNT integrates with GP Medical Director and Best Practice clinical software. Referrals can be send directly from a GP's desktop or from HealthPathways.
                                The SeNT e-Referral solution allows GPs to send secure referrals electronically to Bendigo Health. SeNT integrates with GP Medical Director and Best Practice clinical software. Referrals can be send directly from a GP's desktop or from HealthPathways.
                                The SeNT e-Referral solution allows GPs to send secure referrals electronically to Bendigo Health. SeNT integrates with GP Medical Director and Best Practice clinical software. Referrals can be send directly from a GP's desktop or from HealthPathways.
                            </h6>
                        </div>
                    </div> 
                </div>              
            </div>
        </div>
    </div>

    <div class="row"></div>
    <div class="row"></div>


    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <!-- Boostrap DatePciker JS  -->
    <script src="js/bootstrap-datepicker.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            <%--var dp = $('#<%=txtStartDate.ClientID%>');
            dp.datepicker({--%>
            $('.input-group.date').datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yyyy",
                language: "tr"
            }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="formrightcolumn" runat="server">
    <div class="patirnt-reg-formright"></div>
</asp:Content>
