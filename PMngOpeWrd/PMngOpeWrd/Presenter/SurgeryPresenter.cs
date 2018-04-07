using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMngOpeWrd.View;
using PMngOpeWrd.Model;
using System.Dynamic;
using System.Data;

namespace PMngOpeWrd.Presenter
{
    public class SurgeryPresenter
    {
        ISurgeryView surgeryView;
        SurgeryModel surgeryModel;
        WardModel wardModel;
        PatientRegistrationModel patientRegModel;

        public SurgeryPresenter(ISurgeryView view)
        {
            surgeryView = view;
            surgeryModel = new SurgeryModel();
            wardModel = new WardModel();
            patientRegModel = new PatientRegistrationModel();
        }

        internal void LoadWardOwners()
        {
            surgeryView.wardDoctors = surgeryModel.LoadWardOwners();

        }

        internal void LoadWardsByDoctor()
        {
            surgeryView.Wards = surgeryModel.LoadWardsByDoctor(surgeryView.doctor);
        }

        internal void LoadTheaters()
        {
            surgeryView.theators = surgeryModel.LoadAllTheaters();
        }

        internal void GetPatientById()
        {
            if (surgeryView.patientId.Trim() == null || surgeryView.patientId.Trim() == "")
            {
                surgeryView.noRecordFould = "Please Enter Patient ID";
                ClearRegistrationInformation();
                ClearHeaderInformation();
            }
            else
            {
                GetPatientBasicInformation();
            }
        }

        private void GetPatientBasicInformation()
        {
            DataTable patientData = patientRegModel.GetPatientById(surgeryView.patientId);
            if (patientData.Rows.Count > 0)
            {
                surgeryView.firstName = patientData.Rows[0]["FirstName"].ToString();
                surgeryView.lastName = patientData.Rows[0]["LastName"].ToString();
                surgeryView.NIC = patientData.Rows[0]["NIC"].ToString();
                surgeryView.noRecordFould = null;
            }
            else
            {
                surgeryView.noRecordFould = "There is no mathing patient";
                surgeryView.transactionStatusSuccess = string.Empty;
                surgeryView.transactionStatusFail = string.Empty;
                surgeryView.isNewSurgery = "true";
                ClearHeaderInformation();
                ClearRegistrationInformation();
            }
        }

        internal void ClearHeaderInformation()
        {
            surgeryView.NIC = string.Empty;
            surgeryView.firstName = string.Empty;
            surgeryView.lastName = string.Empty;
        }

        internal void ClearRegistrationInformation()
        {
            LoadWardsByDoctor();
            LoadWardsByDoctor();
            LoadTheaters();
            surgeryView.isNewSurgery = "true";
            surgeryView.admissionDate = string.Empty;
            surgeryView.surgeryDescription = string.Empty;
            surgeryView.surgeryDateFrom = string.Empty;

        }
    }
}