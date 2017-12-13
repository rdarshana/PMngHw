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
    public partial class PatientInquiry : System.Web.UI.Page, IPatientInquiryView
    {
        PatientInquiryPresenter presenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            presenter.FillPatientGrid();
        }

        public PatientInquiry()
        {
            presenter = new PatientInquiryPresenter(this);
        }

        /// <summary>
        /// fill grid data
        /// </summary>
        public DataTable patientsData
        {
            set
            {
                gridViewPatientData.DataSource = value;
                gridViewPatientData.DataBind();

            }
        }

        public string patientId
        {
            get
            {
                return hdnPatientId.Value == "" ? string.Empty : hdnPatientId.Value;
            }

            set
            {
                hdnPatientId.Value = value;
            }
        }

        //when row click, open patient information
        protected void GridViewPatient_onClick(object sender, EventArgs e)
        {
            string selectedPatientId = (sender as LinkButton).CommandArgument;
            patientId = selectedPatientId;

            Response.Redirect("PatientRegistration.aspx?pid="+patientId);
        }

        protected void PatientView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}