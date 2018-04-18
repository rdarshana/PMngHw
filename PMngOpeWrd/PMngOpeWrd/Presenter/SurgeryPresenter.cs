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
            ClearErrorMessages();

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
            ClearErrorMessages();

            bool isValidTheaterSelection = surgeryModel.IsValidTheaterSelection(surgeryView.surgeryDateFrom, surgeryView.surgeryDateTo, surgeryView.theatorId, surgeryView.surgeryId, surgeryView.isNewSurgery);
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
                surgery.WardNo = surgeryView.wardNo;

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
                ClearHeaderInformation();
            }
            else
            {
                surgeryView.transactionStatusFail = "Registration Failed. Theater is not available in selected time range";
            }
        }

        internal void GetReservedTheators()
        {
            surgeryView.availableTheators = null;
            surgeryView.availableTheators = surgeryModel.GetReservedTheators(surgeryView.surgeryDateFrom, surgeryView.surgeryDateTo, surgeryView.theatorId);
        }

        private void ClearErrorMessages()
        {
            surgeryView.transactionStatusSuccess = string.Empty;
            surgeryView.transactionStatusFail = string.Empty;
        }

        internal void GetSurgeryDetailsBySurgeryId()
        {
            DataTable surgeryData = surgeryModel.GetSurgeryDetailsBySurgeryId(surgeryView.surgeryId);
            surgeryView.patientId = surgeryData.Rows[0]["PatientId"].ToString();
            surgeryView.NIC = surgeryData.Rows[0]["NIC"].ToString();
            surgeryView.firstName = surgeryData.Rows[0]["FirstName"].ToString();
            surgeryView.lastName = surgeryData.Rows[0]["LastName"].ToString();
            surgeryView.doctor = surgeryData.Rows[0]["DoctorId"].ToString();
            surgeryView.wardNo = surgeryData.Rows[0]["WardNo"].ToString();

            string patientSurgeryDate = surgeryData.Rows[0]["AdmissionDate"].ToString();
            DateTime valueAdmission = DateTime.Parse(patientSurgeryDate);
            surgeryView.admissionDate = string.Format("{0:yyyy/MM/dd}", valueAdmission);

            surgeryView.surgeryDescription = surgeryData.Rows[0]["Description"].ToString();

            DateTime valueAdmissionTo = DateTime.Parse(surgeryData.Rows[0]["SurgeryEnd"].ToString());
            string formattedTo = string.Format("{0:g}", valueAdmissionTo);
            string[] toArray = formattedTo.Split(' ');
            string toDateFormat = string.Format("{0:yyyy/MM/dd}", DateTime.Parse(toArray[0]));
            surgeryView.surgeryDateTo = toDateFormat + ' ' + toArray[1] + ' ' + toArray[2];

            DateTime valueAdmissionFrom = DateTime.Parse(surgeryData.Rows[0]["SurgeryStart"].ToString());
            string formattedFrom = string.Format("{0:g}", valueAdmissionFrom);
            string[] fromArray = formattedFrom.Split(' ');
            string fromDateFormat = string.Format("{0:yyyy/MM/dd}", DateTime.Parse(fromArray[0]));
            surgeryView.surgeryDateFrom = fromDateFormat + ' ' + fromArray[1] + ' ' + fromArray[2];


            surgeryView.theatorId = surgeryData.Rows[0]["TheatorId"].ToString();
            surgeryView.surgeonApproval = surgeryData.Rows[0]["SurgeonApproval"].ToString();
            surgeryView.surgeonDescription = surgeryData.Rows[0]["SurgeonDescription"].ToString();
            surgeryView.anesthetistApproval = surgeryData.Rows[0]["AnesthetistApproval"].ToString();
            surgeryView.anesthetistProblem = surgeryData.Rows[0]["AnesthetistProlems"].ToString();
            surgeryView.modeOfAnesthesia = surgeryData.Rows[0]["ModeOfAnesthesia"].ToString();
            surgeryView.directorApproval = surgeryData.Rows[0]["DirectorApproval"].ToString();
            surgeryView.directorDescription = surgeryData.Rows[0]["DirectorDescription"].ToString();

            string editableCount = surgeryData.Rows[0]["IsEditableCount"].ToString();
            if (editableCount == "0")
            {
                surgeryView.surggeryDetailIsEditable = "false";
            }
            else
            {
                surgeryView.surggeryDetailIsEditable = "true";
            }
        }

        internal void GetSurgeryApprovalStatusById()
        {
            surgeryView.surgeryStatus = surgeryModel.GetSurgeryApprovalStatusById(surgeryView.surgeryId);
        }
    }
}