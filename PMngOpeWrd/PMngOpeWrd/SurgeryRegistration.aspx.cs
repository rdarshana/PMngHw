using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMngOpeWrd
{
    public partial class SurgeryRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //isNewExamine = "true";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //presenter.AddPatientexamination();
            //presenter.GetPatientHistoryInformation();
            //btnSubmit.Text = "Add";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            //presenter.ClearPatientData();
            //presenter.ClearSearchPatientId();
            //btnSubmit.Text = "Add";
            //btnSubmit.Enabled = false;
            //this.patientData = null;

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
            //gridViewPatientExaminData.PageIndex = e.NewPageIndex;
            //presenter.GetPatientHistoryInformation();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //presenter.GetPatientById();
            //presenter.ClearHistoryInformation();
        }
    }
}