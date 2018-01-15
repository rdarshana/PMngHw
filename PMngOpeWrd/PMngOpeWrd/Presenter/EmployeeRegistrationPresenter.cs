using System;
using PMngOpeWrd.View;
using PMngOpeWrd.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Dynamic;

namespace PMngOpeWrd.Presenter
{
    public class EmployeeRegistrationPresenter
    {
        IEmployeeRegistrationView employeeView;
        EmployeeModel employeeModel;

        public EmployeeRegistrationPresenter(IEmployeeRegistrationView view)
        {
            employeeView = view;
            employeeModel = new EmployeeModel();
        }
        internal void GetNextEmployeeId()
        {
            employeeView.employeeId = employeeModel.GetNextEmployeeId(employeeView.employeeType);
        }

        internal void RegisterEmployee()
        {
            dynamic patient = new ExpandoObject();
            bool transactionStatus = false;

            patient.patientId = employeeView.employeeId;
            patient.isNewPatient = employeeView.isNewEmployee;
            patient.firstName = employeeView.firstName;
            patient.lastName = employeeView.lastName;
            patient.NIC = employeeView.NIC;
            patient.address = employeeView.address;
            patient.mobilePhone = employeeView.mobilePhone;
            patient.landPhone = employeeView.landPhone;
            patient.email = employeeView.email;
        }
    }
}