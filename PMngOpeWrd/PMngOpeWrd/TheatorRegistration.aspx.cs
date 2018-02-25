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
    public partial class TheatorRegistration : System.Web.UI.Page, ITheatorRegistrationView
    {
        TheatorRegistrationPresenter presenter;
        public string theatorId
        {
            get
            {
                return txtTheatorId.Text;
            }

            set
            {
                txtTheatorId.Text = value;
            }
        }

        public string description
        {
            get
            {
                return txtDescription.Text;
            }

            set
            {
                txtDescription.Text = value;
            }
        }

        public DataTable theatorData
        {
            set
            {
                if (value != null)
                {
                    gridViewTheatereData.DataSource = value;
                    gridViewTheatereData.DataBind();

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

        public string isNewTheator
        {
            get
            {
                return hdnIsNewTheator.Value;
            }

            set
            {
                hdnIsNewTheator.Value = value;
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

        public string isActive
        {
            get
            {
                string activeTheator = "true";
                if (chkIsActive.Checked == true)
                {
                    activeTheator = "true";
                }
                else
                {
                    activeTheator = "false";
                }
                return activeTheator;
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

        public TheatorRegistration()
        {
            presenter = new TheatorRegistrationPresenter(this);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            isNewTheator = "true";
            presenter.LoadNextTheatorId();
            presenter.LoadAllTheaterData();
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            presenter.RegisterTheator();
            btnSubmit.Text = "Register";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            presenter.ClearTheaterInfomation();
            btnSubmit.Text = "Register";

            //employeeRegistration = true;
            //employeeUpdate = false;
        }

        protected void GridViewTheator_onClick(object sender, EventArgs e)
        {
           theatorId = (sender as LinkButton).CommandArgument;
            presenter.GetTheaterById();
            btnSubmit.Text = "Update";
            isNewTheator = "true";
        }

        protected void gridViewTheaterData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewTheatereData.PageIndex = e.NewPageIndex;
            presenter.LoadAllTheaterData();
        }

    }
}