using PMngOpeWrd.View;
using PMngOpeWrd.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PMngOpeWrd
{
    public partial class PatientExamination : System.Web.UI.Page, IPatientExaminationView
    {

        PatientExaminationPresenter presenter;

        public PatientExamination()
        {
            presenter = new PatientExaminationPresenter(this);
        }

        public string noRecordFould
        {
            set
            {
                lblNoPatientRecord.Text = value;
                if(lblNoPatientRecord.Text.Trim() == null || lblNoPatientRecord.Text.Trim() == "")
                {
                    btnSubmit.Enabled = true;
                }
                else
                {
                    btnSubmit.Enabled = false;
                }
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

        public DataTable patientData
        {
            get
            {
                DataTable examineData = (DataTable)Session["examinedData"];
                return examineData;
            }
            set
            {
               
                    Session["examinedData"] = value;
                    gridViewPatientExaminData.DataSource = value;
                    gridViewPatientExaminData.DataBind();
                if (value != null)
                {
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
                    grdDisplayMessage.Style["display"] = "block";
                }
            }
        }

        public string complain
        {
            get
            {
                return txtComplain.Text;
            }

            set
            {
                txtComplain.Text = value;
            }
        }

        public string examination
        {
            get
            {
                 return txtExamination.Text;
            }

            set
            {
                txtExamination.Text = value;
            }
        }

        public string diagnosis
        {
            get
            {
                return txtDiagnosis.Text;
            }

            set
            {
                txtDiagnosis.Text = value;
            }
        }

        public string drugs
        {
            get
            {
                return txtDrugs.Text;
            }

            set
            {
                txtDrugs.Text = value;
            }
        }

        public string isNewExamine
        {
            get
            {
                return hdnIsNewExamine.Value;
            }

            set
            {
                hdnIsNewExamine.Value = value;
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
                return Session["id"].ToString();
            }
        }

        public int examineId
        {
            get
            {
                int id;
                if(hdnExamineId.Value == null || hdnExamineId.Value == "")
                {
                    id = 0; 
                }
                else
                {
                    id = Convert.ToInt32(hdnExamineId.Value);
                }

                return id;
            }
            set
            {
                hdnExamineId.Value = value.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                isNewExamine = "true";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            presenter.AddPatientexamination();
            presenter.GetPatientHistoryInformation();
            btnSubmit.Text = "Add";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            presenter.ClearPatientData();
            presenter.ClearSearchPatientId();
            btnSubmit.Text = "Add";
            btnSubmit.Enabled = false;
            this.patientData = null;

        }

        protected void gridViewExaminationData_onClick(object sender, EventArgs e)
        {
             examineId =Convert.ToInt32((sender as LinkButton).CommandArgument);
             isNewExamine = "false";
            btnSubmit.Text = "Update";
            transactionStatusSuccess = string.Empty;
             transactionStatusFail = string.Empty;
            presenter.GetDataSelectedById();
        }

        protected void gridViewExaminationData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewPatientExaminData.PageIndex = e.NewPageIndex;
            presenter.GetPatientHistoryInformation();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            presenter.GetPatientById();
            presenter.ClearHistoryInformation();
        }
    }
}
