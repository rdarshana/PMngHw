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
                ClearRegistrationInformation();
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
            surgeryView.patientId = string.Empty;
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
            surgeryView.surgeryDateFrom = string.Empty;
            surgeryView.surgeryDateTo = string.Empty;
            surgeryView.availableTheators = null;
            surgeryView.transactionStatusFail = string.Empty;   

        }

        internal void RegisterSurgery()
        {
            bool isValidTheaterSelection = surgeryModel.IsValidTheaterSelection(surgeryView.surgeryDateFrom, surgeryView.surgeryDateTo);
            if (isValidTheaterSelection)
            {
                dynamic surgery = new ExpandoObject();
                bool transactionStatus = false;
                surgery.SurgeryId = surgeryView.surgeryId;
                surgery.DoctorId = surgeryView.doctor;
                surgery.AdmissionDate = surgeryView.admissionDate;
                surgery.Description = surgeryView.surgeryDescription;
                surgery.SurgeryStart = surgeryView.surgeryDateFrom;
                surgery.SurgeryEnd = surgeryView.surgeryDateTo;
                surgery.TheatorId = surgeryView.theatorId;
                surgery.PatientId = surgeryView.patientId;
                surgery.IsNewSurgery = surgeryView.isNewSurgery;

                transactionStatus = surgeryModel.RegisterSurgery(surgery);
                surgeryView.transactionStatusFail = string.Empty;
                if (transactionStatus)
                {
                    if (surgeryView.isNewSurgery == "true")
                    {
                        surgeryView.transactionStatusSuccess = "Surgery has been Registered Successfully";
                    }
                    else
                    {
                        surgeryView.transactionStatusSuccess = "Surgery has been Updated Successfully";
                    }
                }
                else
                {
                    if (surgeryView.isNewSurgery == "true")
                    {
                        surgeryView.transactionStatusFail = "Surgery Registration has been Failed";
                    }
                    else
                    {
                        surgeryView.transactionStatusFail = "Surgery Update has been Failed";
                    }

                }
                ClearRegistrationInformation();
            }
            else
            {
                surgeryView.transactionStatusFail = "Registration Failed. Theater is not available in selected time range";
            }
        }

        internal void GetReservedTheators()
        {
            surgeryView.availableTheators = null;
            surgeryView.availableTheators = surgeryModel.GetReservedTheators(surgeryView.surgeryDateFrom, surgeryView.surgeryDateTo);
        }

    }
}