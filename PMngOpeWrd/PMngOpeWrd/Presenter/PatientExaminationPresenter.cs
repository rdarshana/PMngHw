using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMngOpeWrd.View;
using PMngOpeWrd.Model;
using System.Data;
using System.Dynamic;

namespace PMngOpeWrd.Presenter
{
    public class PatientExaminationPresenter
    {
        IPatientExaminationView patientView;
        PatientExaminationModel patientExaminModel;
        PatientRegistrationModel patientRegModel;
        public PatientExaminationPresenter(IPatientExaminationView view)
        {
            patientView = view;
            patientExaminModel = new PatientExaminationModel();
            patientRegModel = new PatientRegistrationModel();
        }

        public void GetPatientById()
        {
            GetPatientHistoryInformation();
            GetPatientBasicInformation();
        }

        public void GetPatientHistoryInformation()
        {
             patientView.patientData = patientExaminModel.GetPatientHistoryById(patientView.patientId);
        }

        private void GetPatientBasicInformation()
        {
            DataTable patientData = patientRegModel.GetPatientById(patientView.patientId);
            patientView.firstName = patientData.Rows[0]["FirstName"].ToString();
            patientView.lastName = patientData.Rows[0]["LastName"].ToString();
            patientView.NIC = patientData.Rows[0]["NIC"].ToString();
        }

        internal void AddPatientexamination()
        {
            dynamic patientExamine = new ExpandoObject();
            bool transactionStatus = false;
            patientExamine.PatientId = patientView.patientId;
            patientExamine.EmployeeId = patientView.employeeId;
            patientExamine.Complain = patientView.complain;
            patientExamine.Examination = patientView.examination;
            patientExamine.Diagnosis = patientView.diagnosis;
            patientExamine.Drugs = patientView.drugs;
            patientExamine.IsNewExamine = patientView.isNewExamine;

            transactionStatus = patientExaminModel.AddPatientExamination(patientExamine);

            if (transactionStatus)
            {
                if (patientView.isNewExamine == "true")
                {
                    patientView.transactionStatusSuccess = "Record Inserted Successfully";
                }
                else
                {
                    patientView.transactionStatusSuccess = "Record Updated Successfully";
                }
            }
            else
            {
                if (patientView.isNewExamine == "true")
                {
                    patientView.transactionStatusFail = "Record Inserted Failed";
                }
                else
                {
                    patientView.transactionStatusFail = "Record Updated Failed";
                }

            }
            patientView.isNewExamine = "true";
            ClearHistoryInformation();
        }

        internal void ClearPatientData()
        {
            patientView.isNewExamine = "true";
            ClearHeaderInformation();
            ClearHistoryInformation();
        }

        internal void ClearHeaderInformation()
        {
            patientView.patientId = string.Empty;
            patientView.NIC = string.Empty;
            patientView.firstName = string.Empty;
            patientView.lastName = string.Empty;
        }

        internal void ClearHistoryInformation()
        {
            patientView.complain = string.Empty;
            patientView.examination = string.Empty;
            patientView.diagnosis = string.Empty;
            patientView.drugs = string.Empty;
        }

        internal void GetDataSelectedById()
        {
            DataTable selectedRow = patientView.patientData.AsEnumerable().Where
                        (row => row.Field<Int32>("ID") == patientView.examineId).CopyToDataTable();

            patientView.complain = selectedRow.Rows[0]["Complain"].ToString();
            patientView.examination = selectedRow.Rows[0]["Examination"].ToString();
            patientView.diagnosis = selectedRow.Rows[0]["Diagnosis"].ToString();
            patientView.drugs = selectedRow.Rows[0]["Drugs"].ToString();
            patientView.complain = selectedRow.Rows[0]["Complain"].ToString();
        }
    }
}