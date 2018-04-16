using PMngOpeWrd.Model;
using PMngOpeWrd.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace PMngOpeWrd.Presenter
{
    public class AdmissionPresenter
    {
        IAdmissionView admissionView;
        AdmissionModel admissionModel;
        PatientRegistrationModel patientRegModel;
        WardModel wardModel;

        public AdmissionPresenter(IAdmissionView view)
        {
            admissionView = view;
            admissionModel = new AdmissionModel();
            patientRegModel = new PatientRegistrationModel();
            wardModel = new WardModel();
        }

        internal void GetPatientById()
        {
            ClearErrorMessages();

            if (admissionView.patientId.Trim() == null || admissionView.patientId.Trim() == "")
            {
                admissionView.noRecordFould = "Please Enter Patient ID";
                ClearAdmissionInformation();
                ClearHeaderInformation();
            }
            else
            {
                GetPatientBasicInformation();
            }
        }

        internal void GetAdmissionDetailById()
        {
            DataTable patientData = admissionModel.GetAdmissionDetailById(Convert.ToInt32(admissionView.admissionId));
            
            admissionView.patientId = patientData.Rows[0]["PatientId"].ToString();
            admissionView.firstName = patientData.Rows[0]["FirstName"].ToString();
            admissionView.lastName = patientData.Rows[0]["LastName"].ToString();
            admissionView.NIC = patientData.Rows[0]["NIC"].ToString();
            admissionView.wardNo = patientData.Rows[0]["WardNo"].ToString();
            admissionView.admissionDescription = patientData.Rows[0]["AdmissionDescription"].ToString();
            admissionView.dischargeDescription = patientData.Rows[0]["DischargeDescription"].ToString();
            admissionView.isNewAdmission = "false";
        }

        internal void GetPatientAmissionStatusById()
        {
            dynamic surgery = new ExpandoObject();
            int admissionId = 0;
            if(admissionView.dataFrom == "query")
            {
                admissionId = Convert.ToInt32(admissionView.admissionId);
            }

            admissionView.admissionHistory = admissionModel.GetPatientAdmissionStatus(admissionView.patientId, admissionId);
        }

        internal void GetAvailableBeds()
        {
            admissionView.availableBeds = admissionModel.GetAvailableBeds(admissionView.wardNo);
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
                ClearAdmissionInformation();
            }
            else
            {
                admissionView.noRecordFould = "There is no mathing patient";
                admissionView.transactionStatusSuccess = string.Empty;
                admissionView.transactionStatusFail = string.Empty;
                admissionView.isNewAdmission = "true";

                ClearHeaderInformation();
                ClearAdmissionInformation();
            }
        }

        private void ClearErrorMessages()
        {
            admissionView.transactionStatusSuccess = string.Empty;
            admissionView.transactionStatusFail = string.Empty;
            admissionView.noRecordFould = string.Empty;
        }

        internal void LoadWardOwners()
        {
            admissionView.Wards = admissionModel.GetAllWardDataWithType();
        }

        internal void AdmitPatient()
        {
            ClearErrorMessages();

            dynamic surgery = new ExpandoObject();
            bool transactionStatus = false;
            surgery.AdmissionId = admissionView.admissionId;
            surgery.WardNo = admissionView.wardNo;
            surgery.PatientId = admissionView.patientId;
            surgery.AdmissionDescription = admissionView.admissionDescription;
            surgery.AdmittedBy = admissionView.employeeId;
            surgery.DischargeDescription = admissionView.dischargeDescription;
            surgery.IsNewAdmission = admissionView.isNewAdmission;
            surgery.AdmissionStatus = admissionView.admissionStatus;

            transactionStatus = admissionModel.AdmitPatient(surgery);
            admissionView.transactionStatusFail = string.Empty;
            if (transactionStatus)
            {
                if (admissionView.isNewAdmission == "true")
                {
                    admissionView.transactionStatusSuccess = "Patinet has been Admitted Successfully";
                }
                else
                {
                    admissionView.transactionStatusSuccess = "Patient Admission Updated Successfully";
                }
            }
            else
            {
                if (admissionView.isNewAdmission == "true")
                {
                    admissionView.transactionStatusFail = "Patient Admission has been Failed";
                }
                else
                {
                    admissionView.transactionStatusFail = "Patient Update has been Failed";
                }

            }
            ClearAdmissionInformation();
            ClearHeaderInformation();
        }

        internal void ClearAdmissionInformation()
        {
            admissionView.admissionDescription = string.Empty;
            admissionView.dischargeDescription = string.Empty;
            admissionView.wardNo = "1";
        }

        internal void ClearHeaderInformation()
        {
            admissionView.patientId = string.Empty;
            admissionView.NIC = string.Empty;
            admissionView.firstName = string.Empty;
            admissionView.lastName = string.Empty;
        }

        internal void ClearAdmissionData()
        {
            ClearAdmissionInformation();
            ClearHeaderInformation();
            ClearErrorMessages();
        }

        internal void GetIsPatientAdmitForSurgery()
        {
            string wardNo = admissionModel.GetIsPatientAdmitForSurgery(admissionView.patientId);
            if(wardNo != string.Empty)
            {
                admissionView.wardNo = wardNo;
                admissionView.wardNoEnable = false;
            }
        }
    }
}