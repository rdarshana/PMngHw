using PMngOpeWrd.View;
using PMngOpeWrd.Model;
using PMngOpeWrd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Dynamic;

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
            PatientRegistrationModel patientRegistration = new PatientRegistrationModel();
            

            dynamic patient = new ExpandoObject();
            patient.firstName =  patientView.firstName;
            patient.lastName = patientView.lastName;
            patient.NIC= patientView.NIC;
            patient.address = patientView.address;
            patient.mobilePhone = patientView.mobilePhone;
            patient.landPhone = patientView.landPhone;
            patient.email = patientView.email;
            patient.gender = patientView.gender;
            patient.maritalStatus = patientView.maritalStatus;
            patient.emergencyContact = patientView.emergencyContact;
            patient.dateOfBirth = patientView.dateOfBirth;
            patientRegistration.InsertPatientData(patient);

            return true;

        }
    }
}