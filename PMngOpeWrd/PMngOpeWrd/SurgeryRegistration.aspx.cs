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

namespace PMngOpeWrd
{
    public partial class SurgeryRegistration : System.Web.UI.Page, ISurgeryView
    {
        SurgeryPresenter presenter;

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
                ddlWardNo.DataTextField = "WardNo";
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
                ddlDoctors.ClearSelection();
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
                ddlSurgeonApprove.ClearSelection();
                ListItem selectedApprove = ddlSurgeonApprove.Items.FindByValue(directorApprove);
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

        public SurgeryRegistration()
        {
            presenter = new SurgeryPresenter(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                isNewSurgery = "true";
                presenter.LoadWardOwners();
                presenter.LoadWardsByDoctor();
                presenter.LoadTheaters();
            }
            else
            {

            }
           
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            presenter.RegisterSurgery();
            //presenter.GetPatientHistoryInformation();
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
            //examineId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            //isNewExamine = "false";
            //btnSubmit.Text = "Update";
            //transactionStatusSuccess = string.Empty;
            //transactionStatusFail = string.Empty;
            //presenter.GetDataSelectedById();
        }

        protected void gridViewSurgeryRegistration_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewTheators.PageIndex = e.NewPageIndex;
            presenter.GetReservedTheators();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
             presenter.GetPatientById();
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
    }
}