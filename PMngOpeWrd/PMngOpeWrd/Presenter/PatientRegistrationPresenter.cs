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
        public void RegisterPatient()
        {
            dynamic patient = new ExpandoObject();
            bool transactionStatus = false;

            patient.patientId = patientView.patientId;
            patient.firstName = patientView.firstName;
            patient.lastName = patientView.lastName;
            patient.NIC = patientView.NIC;
            patient.address = patientView.address;
            patient.mobilePhone = patientView.mobilePhone;
            patient.landPhone = patientView.landPhone;
            patient.email = patientView.email;
            patient.gender = patientView.gender;
            patient.bloodGroup = patientView.bloodGroup;
            patient.maritalStatus = patientView.maritalStatus;
            patient.emergencyContact = patientView.emergencyContact;
            patient.dateOfBirth = patientView.dateOfBirth;
            patient.gardianName = patientView.gardianName;
            patient.gardianAddress = patientView.gardianAddress;
            transactionStatus = patientRegistration.InsertPatientData(patient);

            if (transactionStatus)
            {
                if (patientView.patientId == string.Empty)
                {
                    patientView.transactionStatusSuccess = "Patient has been Registered Successfully";
                }
                else
                {
                    patientView.transactionStatusSuccess = "Patient has been Updated Successfully";
                }
            }
            else
            {
                if (patientView.patientId == string.Empty)
                {
                    patientView.transactionStatusFail = "Patient Registration has been Failed";
                }
                else
                {
                    patientView.transactionStatusFail = "Patient Update has been Failed";
                }

            }

            //FillPatientGrid();
            ClearPatientData();

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
            patientView.bloodGroup = patientData.Rows[0]["BloodGroup"].ToString();
            patientView.gender = patientData.Rows[0]["Gender"].ToString();
            patientView.maritalStatus = patientData.Rows[0]["MaritalStatus"].ToString();
            patientView.emergencyContact = patientData.Rows[0]["EmergencyContact"].ToString();
            patientView.dateOfBirth = patientData.Rows[0]["DateOfBirth"].ToString();
            patientView.gardianName = patientData.Rows[0]["GardianName"].ToString();
            patientView.gardianAddress = patientData.Rows[0]["GardianAddress"].ToString();
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
            patientView.gender = "male";
            patientView.maritalStatus = "Single";
            patientView.emergencyContact = string.Empty;
            patientView.dateOfBirth = string.Empty;
            patientView.bloodGroup = "default";
            patientView.gardianName = string.Empty;
            patientView.gardianAddress = string.Empty;
            //patientView.transactionStatusSuccess = string.Empty;
            //patientView.transactionStatusFail = string.Empty;
        }

        /// <summary>
        /// Delete patient by Id
        /// </summary>
        public void DeletePatientById()
        {
            bool status = patientRegistration.DeletePatientBySelectedId(patientView.patientId);
            if (status)
            {
                patientView.transactionStatusSuccess = "Patient has been Deleted Successfully";
            }
            else
            {
                patientView.transactionStatusFail = "Patient Delete has been Failed";
            }

            ClearPatientData();
            //FillPatientGrid();
        }
    }
}