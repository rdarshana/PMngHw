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

        public string employeeType
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

        public string employeeId
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

        public string address
        {
            get
            {
                return txtAddress.Text;
            }

            set
            {
                txtAddress.Text = value;
            }
        }

        public string mobilePhone
        {
            get
            {
                return txtMobilePhone.Text;
            }

            set
            {
                txtMobilePhone.Text = value;
            }
        }

        public string landPhone
        {
            get
            {
                return txtLandPhone.Text;
            }

            set
            {
                txtLandPhone.Text = value;
            }
        }

        public string email
        {
            get
            {
                return txtEmail.Text;
            }

            set
            {
                txtEmail.Text = value;
            }
        }

        public string isActive
        {
            get
            {
                string activeEmployee = "true";
                if(chkIsActive.Checked == true)
                {
                    activeEmployee = "true";
                }
                else
                {
                    activeEmployee = "false";
                }
                return activeEmployee;
            }

            set
            {
               if(value == "true")
                {
                    chkIsActive.Checked = true;
                }
                else
                {
                    chkIsActive.Checked = false;
                }
            }
        }

        public string isNewEmployee
        {
            get
            {
                return hdnIsNewEmployee.Value;
            }

            set
            {
                hdnIsNewEmployee.Value = value; 
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

            if (!IsPostBack)
            {
                if(Request.QueryString["eid"] != null)
                {
                    isNewEmployee = "false";
                    string employeeId = Request.QueryString["eid"];
                    string[] employeeIdSplit = employeeId.Split('-');
                    string employeeIdPrefix = employeeIdSplit[0];
                    string employeeType = string.Empty;

                    switch (employeeIdPrefix)
                    {
                        case "DOC":
                            employeeType = "doctor";
                            break;
                        case "ANE":
                            employeeType = "anesthetist";
                            break;
                        case "DIR":
                            employeeType = "director";
                            break;
                        case "MLT":
                            employeeType = "mlt";
                            break;
                    }
                    this.employeeType = employeeType;
                    this.employeeId = employeeId;
                    ddlEmployeeType.Enabled = false;
                    btnSubmit.Text = "Update";
                }
                else
                {
                    btnSubmit.Text = "Register";
                    isNewEmployee = "true";
                    presenter.GetNextEmployeeId();
                    ddlEmployeeType.Enabled = true;
                }

            }

           
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            presenter.RegisterEmployee();
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