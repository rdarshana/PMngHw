using System;
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
    public partial class SurgeryApproval : System.Web.UI.Page, ISurgeryApprovalView
    {
        SurgeryApprovalPresenter presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                presenter.FillPatientGrid();
            }

        }

        public SurgeryApproval()
        {
            presenter = new SurgeryApprovalPresenter(this);
        }

        protected void gridViewSurgeryData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewSurgeryData.PageIndex = e.NewPageIndex;
            presenter.FillPatientGrid();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            presenter.GetEmployeeByKey();
        }

        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
            presenter.ClearFilter();
        }

        protected void GridViewPatient_onClick(object sender, EventArgs e)
        {
            //string selectedPatientId = (sender as LinkButton).CommandArgument;
            //patientId = selectedPatientId;

            //Response.Redirect("PatientRegistration.aspx?pid=" + patientId);
        }

        public DataTable surgeryData
        {
            set
            {
                if (value != null)
                {
                    gridViewSurgeryData.DataSource = value;
                    gridViewSurgeryData.DataBind();

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

        public string employeeId
        {
            get
            {
                return hdnEmployeeId.Value == "" ? string.Empty : hdnEmployeeId.Value;
            }

            set
            {
                hdnEmployeeId.Value = value;
            }
        }

        public string searchValue
        {
            get
            {
                return txtSearchId.Text;
            }
            set
            {
                txtSearchId.Text = value;
            }
        }

        public string searchColumn
        {
            get
            {
                string selectedValue = ddlEmployeeFilter.SelectedValue;
                string columnName = string.Empty;
                switch (selectedValue)
                {
                    case "patientId":
                        columnName = "PatientId";
                        break;
                    case "surgeryId":
                        columnName = "SurgeryId";
                        break;
                }

                return columnName;
            }
        }

        public string userType
        {
            get
            {
                string userType = string.Empty;
                if (!string.IsNullOrEmpty(Session["role"] as string))
                {
                    userType = Session["role"].ToString();
                }
                else
                {
                    userType = "doctor";
                }
                return userType;
            }
        }
    }
}