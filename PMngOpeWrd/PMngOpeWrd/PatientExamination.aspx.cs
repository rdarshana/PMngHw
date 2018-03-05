using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMngOpeWrd
{
    public partial class PatientExamination : System.Web.UI.Page
    {
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
    }
}
