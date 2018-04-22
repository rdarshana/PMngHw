using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMngOpeWrd.View;
using PMngOpeWrd.Presenter;
using System.Data;
using System.Reflection;

namespace PMngOpeWrd
{
    public partial class PatientRegistration : System.Web.UI.Page, IPatientRegistrationView
    {
        PatientRegistrationPresenter presenter;

        public PatientRegistration()
        {
            presenter = new PatientRegistrationPresenter(this);
        }

        public string address
        {
            get
            {
                return txtAddress.Text;
            }

            set
            {
                txtAddress.Text = value;
            }
        }

        public string dateOfBirth
        {
            get
            {
                return txtDateofBirth.Text;
            }

            set
            {
                txtDateofBirth.Text = value;
            }
        }

        public string email
        {
            get
            {
                return txtEmail.Text;
            }

            set
            {
                txtEmail.Text = value;
            }
        }

        public string emergencyContact
        {
            get
            {
                return txtEmergencyContact.Text.Trim();
            }

            set
            {
                txtEmergencyContact.Text = value;
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

        public string gender
        {
            get
            {
                return ddlGender.SelectedValue;
            }

            set
            {
                string gender = value.Trim();
                ddlGender.ClearSelection();
                ListItem selectedGender = ddlGender.Items.FindByValue(gender);
                if (selectedGender != null)
                {
                    selectedGender.Selected = true;
                }

            }
        }

        public string landPhone
        {
            get
            {
                return txtLandPhone.Text;
            }

            set
            {
                txtLandPhone.Text = value;
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

        public string maritalStatus
        {
            get
            {
                string status;
                if (radioStatusSingle.Checked)
                {
                    status = "Single";
                }
                else
                {
                    status = "Married";
                }
                return status;
            }

            set
            {
                if (string.Equals(value, "Single"))
                {
                    radioStatusMarried.Checked = false;
                    radioStatusSingle.Checked = true;
                }
                else
                {
                    radioStatusSingle.Checked = false;
                    radioStatusMarried.Checked = true;
                }
            }
        }

        public string mobilePhone
        {
            get
            {
                return txtMobilePhone.Text;
            }

            set
            {
                txtMobilePhone.Text = value;
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

        public string bloodGroup
        {
            get
            {
                return ddlBloodGroup.SelectedValue;
            }

            set
            {
                string bloodGroup = value.Trim();
                ddlBloodGroup.ClearSelection();
                ListItem itemtoSelect = ddlBloodGroup.Items.FindByValue(bloodGroup);
                if (itemtoSelect != null)
                {
                    itemtoSelect.Selected = true;
                }
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

        public string gardianName
        {
            get
            {
                return txtGardianName.Text;
            }

            set
            {
                txtGardianName.Text = value;
            }
        }

        public string gardianAddress
        {
            get
            {
                return txtGardianAddress.Text;
            }

            set
            {
                txtGardianAddress.Text = value;
            }
        }

        public string isNewPatient
        {
            get
            {
                return hdnIsNewPatient.Value;


            }
            set
            {
                hdnIsNewPatient.Value = value;
            }
        }

        public bool patientRegistration
        {
            set
            {
                divPatientRegistration.Visible = value;
            }
        }

        public bool patientUpdate
        {
            set
            {
                divPatientUpdate.Visible = value;
            }
        }

        public string NICNumberError
        {
            set
            {
                lblNICInValid.Text = value;
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
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //read only a dateof birth control in page load
                txtDateofBirth.Attributes.Add("readonly", "readonly");
                //presenter.FillPatientGrid();
                transactionStatusSuccess = string.Empty;
                transactionStatusFail = string.Empty;

                if (Request.QueryString["pid"] != null)
                {
                    string patientID = Request.QueryString["pid"];
                    isNewPatient = "false";
                    this.patientId = patientID;
                    presenter.GetPatientById();
                    btnSubmit.Text = "Update";
                    this.removeQueryString = "pid";
                    patientRegistration = false;
                    patientUpdate = true;
                }
                else
                {
                    isNewPatient = "true";
                    patientRegistration = true;
                    patientUpdate = false;
                    presenter.GetNextPatientId();
                }
                ValidateFormPermission();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            transactionStatusFail = string.Empty;
            transactionStatusSuccess = string.Empty;

            presenter.RegisterPatient();

            if (lblNICInValid.Text == "")
            {
                btnSubmit.Text = "Register";
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            presenter.DeletePatientById();
            btnSubmit.Text = "Register";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            presenter.ClearPatientData();
            btnSubmit.Text = "Register";
            this.removeQueryString = "pid";
        }

        private void ValidateFormPermission()
        {
            if (!string.IsNullOrEmpty(Session["role"] as string))
            {
                string loginUserRole = Session["role"] as string;
                if (loginUserRole == "anesthetist" || loginUserRole == "administrator" || loginUserRole == "director")
                {
                    formEditable(false);
                }
            }
        }

        private void formEditable(bool status)
        {
            txtFirstName.Enabled = status;
            txtLastName.Enabled = status;
            txtNIC.Enabled = status;
            ddlGender.Enabled = status;
            radioStatusMarried.Enabled = status;
            radioStatusSingle.Enabled = status;
            ddlBloodGroup.Enabled = status;
            txtAddress.Enabled = status;
            txtMobilePhone.Enabled = status;
            txtLandPhone.Enabled = status;
            txtEmail.Enabled = status;
            txtGardianName.Enabled = status;
            txtGardianAddress.Enabled = status;
            txtEmergencyContact.Enabled = status;
            btnClear.Enabled = status;
            btnSubmit.Enabled = status;
        }
    }
}