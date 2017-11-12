using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMngOpeWrd.View;
using PMngOpeWrd.Presenter;

namespace PMngOpeWrd
{
    public partial class PatientRegistration : System.Web.UI.Page, IPatientRegistrationView
    {
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
                ddlGender.ClearSelection();
                ddlGender.Items.FindByValue(value).Selected = true;
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
                if (String.Equals(value, "Single"))
                {
                    radioStatusSingle.Checked = true;
                }
                else
                {
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
                ddlBloodGroup.ClearSelection();
                ddlBloodGroup.Items.FindByValue(value).Selected = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //read only a dateof birth contron in page load
                txtDateofBirth.Attributes.Add("readonly", "readonly");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            PatientRegistrationPresenter presenter = new PatientRegistrationPresenter(this);
            presenter.RegisterPatient();

        }
    }
}