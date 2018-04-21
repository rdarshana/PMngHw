using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMngOpeWrd.View;
using PMngOpeWrd.Presenter;
using System.Reflection;

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

        public string password
        {
            get
            {
                return pwdPassword.Text;
            }

            set
            {
                pwdPassword.Text = value;
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
                if (chkIsActive.Checked == true)
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
                if (value == "true")
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

        public string transactionStatusSuccess
        {
            set
            {
                lblSuccess.Text = value;
            }
        }

        public string transactionStatusFail
        {
            set
            {
                lblFail.Text = value;
            }
        }

        public bool employeeRegistration
        {
            set
            {
                divEmployeeRegistration.Visible = value;
            }
        }

        public bool employeeUpdate
        {
            set
            {
                divEmployeeUpdate.Visible = value;
            }
        }

        public bool employeeTypeEnable
        {
            set
            {
                ddlEmployeeType.Enabled = value;
            }
        }

        public EmployeeRegistration()
        {
            presenter = new EmployeeRegistrationPresenter(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["empid"] != null)
                {
                    isNewEmployee = "false";
                    employeeId = Request.QueryString["empid"];
                    employeeType = Request.QueryString["emptyp"];
                    removeQueryString = "empid";
                    removeQueryString = "emptyp";
                    employeeTypeEnable = false;
                    presenter.GetEmployeeById();
                    btnSubmit.Text = "Update";
                    employeeRegistration = false;
                    employeeUpdate = true;

                    //if user edit his profile
                    if (Session["id"] as string == employeeId)
                    {
                        btnClear.Enabled = false;
                    }
                }
                else
                {
                    btnSubmit.Text = "Register";
                    isNewEmployee = "true";
                    presenter.GetNextEmployeeId();
                    ddlEmployeeType.Enabled = true;
                    employeeRegistration = true;
                    employeeUpdate = false;
                }
                ValidateFormPermission();
            }
        }

        private void ValidateFormPermission()
        {
            if (Session["id"] as string != employeeId)
            {
                string loginUserRole = Session["role"] as string;
                if (loginUserRole == "anesthetist" || loginUserRole == "doctor" || loginUserRole == "director")
                {
                    formEditable(false);
                }
            }
           
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            presenter.RegisterEmployee();
            btnSubmit.Text = "Register";

            if (Session["id"] as string == employeeId)
            {
                Response.Redirect("EmployeeInquiry.aspx");
            }

            presenter.ClearEmployeeData();
            presenter.GetNextEmployeeId();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            presenter.ClearEmployeeData();
            presenter.GetNextEmployeeId();
            btnSubmit.Text = "Register";
            this.removeQueryString = "empid";
            employeeRegistration = true;
            employeeUpdate = false;
        }

        protected void ddlEmployeeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.GetNextEmployeeId();
        }

        public string removeQueryString
        {
            set
            {
                PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                // make collection editable
                isreadonly.SetValue(this.Request.QueryString, false, null);
                // remove
                this.Request.QueryString.Remove(value);
            }
        }

        private void formEditable(bool status)
        {
            txtFirstName.Enabled = status;
            txtLastName.Enabled = status;
            pwdPassword.Visible = status;
            pwdConfirmPassword.Visible = status;
            txtNIC.Enabled = status;
            txtMobilePhone.Enabled = status;
            txtLandPhone.Enabled = status;
            txtAddress.Enabled = status;
            txtEmail.Enabled = status;
            chkIsActive.Enabled = status;
            btnClear.Enabled = status;
            btnSubmit.Enabled = status;
            ddlEmployeeType.Enabled = status;
        }
    }
}