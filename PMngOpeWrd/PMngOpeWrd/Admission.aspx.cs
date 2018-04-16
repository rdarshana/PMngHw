using Microsoft.CSharp.RuntimeBinder;
using PMngOpeWrd.Presenter;
using PMngOpeWrd.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
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
            set
            {
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
                    hdnAdmissionStatus.Value = value;
            }
        }

        public dynamic admissionHistory
        {
            set
            {
         
                object valueProperty = ((ExpandoObject)value);

                if (IsPropertyExist(value))
                {
                    admissionStatus = value.status;

                    if (value.status == "admitted")
                    {
                        admissionId = Convert.ToString(value.Id);
                        admissionDescription = value.AdmissionDescription;
                        dischargeDescription = value.DischargeDescription;
                        wardNo = value.WardNo;
                        txtAdmission.Enabled = true;
                        txtDischarge.Enabled = true;
                        ddlWardNo.Enabled = true;
                        btnSubmit.Enabled = true;
                        btnUpdate.Enabled = true;
                        btnSubmit.Text = "Discharge";
                        admissionStatus = "dischargeAdmission";
                        divDischarge.Visible = true;
                        isNewAdmission = "false";
                    }
                    else
                    {
                        if (value.status == "discharged" && dataFrom == "query")
                        {
                            admissionId = Convert.ToString(value.Id);
                            admissionDescription = value.AdmissionDescription;
                            dischargeDescription = value.DischargeDescription;
                            wardNo = value.WardNo;
                            btnSubmit.Text = "Discharge";
                            btnSubmit.Enabled = false;
                            btnUpdate.Enabled = false;
                            ddlWardNo.Enabled = false;
                            txtAdmission.Enabled = false;
                            txtDischarge.Enabled = false;
                            divDischarge.Visible = true;
                            isNewAdmission = "false";
                            admissionStatus = "dischargeAdmission";
                        }
                        else if (value.status == "discharged" && dataFrom == "search")
                        {
                            admissionId = Convert.ToString(value.Id);
                            admissionDescription = string.Empty;
                            dischargeDescription = string.Empty;
                            txtDischarge.Enabled = true;
                            txtAdmission.Enabled = true;
                            ddlWardNo.Enabled = true;
                            btnSubmit.Text = "Admit";
                            btnSubmit.Enabled = true;
                            btnUpdate.Enabled = false;
                            isNewAdmission = "true";
                            divDischarge.Visible = false;
                            admissionStatus = "newAdmission";
                        }
                        else
                        {
                            admissionId = Convert.ToString(value.Id);
                            admissionDescription = string.Empty;
                            dischargeDescription = string.Empty;
                            txtDischarge.Enabled = true;
                            txtAdmission.Enabled = true;
                            ddlWardNo.Enabled = true;
                            btnSubmit.Text = "Admit";
                            btnSubmit.Enabled = true;
                            btnUpdate.Enabled = false;
                            divDischarge.Visible = false;
                            isNewAdmission = "true";
                        }
                    }
                }
                else
                {
                    admissionDescription = string.Empty;
                    dischargeDescription = string.Empty;
                    txtAdmission.Enabled = true;
                    txtDischarge.Enabled = true;
                    ddlWardNo.Enabled = true;
                    btnSubmit.Text = "Admit";
                    btnSubmit.Enabled = true;
                    btnUpdate.Enabled = false;
                    admissionStatus = "newAdmission";
                    divDischarge.Visible = false;
                    isNewAdmission = "true";
                }
            }
        }

        public string dataFrom
        {
            get
            {
                return hdnDataFrom.Value;
            }
            set
            {
                hdnDataFrom.Value = value;
            }
        }

        public bool wardNoEnable
        {
            set
            {
                ddlWardNo.Enabled = value;
                lblSurgeryNotification.Visible = !value;
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
                presenter.LoadWardOwners();
                presenter.GetAvailableBeds();

                if (Request.QueryString["admid"] != null)
                {
                    dataFrom = "query";
                    isNewAdmission = "false";
                    admissionId = Request.QueryString["admid"];
                    presenter.GetPatientAmissionStatusById();
                    //lblSurgeryNotification.Visible = false;
                    //presenter.GetIsPatientAdmitForSurgery();
                    removeQueryString = "admid";
                    removeQueryString = "admid";
                    txtPatientId.Enabled = false;
                    btnSearch.Enabled = false;
                    presenter.GetAdmissionDetailById();
                    presenter.GetAvailableBeds();
                    btnUpdate.Enabled = true;
                }
                else
                {
                    dataFrom = "search";
                    btnSubmit.Text = "Admit";
                    isNewAdmission = "true";
                    btnUpdate.Enabled = false;
                    btnSearch.Enabled = true;
                    txtPatientId.Enabled = true;
                }
                presenter.GetPatientAmissionStatusById();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            lblSurgeryNotification.Visible = false;
            presenter.ClearAdmissionData();
            btnSubmit.Text = "Admit";
            removeQueryString = "admid";
            divDischarge.Visible = false;
            txtPatientId.Enabled = true;
            btnSearch.Enabled = true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            presenter.AdmitPatient();
            btnSubmit.Text = "Admit";
            txtPatientId.Enabled = true;
            btnSearch.Enabled = true;
        }

        protected void btnSubmitUpdate_Click(object sender, EventArgs e)
        {
            admissionStatus = "updateAdmission";
            presenter.AdmitPatient();
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblSurgeryNotification.Visible = false;
            dataFrom = "search";
            presenter.GetPatientById();
            presenter.GetPatientAmissionStatusById();
            presenter.GetAvailableBeds();
            presenter.GetIsPatientAdmitForSurgery();
            txtPatientId.Enabled = false;
            btnSearch.Enabled = false;
        }

        protected void WardChanged(object sender, EventArgs e)
        {
            presenter.GetAvailableBeds();
        }

        public static bool IsPropertyExist(dynamic dynamicObj)
        {
            try
            {
                var value = dynamicObj.status;
                return true;
            }
            catch (RuntimeBinderException)
            {

                return false;
            }

        }

    }
}