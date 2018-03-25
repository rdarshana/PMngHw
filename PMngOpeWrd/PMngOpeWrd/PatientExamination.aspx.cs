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
        public string transactionStatusSuccess
        {
            set
            {
                throw new NotImplementedException();
            }
        }

        public string transactionStatusFail
        {
            set
            {
                throw new NotImplementedException();
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
            set
            {
                if (value != null)
                {
                    gridViewPatientExaminData.DataSource = value;
                    gridViewPatientExaminData.DataBind();

                    if (value.Rows.Count > 0)
                    {
                        grdDisplayMessage.Style["display"] = "none";
                    }
                    else
                    {
                        grdDisplayMessage.Style["display"] = "block";
                    }
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
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //isNewWard = "true";
                //presenter.LoadNextWardId();
                //presenter.LoadAllWardData();
                //presenter.LoadWardOwners();
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //presenter.RegisterWard();
            //presenter.LoadAllWardData();
            //btnSubmit.Text = "Register";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            //presenter.ClearWardInfomation();
            //btnSubmit.Text = "Register";
        }

        protected void gridViewExaminationData_onClick(object sender, EventArgs e)
        {
            //wardNo = (sender as LinkButton).CommandArgument;
            //presenter.GetWardById();
            //btnSubmit.Text = "Update";
            //isNewWard = "false";
            //transactionStatusSuccess = string.Empty;
            //transactionStatusFail = string.Empty;
        }

        protected void gridViewExaminationData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //gridViewWardData.PageIndex = e.NewPageIndex;
            //presenter.LoadAllWardData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            presenter.GetPatientById();
        }
        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
           // presenter.ClearFilter();
        }
    }
}
