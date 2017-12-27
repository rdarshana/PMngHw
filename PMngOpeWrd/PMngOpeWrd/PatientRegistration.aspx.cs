﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMngOpeWrd.View;
using PMngOpeWrd.Presenter;
using System.Data;

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
                return hdnPatientId.Value == "" ? string.Empty : hdnPatientId.Value;
            }

            set
            {
                hdnPatientId.Value = value;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //read only a dateof birth contron in page load
                txtDateofBirth.Attributes.Add("readonly", "readonly");
                //presenter.FillPatientGrid();
                transactionStatusSuccess = string.Empty;
                transactionStatusFail = string.Empty;

                if (Request.QueryString["pid"] != null)
                {
                    this.patientId = Request.QueryString["pid"];
                    presenter.GetPatientById();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            presenter.RegisterPatient();
            btnSubmit.Text = "Register";

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
        }
    }
}