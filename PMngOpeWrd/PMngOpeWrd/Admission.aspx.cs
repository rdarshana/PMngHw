using PMngOpeWrd.Presenter;
using PMngOpeWrd.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMngOpeWrd
{
    public partial class Admission : System.Web.UI.Page, IAdmissionView
    {
        AdmissionPresenter presenter;
        public Admission()
        {
            presenter = new AdmissionPresenter(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                presenter.LoadWardOwners();
                presenter.GetAvailableBeds();
                

                if (Request.QueryString["admid"] != null)
                {
                    isNewAdmission = "false";
                    admissionId = Request.QueryString["admid"];
                    presenter.GetPatientAmissionStatusById();
                    removeQueryString = "admid";
                    removeQueryString = "admid";
                    txtPatientId.Enabled = false;
                    //presenter.GetEmployeeById();
                    btnSubmit.Text = "Update Admission";
                }
                else
                {
                    btnSubmit.Text = "Submit Admission";
                    isNewAdmission = "true";
                    //presenter.GetNextEmployeeId();
                    txtPatientId.Enabled = true;
                 }
            }
        }

        public string admissionId
        {
            get
            {
                return hdnAdmissionId.Value;
            }
            set
            {
                hdnAdmissionId.Value = value;
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

        public string isNewAdmission
        {
            get
            {
                return hdnIsNewAdmission.Value;
            }

            set
            {
                hdnIsNewAdmission.Value = value;
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

        public int availableBeds
        {
            set {
                txtAvailableBeds.Text = Convert.ToString(value);
            }
        }

        public string admissionDescription
        {
            get
            {
                return txtAdmission.Text;
            }
            set
            {
                txtAdmission.Text = value;
            }
        }

        public string dischargeDescription
        {
            get
            {
                return txtDischarge.Text;
            }
            set
            {
                txtDischarge.Text = value;
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

        public string admissionStatus
        {
            get
            {
                return hdnAdmissionStatus.Value;
            }

            set
            {
                if (value == "admitted")
                {
                    hdnAdmissionStatus.Value = "updateAdmission";
                }
                else if (value == "discharged")
                {
                    hdnAdmissionStatus.Value = "dischargeAdmission";
                }
                else
                {
                    hdnAdmissionStatus.Value = "newAdmission";
                    isNewAdmission = "true";
                }
            }
        }

        public string removeQueryString
        {
            set
            {
                PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                // make collection editable
                isreadonly.SetValue(this.Request.QueryString, false, null);
                // remove
                this.Request.QueryString.Remove(value);
            }
        }



        protected void btnClear_Click(object sender, EventArgs e)
        {
            //presenter.ClearEmployeeData();
            btnSubmit.Text = "Submit Admission";
            this.removeQueryString = "admid";
            //employeeRegistration = true;
            //employeeUpdate = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            presenter.AdmitPatient();
            btnSubmit.Text = "Submit Admission";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            presenter.GetPatientById();
            presenter.GetPatientAmissionStatusById();
            //presenter.ClearHistoryInformation();
        }

        protected void WardChanged(object sender, EventArgs e)
        {
            presenter.GetAvailableBeds();
        }
    }
}