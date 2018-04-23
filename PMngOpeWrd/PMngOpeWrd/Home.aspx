<%@ Page Title="" Language="C#" MasterPageFile="~/PMng.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PMngOpeWrd.TestPage" %>

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
                            <h4 class="subheading">Improving health through trusted Information</h4>
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
                            <h6 class="main-content">Surgery is a treatment of injuries or disorders of the body by incision or manipulation, especially with instruments. When admitting patients to the hospital for a surgery, doctors have to go through a full analysis of patient records while trying to gather all the wanted prescriptions. According to manual process it could take a considerable time. </h6>
                            <h6 class="main-content">When they are recorded registration details manually in a book, it also very difficult to manage efficiently. Due to the shortage of the clerical staff, even emergency surgeries could get delayed too. As such, Most of the patients blaming their surgery become delay and they waste their time at the hospital.
                                When discussed with the doctors, they also identified some areas need to improve. According to their feedback, identified which areas can be improved with software solution to increase the efficiency and the productivity of the overall process.
                            </h6>
                            <h6 class="main-content">With this, all the patients’ records, availability of theaters, coworkers who’s going to be there in the theater is a single click away from the doctor. Starting from the registration of a patient at the clinic till he undergoes the surgery, all the intermediate processes like patient admission, examination, 
                                medicines and theater allocations are accessible to doctors through the system. Post-surgery examinations also could monitor using this system.  All the patients and system users are given a unique identification number. Considering all the facilities described above, Patient Management for Operation Wards web application is fully utilized and efficient software for theaters in hospitals to increase the quality of the service provides by them. </h6>
                            <h6 class="main-content">PMOW is developed by applying object oriented concepts, C# language using Microsoft Visual Studio Integrated Development Environment (IDE). MVP architecture is used to increase the maintainability and the extendibility of the system. Several testing has been performed to evaluate the accuracy, reliability and performance of the PMOW application.
                                Medical staff can access surgery related patient information through PMOW web application. That will be very helpful to avoid unnecessary delays in the surgery and provide efficient service to the patients. Since patient information can access easily, surgeons have ability do some researches related to disease. 
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
