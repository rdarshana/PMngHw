using PMngOpeWrd.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PMngOpeWrd.Presenter;

namespace PMngOpeWrd
{
    public partial class WardRegistration : System.Web.UI.Page, IWardRegistrationView
    {
        WardRegistrationPresenter presenter;

        public string isActive
        {
            get
             {
                string activeWard = "true";
                if (chkIsActive.Checked == true)
                {
                    activeWard = "true";
                }
                else
                {
                    activeWard = "false";
                }
                return activeWard;
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

        public string isNewWard
        {
            get
            {
                return hdnIsNewWard.Value;
            }

            set
            {
                hdnIsNewWard.Value = value;
            }
        }

        public int noOfBeds
        {
            get
            {
                return Convert.ToInt32(txtNoOfBeds.Text.Trim());
            }

            set
            {
                txtNoOfBeds.Text = value.ToString();
            }
        }

        public string owner
        {
            get
            {
                return ddlOwner.SelectedValue;
            }

            set
            {
                string wardOwner = value.Trim();
                ddlOwner.ClearSelection();
                ListItem selectedWard = ddlOwner.Items.FindByValue(wardOwner);
                if (selectedWard != null)
                {
                    selectedWard.Selected = true;
                }
            }
        }

        public string transactionStatusFail
        {
            set
            {
                lblFail.Text = value;
            }
        }

        public string transactionStatusSuccess
        {
            set
            {
                lblSuccess.Text = value;
            }
        }

        public string type
        {
            get
            {
                return ddlType.SelectedValue;
            }

            set
            {
                string wardType = value.Trim();
                ddlOwner.ClearSelection();
                ListItem selectedType = ddlOwner.Items.FindByValue(wardType);
                if (selectedType != null)
                {
                    selectedType.Selected = true;
                }
            }
        }

        public DataTable wardData
        {
            set
            {
                if (value != null)
                {
                    gridViewWardData.DataSource = value;
                    gridViewWardData.DataBind();

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

        public string wardNo
        {
            get
            {
                return txtWardNo.Text.Trim();
            }

            set
            {
                txtWardNo.Text = value;
            }
        }

        public DataTable loadWardOwners
        {
            set
            {
                ddlOwner.DataSource = value;
                ddlOwner.DataTextField = "Owner";
                ddlOwner.DataValueField = "EmployeeID";
                ddlOwner.DataBind();
            }
        }

        public WardRegistration()
        {
            presenter = new WardRegistrationPresenter(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                isNewWard = "true";
                presenter.LoadNextWardId();
                presenter.LoadAllWardData();
                presenter.LoadWardOwners();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            presenter.RegisterWard();
            presenter.LoadAllWardData();
            btnSubmit.Text = "Register";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            presenter.ClearWardInfomation();
            btnSubmit.Text = "Register";
        }

        protected void GridViewTheator_onClick(object sender, EventArgs e)
        {
            wardNo = (sender as LinkButton).CommandArgument;
            presenter.GetWardById();
            btnSubmit.Text = "Update";
            isNewWard = "false";
            transactionStatusSuccess = string.Empty;
            transactionStatusFail = string.Empty;
        }

        protected void gridViewTheaterData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewWardData.PageIndex = e.NewPageIndex;
            presenter.LoadAllWardData();
        }
    }
}