using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMngOpeWrd.View;
using PMngOpeWrd.Presenter;
using System.Data;
using System.Threading;
using Microsoft.CSharp.RuntimeBinder;

namespace PMngOpeWrd
{
    public partial class SurgeryRegistration : System.Web.UI.Page, ISurgeryView
    {
        SurgeryPresenter presenter;
        string navigateFrom = string.Empty;

        public string patientId
        {
            get
            {
                return txtPatientId.Text;
            }

            set
            {
                txtPatientId.Text = value;
            }
        }

        public string firstName
        {
            get
            {
                return txtFirstName.Text;
            }

            set
            {
                txtFirstName.Text = value;
            }
        }

        public string lastName
        {
            get
            {
                return txtLastName.Text;
            }

            set
            {
                txtLastName.Text = value;
            }
        }

        public string NIC
        {
            get
            {
                return txtNIC.Text;
            }

            set
            {
                txtNIC.Text = value;
            }
        }

        public string isNewSurgery
        {
            get
            {
                return hdnIsNewSurgery.Value;
            }

            set
            {
                hdnIsNewSurgery.Value = value;
            }
        }

        public string transactionStatusSuccess
        {
            set
            {
                lblSuccess.Text = value;
            }
        }

        public string transactionStatusFail
        {
            set
            {
                lblFail.Text = value;
            }
        }

        public int surgeryId
        {
            get
            {
                int id;
                if (hdnSurgeryId.Value == null || hdnSurgeryId.Value == "")
                {
                    id = 0;
                }
                else
                {
                    id = Convert.ToInt32(hdnSurgeryId.Value);
                }

                return id;
            }

            set
            {
                hdnSurgeryId.Value = value.ToString();
            }
        }

        //public string noRecordFound
        //{
        //    set
        //    {
        //        grdDisplayMessage.
        //    }
        //}

        public string doctor
        {
            get
            {
                return ddlDoctors.SelectedValue;
            }

            set
            {
                string wardOwner = value.Trim();
                ddlDoctors.ClearSelection();
                ListItem selectedOwner = ddlDoctors.Items.FindByValue(wardOwner);
                if (selectedOwner != null)
                {
                    selectedOwner.Selected = true;
                }
            }
        }

        public string wardNo
        {
            get
            {
                return ddlWardNo.SelectedValue;
            }

            set
            {
                string wardOwner = value.Trim();
                ddlWardNo.ClearSelection();
                ListItem selectedOwner = ddlWardNo.Items.FindByValue(wardOwner);
                if (selectedOwner != null)
                {
                    selectedOwner.Selected = true;
                }
            }
        }

        public DataTable wardDoctors
        {
            set
            {
                ddlDoctors.DataSource = value;
                ddlDoctors.DataTextField = "Owner";
                ddlDoctors.DataValueField = "EmployeeId";
                ddlDoctors.DataBind();
            }
        }

        public DataTable Wards
        {
            set
            {
                ddlWardNo.DataSource = value;
                ddlWardNo.DataTextField = "Wards";
                ddlWardNo.DataValueField = "WardNo";
                ddlWardNo.DataBind();
            }
        }

        public string admissionDate
        {
            get
            {
                return txtAdmissionDate.Text;
            }

            set
            {
                txtAdmissionDate.Text = value;
            }
        }

        public string surgeryDescription
        {
            get
            {
                return txtSurgeryDescription.Text;
            }

            set
            {
                txtSurgeryDescription.Text = value;
            }
        }

        public string surgeryDateFrom
        {
            get
            {
                return txtSurgeryDateFrom.Text;
            }

            set
            {
                txtSurgeryDateFrom.Text = value;
            }
        }

        public string surgeryDateTo
        {
            get
            {
                return txtSurgeryDateTo.Text;
            }

            set
            {
                txtSurgeryDateTo.Text = value;
            }
        }


        public string theatorId
        {
            get
            {
                return ddlTheators.SelectedValue;
            }

            set
            {
                string theator = value.Trim();
                ddlTheators.ClearSelection();
                ListItem selectedTheator = ddlTheators.Items.FindByValue(theator);
                if (selectedTheator != null)
                {
                    selectedTheator.Selected = true;
                }
            }
        }

        public DataTable availableTheators
        {
            set
            {
                if (value != null)
                {
                    gridViewTheators.DataSource = value;
                    gridViewTheators.DataBind();

                    if (value.Rows.Count > 0)
                    {
                        grdDisplayMessage.Style["display"] = "none";
                    }
                    else
                    {
                        grdDisplayMessage.Style["display"] = "block";
                    }
                }
                else
                {
                    DataTable emptyData = new DataTable();
                    gridViewTheators.DataSource = emptyData;
                    gridViewTheators.DataBind();
                    grdDisplayMessage.Style["display"] = "none";
                }
            }
        }

        public DataTable theators
        {
            set
            {
                ddlTheators.DataSource = value;
                ddlTheators.DataTextField = "TheatorId";
                ddlTheators.DataValueField = "TheatorId";
                ddlTheators.DataBind();
            }
        }

        public string surgeonApproval
        {
            get
            {
                return ddlSurgeonApprove.SelectedValue;
            }

            set
            {
                string surgeonApprove = value.Trim();
                ddlSurgeonApprove.ClearSelection();
                ListItem selectedApprove = ddlSurgeonApprove.Items.FindByValue(surgeonApprove);
                if (selectedApprove != null)
                {
                    selectedApprove.Selected = true;
                }
            }
        }

        public string surgeonDescription
        {
            get
            {
                return txtSurgeonDescription.Text;
            }

            set
            {
                txtSurgeonDescription.Text = value;
            }
        }

        public string anesthetistApproval
        {
            get
            {
                return ddlAnesthetistApprove.SelectedValue;
            }

            set
            {
                string anesthetistApprove = value.Trim();
                ddlAnesthetistApprove.ClearSelection();
                ListItem selectedApprove = ddlAnesthetistApprove.Items.FindByValue(anesthetistApprove);
                if (selectedApprove != null)
                {
                    selectedApprove.Selected = true;
                }
            }
        }

        public string anesthetistProblem
        {
            get
            {
                return txtAnestheticsProblems.Text;
            }

            set
            {
                txtAnestheticsProblems.Text = value;
            }
        }

        public string modeOfAnesthesia
        {
            get
            {
                return txtModeOfAnesthesia.Text;
            }

            set
            {
                txtModeOfAnesthesia.Text = value;
            }
        }

        public string directorApproval
        {
            get
            {
                return ddlDirectorApprove.SelectedValue;
            }

            set
            {
                string directorApprove = value.Trim();
                ddlDirectorApprove.ClearSelection();
                ListItem selectedApprove = ddlDirectorApprove.Items.FindByValue(directorApprove);
                if (selectedApprove != null)
                {
                    selectedApprove.Selected = true;
                }
            }
        }

        public string directorDescription
        {
            get
            {
                return txtDirectorDescription.Text;
            }

            set
            {
                txtDirectorDescription.Text = value;
            }
        }

        public string noRecordFould
        {
            set
            {
                lblNoPatientRecord.Text = value;
                if (lblNoPatientRecord.Text.Trim() == null || lblNoPatientRecord.Text.Trim() == "")
                {
                    btnSubmit.Enabled = true;
                }
                else
                {
                    btnSubmit.Enabled = false;
                }
            }
        }

        public string employeeId
        {
            get
            {
                string admittedBy = string.Empty;

                if (!string.IsNullOrEmpty(Session["id"] as string))
                {
                    admittedBy = Session["id"].ToString();
                }
                else
                {
                    admittedBy = "EMP-14";
                }
                return admittedBy;
            }
        }

        public string surggeryDetailIsEditable
        {
            get
            {
                return hdnSurggeryDetailIsEditable.Value;
            }
            set
            {
                hdnSurggeryDetailIsEditable.Value = value;
            }
        }

        public dynamic surgeryStatus
        {
            set
            {
                string userType = string.Empty;
                if (!string.IsNullOrEmpty(Session["role"] as string))
                {
                    userType = Session["role"].ToString();
                }
                else
                {
                    userType = "doctor";
                }

                if (IsPropertyExist(value) && navigateFrom == "app")
                {
                    if (userType == "doctor")
                    {
                        if (value.SurgeonApproval == "")
                        {
                            MainFormEditable(false);
                            SurgeonApprovalEditable(true);
                            AnesthetistApprovalEditable(false);
                            DirectorApprovalEditable(false);
                        }
                        else
                        {
                            MainFormEditable(false);
                            SurgeonApprovalEditable(false);
                            AnesthetistApprovalEditable(false);
                            DirectorApprovalEditable(false);
                        }
                    }
                    else if (userType == "anesthetist")
                    {
                        if (value.SurgeonApproval == "approved" && value.AnesthetistApproval == "")
                        {
                            MainFormEditable(false);
                            SurgeonApprovalEditable(false);
                            AnesthetistApprovalEditable(true);
                            DirectorApprovalEditable(false);
                        }
                        else
                        {
                            MainFormEditable(false);
                            SurgeonApprovalEditable(false);
                            AnesthetistApprovalEditable(false);
                            DirectorApprovalEditable(false);
                        }
                    }
                    else if (userType == "director")
                    {
                        if(value.SurgeonApproval == "approved" && value.AnesthetistApproval == "approved" && value.DirectorApproval =="")
                        {
                            MainFormEditable(false);
                            SurgeonApprovalEditable(false);
                            AnesthetistApprovalEditable(false);
                            DirectorApprovalEditable(true);
                        }
                        else
                        {
                            MainFormEditable(false);
                            SurgeonApprovalEditable(false);
                            AnesthetistApprovalEditable(false);
                            DirectorApprovalEditable(false);
                        }
                    }
                    else
                    {
                        MainFormEditable(false);
                        SurgeonApprovalEditable(false);
                        AnesthetistApprovalEditable(false);
                        DirectorApprovalEditable(false);
                    }
                    btnClear.Enabled = false;
                    txtPatientId.Enabled = false;
                    btnSearch.Enabled = false;
                }
                else if (navigateFrom == "lst")
                {
                    if(surggeryDetailIsEditable == "true" && userType == "doctor")
                    {
                        MainFormEditable(true);
                        SurgeonApprovalEditable(false);
                        AnesthetistApprovalEditable(false);
                        DirectorApprovalEditable(false);
                        btnSearch.Enabled = false;
                        txtPatientId.Enabled = false;
                        btnClear.Enabled = false;
                        btnSubmit.Text = "Update";
                    }
                    else
                    {
                        MainFormEditable(false);
                        SurgeonApprovalEditable(false);
                        AnesthetistApprovalEditable(false);
                        DirectorApprovalEditable(false);
                    }
                }
                else
                {
                    MainFormEditable(false);
                    SurgeonApprovalEditable(false);
                    AnesthetistApprovalEditable(false);
                    DirectorApprovalEditable(false);
                }                
            }
        }

        public SurgeryRegistration()
        {
            presenter = new SurgeryPresenter(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                presenter.LoadWardOwners();
                presenter.LoadWardsByDoctor();
                presenter.LoadTheaters();

                if ((Request.QueryString["frm"] != null) && (Request.QueryString["sid"] != null))
                {
                    isNewSurgery = "false";
                    navigateFrom = Request.QueryString["frm"];
                    surgeryId= Convert.ToInt32(Request.QueryString["sid"]);
                    presenter.GetSurgeryDetailsBySurgeryId();
                    presenter.GetSurgeryApprovalStatusById();
                }
                else
                {
                    isNewSurgery = "true";
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            presenter.RegisterSurgery();
            btnSubmit.Text = "Register";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            presenter.ClearHeaderInformation();
            presenter.ClearRegistrationInformation();
            btnSubmit.Text = "Register";
            btnSubmit.Enabled = false;

        }

        protected void gridViewSurgeryData_onClick(object sender, EventArgs e)
        {
        }

        protected void gridViewSurgeryRegistration_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewTheators.PageIndex = e.NewPageIndex;
            presenter.GetReservedTheators();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            presenter.GetPatientById();
            //hdnAdmissionDate.Value = "2018/4/19";
            //presenter.ClearHistoryInformation();
        }

        protected void SelectedDocorChanged(object sender, EventArgs e)
        {
            presenter.LoadWardsByDoctor();
        }

        protected void btnSearchTheator_Click(object sender, EventArgs e)
        {
            //hdnAdmissionDate.Value = admissionDate;
            //hdnSurgeryStart.Value = surgeryDateFrom;
            //hdnSurgeryEnd.Value = surgeryDateTo;
            presenter.GetReservedTheators();
            //Thread.Sleep(5000);
            //admissionDate = hdnAdmissionDate.Value;
            //surgeryDateFrom = hdnSurgeryStart.Value;
            //surgeryDateTo = hdnSurgeryEnd.Value;
        }

        private void MainFormEditable(bool status)
        {
            txtPatientId.Enabled = status;
            btnSearch.Enabled = status;
            ddlDoctors.Enabled = status;
            ddlWardNo.Enabled = status;
            txtSurgeryDescription.Enabled = status;
            ddlTheators.Enabled = status;
            btnSearchTheator.Enabled = status;
            btnSubmit.Enabled = status;
            btnClear.Enabled = status;
        }

        private void SurgeonApprovalEditable(bool status)
        {
            ddlSurgeonApprove.Enabled = status;
            txtSurgeonDescription.Enabled = status;
            btnSurgeonApproval.Enabled = status;
        }

        private void AnesthetistApprovalEditable(bool status)
        {
            ddlAnesthetistApprove.Enabled = status;
            txtAnestheticsProblems.Enabled = status;
            txtModeOfAnesthesia.Enabled = status;
            btnAnesthesiaOk.Enabled = status;
        }

        private void DirectorApprovalEditable(bool status)
        {
            ddlDirectorApprove.Enabled = status;
            txtDirectorDescription.Enabled = status;
            btnDirecctorApproval.Enabled = status;
        }

        public static bool IsPropertyExist(dynamic dynamicObj)
        {
            try
            {
                var value = dynamicObj.PatientId;
                return true;
            }
            catch (RuntimeBinderException)
            {
                return false;
            }
        }

        protected void btnSurgeonApproval_Click(object sender, EventArgs e)
        {
            presenter.SubmitSurgeonApproval();
            SurgeonApprovalEditable(false);
            lblSurgeonApprovalStatus.Text = "Approval Submitted Successfully";
        }

        protected void btnAnesthesiaOk_Click(object sender, EventArgs e)
        {
            presenter.SubmitAnesthesiaApproval();
            AnesthetistApprovalEditable(false);
            lblAnestheticsApprovalStatus.Text = "Approval Submitted Successfully";
        }

        protected void btnDirecctorApproval_Click(object sender, EventArgs e)
        {
            presenter.SubmitDirecctorApproval();
            DirectorApprovalEditable(false);
            lblDirectorApprovalStatus.Text = "Approval Submitted Successfully";
        }
    }
}