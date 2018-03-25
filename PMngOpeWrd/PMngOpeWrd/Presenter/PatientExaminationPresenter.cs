using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMngOpeWrd.View;
using PMngOpeWrd.Model;
using System.Data;

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
    }
}