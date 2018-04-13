using PMngOpeWrd.Model;
using PMngOpeWrd.View;
using System;
using System.Collections.Generic;
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

    }
}