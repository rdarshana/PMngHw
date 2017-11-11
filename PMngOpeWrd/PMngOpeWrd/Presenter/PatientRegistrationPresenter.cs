using PMngOpeWrd.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMngOpeWrd.Presenter
{
    public class PatientRegistrationPresenter
    {
        IPatientRegistrationView patientView;

        public PatientRegistrationPresenter (IPatientRegistrationView view)
        {
            patientView = view;
        }


        public bool RegisterPatient()
        {
            return true;

        }
    }
}