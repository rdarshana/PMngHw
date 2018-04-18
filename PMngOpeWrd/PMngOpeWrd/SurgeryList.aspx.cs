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
            //presenter.FillPatientGrid();
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
           // presenter.FillPatientGrid();
        }

        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
           // presenter.ClearFilter();
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