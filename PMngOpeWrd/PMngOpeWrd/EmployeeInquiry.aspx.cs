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
    public partial class EmployeeInquiry : System.Web.UI.Page , IEmployeeInquiryView
    {
        EmployeeInquiryPresenter presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                presenter.FillPatientGrid();
            }

        }

        public EmployeeInquiry()
        {
            presenter = new EmployeeInquiryPresenter(this);
        }

        protected void gridViewEmployeeData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewEmployeeData.PageIndex = e.NewPageIndex;
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

      
        public DataTable employeeData
        {
            set
            {
                if (value != null)
                {
                    gridViewEmployeeData.DataSource = value;
                    gridViewEmployeeData.DataBind();

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

        public string searchColumn
        {
            get
            {
                string selectedValue = ddlEmployeeFilter.SelectedValue;
                string columnName = string.Empty;
                switch (selectedValue)
                {
                    case "employeeId":
                        columnName = "EmployeeId";
                        break;
                    case "nic":
                        columnName = "NIC";
                        break;
                    case "firstName":
                        columnName = "FirstName";
                        break;
                }

                return columnName;
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
    }
}