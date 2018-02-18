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
            dynamic employee = new ExpandoObject();
            bool transactionStatus = false;

            employee.patientId = employeeView.employeeId;
            employee.isNewEmployee = employeeView.isNewEmployee;
            employee.employeeType = employeeView.employeeType;
            employee.password = employeeView.password;
            employee.firstName = employeeView.firstName;
            employee.lastName = employeeView.lastName;
            employee.NIC = employeeView.NIC;
            employee.address = employeeView.address;
            employee.mobilePhone = employeeView.mobilePhone;
            employee.landPhone = employeeView.landPhone;
            employee.email = employeeView.email;
            employee.isActive = employeeView.isActive;

            transactionStatus = employeeModel.RegisterEmployee(employee);

            if (transactionStatus)
            {
                if (employeeView.employeeId == string.Empty)
                {
                    employeeView.transactionStatusSuccess = "Patient has been Registered Successfully";
                }
                else
                {
                    employeeView.transactionStatusSuccess = "Patient has been Updated Successfully";
                }
            }
            else
            {
                if (employeeView.employeeId == string.Empty)
                {
                    employeeView.transactionStatusFail = "Patient Registration has been Failed";
                }
                else
                {
                    employeeView.transactionStatusFail = "Patient Update has been Failed";
                }

            }


            ClearEmployeeData();
        }

        /// <summary>
        ///Clear form data
        /// </summary>
        internal void ClearEmployeeData()
        {
            employeeView.employeeId = string.Empty;
            employeeView.employeeType = "anesthetist";
            employeeView.firstName = string.Empty;
            employeeView.lastName = string.Empty;
            employeeView.NIC = string.Empty;
            employeeView.address = string.Empty;
            employeeView.mobilePhone = string.Empty;
            employeeView.landPhone = string.Empty;
            employeeView.email = string.Empty;
            employeeView.isActive = "true";
            employeeView.employeeRegistration = true;
            employeeView.employeeUpdate = false;
            employeeView.removeQueryString = "eid";
            employeeView.employeeTypeEnable = true;
            employeeView.isNewEmployee = "true";
            GetNextEmployeeId();
        }
    }
}