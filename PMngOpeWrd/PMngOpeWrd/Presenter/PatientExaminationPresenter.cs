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
            patientView.patientData = patientExaminModel.GetPatientHistoryById(patientView.patientId);
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
            //ClearEmployeeData();
        }
    }
}