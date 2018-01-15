using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMngOpeWrd.View;
using PMngOpeWrd.Presenter;

namespace PMngOpeWrd
{
    public partial class EmployeeRegistration : System.Web.UI.Page, IEmployeeRegistrationView
    {
        EmployeeRegistrationPresenter presenter;

        public string EmployeeType
        {
            get
            {
                return ddlEmployeeType.SelectedValue;
            }

            set
            {
                string employeeType = value.Trim();
                ddlEmployeeType.ClearSelection();
                ListItem selectedEmployee = ddlEmployeeType.Items.FindByValue(employeeType);
                if (selectedEmployee != null)
                {
                    selectedEmployee.Selected = true;
                }
            }
        }

        public string EmployeeId
        {
            get
            {
                return txtEmployeeId.Text;
            }

            set
            {
                txtEmployeeId.Text = value;
            }
        }

        public string firstName
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

        public string lastName
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

        public string NIC
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

        public string address
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

        public string mobilePhone
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

        public string landPhone
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

        public string email
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

        public string isActive
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

        public EmployeeRegistration()
        {
            presenter = new EmployeeRegistrationPresenter(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //txtAddress.Visible = false;
            //lblAddress.Visible = false;

            presenter.GetNextEmployeeId();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

        protected void ddlEmployeeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.GetNextEmployeeId();
        }
    }
}