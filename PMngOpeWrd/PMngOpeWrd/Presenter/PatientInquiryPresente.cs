using PMngOpeWrd.View;
using PMngOpeWrd.Model;
using PMngOpeWrd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Dynamic;
using System.Data;

namespace PMngOpeWrd.Presenter
{
    public class PatientInquiryPresenter
    {
        IPatientInquiryView patientView;
        PatientRegistrationModel patientRegistration;

        /// <summary>
        /// constructor of the patient presenter
        /// </summary>
        /// <param name="view"></param>
        public PatientInquiryPresenter(IPatientInquiryView view)
        {
            patientView = view;
            patientRegistration = new PatientRegistrationModel();
        }


        //Get all ptient information
        public void FillPatientGrid()
        {
            patientView.patientsData = patientRegistration.GetAllPatientData();
        }

        public void GetPatientByKey()
        {
            patientView.patientsData = patientRegistration.GetPatientBySearchKey(patientView.searchColumn, patientView.searchValue);

        }

        public void ClearFilter()
        {
            patientView.searchValue = string.Empty;
            FillPatientGrid();
        }
    }
}