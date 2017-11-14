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
    public class PatientRegistrationPresenter
    {
        IPatientRegistrationView patientView;
        PatientRegistrationModel patientRegistration;

        /// <summary>
        /// constructor of the patient presenter
        /// </summary>
        /// <param name="view"></param>
        public PatientRegistrationPresenter(IPatientRegistrationView view)
        {
            patientView = view;
            patientRegistration = new PatientRegistrationModel();
        }

        /// <summary>
        /// Register Patient
        /// </summary>
        /// <returns></returns>
        public bool RegisterPatient()
        {
            dynamic patient = new ExpandoObject();
            patient.patientId = patientView.patientId;
            patient.firstName = patientView.firstName;
            patient.lastName = patientView.lastName;
            patient.NIC = patientView.NIC;
            patient.address = patientView.address;
            patient.mobilePhone = patientView.mobilePhone;
            patient.landPhone = patientView.landPhone;
            patient.email = patientView.email;
            patient.gender = patientView.gender;
            patient.maritalStatus = patientView.maritalStatus;
            patient.emergencyContact = patientView.emergencyContact;
            patient.dateOfBirth = patientView.dateOfBirth;
            patientRegistration.InsertPatientData(patient);

            FillPatientGrid();
            ClearPatientData();


            return true;

        }

        //Get all ptient information
        public void FillPatientGrid()
        {
            patientView.patientsData = patientRegistration.GetAllPatientData();
        }

        /// <summary>
        /// get patient information by given id
        /// </summary>
        public void GetPatientById()
        {
            
            DataTable patientData = patientRegistration.GetPatientById(patientView.patientId);
            patientView.firstName = patientData.Rows[0]["FirstName"].ToString();
            patientView.lastName = patientData.Rows[0]["LastName"].ToString();
            patientView.NIC = patientData.Rows[0]["NIC"].ToString();
            patientView.address = patientData.Rows[0]["Address"].ToString();
            patientView.mobilePhone = patientData.Rows[0]["MobilePhone"].ToString();
            patientView.landPhone = patientData.Rows[0]["LandPhone"].ToString();
            patientView.email = patientData.Rows[0]["Email"].ToString();
            patientView.gender = patientData.Rows[0]["Gender"].ToString();
            patientView.maritalStatus = patientData.Rows[0]["MaritalStatus"].ToString();
            patientView.emergencyContact = patientData.Rows[0]["EmergencyContact"].ToString();
            patientView.dateOfBirth = patientData.Rows[0]["DateOfBirth"].ToString();
        }

        /// <summary>
        ///Clear form data
        /// </summary>
        public void ClearPatientData()
        {
            patientView.patientId = string.Empty;
            patientView.firstName = string.Empty;
            patientView.lastName = string.Empty;
            patientView.NIC = string.Empty;
            patientView.address = string.Empty;
            patientView.mobilePhone = string.Empty;
            patientView.landPhone = string.Empty;
            patientView.email = string.Empty;
            patientView.gender = string.Empty;
            patientView.maritalStatus = string.Empty;
            patientView.emergencyContact = string.Empty;
            patientView.dateOfBirth = string.Empty;
        }

        /// <summary>
        /// Delete patient by Id
        /// </summary>
        public void DeletePatientById()
        {
            patientRegistration.DeletePatientBySelectedId(patientView.patientId);
            ClearPatientData();
            FillPatientGrid();
        }
    }
}