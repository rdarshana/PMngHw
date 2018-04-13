using PMngOpeWrd.Model;
using PMngOpeWrd.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PMngOpeWrd.Presenter
{
    public class AdmissionPresenter
    {
        IAdmissionView admissionView;
        AdmissionModel admissionModel;
        PatientRegistrationModel patientRegModel;

        public AdmissionPresenter(IAdmissionView view)
        {
            admissionView = view;
            admissionModel = new AdmissionModel();
            patientRegModel = new PatientRegistrationModel();
        }

        internal void GetPatientById()
        {
            ClearErrorMessages();

            if (admissionView.patientId.Trim() == null || admissionView.patientId.Trim() == "")
            {
                admissionView.noRecordFould = "Please Enter Patient ID";
                //ClearRegistrationInformation();
                //ClearHeaderInformation();
            }
            else
            {
                GetPatientBasicInformation();
            }
        }

        private void GetPatientBasicInformation()
        {
            DataTable patientData = patientRegModel.GetPatientById(admissionView.patientId);
            if (patientData.Rows.Count > 0)
            {
                admissionView.firstName = patientData.Rows[0]["FirstName"].ToString();
                admissionView.lastName = patientData.Rows[0]["LastName"].ToString();
                admissionView.NIC = patientData.Rows[0]["NIC"].ToString();
                admissionView.noRecordFould = null;
                //ClearRegistrationInformation();
            }
            else
            {
                admissionView.noRecordFould = "There is no mathing patient";
                admissionView.transactionStatusSuccess = string.Empty;
                admissionView.transactionStatusFail = string.Empty;
                admissionView.isNewAdmission = "true";

                //ClearHeaderInformation();
                //ClearRegistrationInformation();
            }
        }

        private void ClearErrorMessages()
        {
            admissionView.transactionStatusSuccess = string.Empty;
            admissionView.transactionStatusFail = string.Empty;
        }
    }
}