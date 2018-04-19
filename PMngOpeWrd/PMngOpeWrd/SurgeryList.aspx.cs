using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMngOpeWrd.Presenter;
using PMngOpeWrd.View;
using System.Data;

namespace PMngOpeWrd
{
    public partial class SurgeryList : System.Web.UI.Page, ISurgeryListView
    {
        SurgeryListPresenter presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                presenter.LoadWardOwners();
                string thisDay = DateTime.Now.ToString("yyyy/MM/dd");
                txtSurgeryDateFrom.Text = thisDay;
                txtSurgeryDateTo.Text = thisDay;
                presenter.FillPatientGrid();
            }

        }

        public SurgeryList()
        {
            presenter = new SurgeryListPresenter(this);
        }

        protected void gridViewSurgeryList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewSurgeryList.PageIndex = e.NewPageIndex;
            presenter.FillPatientGrid();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int parsedValue;
            if (searchColumn == "SurgeryId")
            {
                if (!int.TryParse(searchValue, out parsedValue))
                {
                    lblSurgeryIdInValid.Text = "Surgery Id Should be a Number";
                    DataTable emptyData = new DataTable();
                    surgeryData = emptyData;
                    return;
                }
            }
            lblSurgeryIdInValid.Text = string.Empty;
            presenter.FillPatientGrid();
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
                    gridViewSurgeryList.DataSource = value;
                    gridViewSurgeryList.DataBind();

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
                string selectedValue = ddlPatientFilter.SelectedValue;
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
            set
            {
                string defaultFilter = value.Trim();
                ddlPatientFilter.ClearSelection();
                ListItem selectedColumn = ddlPatientFilter.Items.FindByValue(defaultFilter);
                if (selectedColumn != null)
                {
                    selectedColumn.Selected = true;
                }
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

        public string doctor
        {
            get
            {
                return ddlDoctors.SelectedValue;
            }

            set
            {
                string wardOwner = value.Trim();
                ddlDoctors.ClearSelection();
                ListItem selectedOwner = ddlDoctors.Items.FindByValue(wardOwner);
                if (selectedOwner != null)
                {
                    selectedOwner.Selected = true;
                }
            }
        }

        public DataTable wardDoctors
        {
            set
            {
                ddlDoctors.DataSource = value;
                ddlDoctors.DataTextField = "Owner";
                ddlDoctors.DataValueField = "EmployeeId";
                ddlDoctors.DataBind();
            }
        }

        public string status
        {
            get
            {
                return ddlSurgeryStatus.SelectedValue;
            }

            set
            {
                string surgeryStatus = value.Trim();
                ddlSurgeryStatus.ClearSelection();
                ListItem selectedStatus = ddlSurgeryStatus.Items.FindByValue(surgeryStatus);
                if (selectedStatus != null)
                {
                    selectedStatus.Selected = true;
                }
            }
        }

        public string surgeryStartFrom
        {
            get
            {
               return txtSurgeryDateFrom.Text;
            }
            set
            {
                txtSurgeryDateFrom.Text = value;
            }
        }
        public string surgeryStartTo
        {
            get
            {
                return txtSurgeryDateTo.Text;
            }
            set
            {
                txtSurgeryDateTo.Text = value;
            }
        }

        public string admissionFrom
        {
            get
            {
                return txtAdmissionDateFrom.Text;
            }
            set
            {
                txtAdmissionDateFrom.Text = value;
            }
        }

        public string admissionTo
        {
            get
            {
                return txtAdmissionDateTo.Text;
            }
            set
            {
                txtAdmissionDateTo.Text = value;
            }
        }

    }
}