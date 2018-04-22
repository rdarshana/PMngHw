using PMngOpeWrd.View;
using PMngOpeWrd.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMngOpeWrd
{
    public partial class OperationNote : System.Web.UI.Page, IOperationNoteView
    {
        OperationNotePresenter presenter;

        public OperationNote()
        {
            presenter = new OperationNotePresenter(this);
        }

        public int surgeryId
        {
            get
            {
                return Convert.ToInt32(txtSurgeryId.Text);
            }

            set
            {
                txtSurgeryId.Text = Convert.ToString(value);
            }
        }

        public string patientId
        {
            set
            {
                txtPatientId.Text = value;
            }
        }

        public string NIC
        {
            set
            {
                txtNIC.Text = value;
            }
        }

        public string doctor
        {
            set
            {
                txtDoctor.Text = value;
            }
        }

        public string description
        {
            set
            {
                txtDescription.Text = value;
            }
        }

        public string surgeryNote
        {
            get
            {
                return txtNote.Text;
            }

            set
            {
                txtNote.Text = value;
            }
        }

        public string surgeryStatus
        {
            get 
            {
                return ddlSurgeryStatus.SelectedValue;
            }

            set
            {
                string status= value.Trim();
                ddlSurgeryStatus.ClearSelection();
                ListItem selectedStatus = ddlSurgeryStatus.Items.FindByValue(status);
                if (selectedStatus != null)
                {
                    selectedStatus.Selected = true;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["sid"] != null)
                {
                    surgeryId = Convert.ToInt32(Request.QueryString["sid"]);
                    presenter.GetSurgeryDetailsById();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            presenter.SubmitPostSurgery();
            Response.Redirect("SurgeryList.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SurgeryList.aspx");
        }
    }
}