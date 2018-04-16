using PMngOpeWrd.Presenter;
using PMngOpeWrd.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMngOpeWrd
{
    public partial class AdmissionInquery : System.Web.UI.Page, IAdmissionInqueryView
    {
        AdmissionInqueryPresenter presenter;
       
        public AdmissionInquery()
        {
            presenter = new AdmissionInqueryPresenter(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                presenter.FillPatientAdmissionGrid();
            }
        }

        protected void gridViewAdmissionData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //gridViewSurgeryData.PageIndex = e.NewPageIndex;
            //presenter.FillPatientGrid();
        }

        protected void btnSearchFilter_Click(object sender, EventArgs e)
        {
            //presenter.GetEmployeeByKey();
            presenter.FillPatientAdmissionGridBySearchValues();
        }

        protected void GridViewPatient_onClick(object sender, EventArgs e)
        {
            //string selectedPatientId = (sender as LinkButton).CommandArgument;
            //patientId = selectedPatientId;

            //Response.Redirect("PatientRegistration.aspx?pid=" + patientId);
        }

        public string patientId
        {
            get
            {
                return txtPatientId.Text.Trim();
            }

            set
            {
                txtPatientId.Text = value;
            }
        }

        public DataTable admissionData
        {
            set
            {
                if (value != null)
                {
                    gridViewAdmissionData.DataSource = value;
                    gridViewAdmissionData.DataBind();

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

        public string status
        {
            get
            {
                //return ddlStatus.SelectedValue;

                string selectedValue = ddlStatus.SelectedValue;
                string selectedStatus = string.Empty;
                switch (selectedValue)
                {
                    case "admitted":
                        selectedStatus = "admitted";
                        break;
                    case "discharged":
                        selectedStatus = "discharged";
                        break;
                    case "all":
                        selectedStatus = "";
                        break;
                }
                return selectedStatus;
            }
            set
            {
                string status = value.Trim();
                ddlStatus.ClearSelection();
                ListItem selectedStatus = ddlStatus.Items.FindByValue(status);
                if (selectedStatus != null)
                {
                    selectedStatus.Selected = true;
                }
            }
        }
    }
}