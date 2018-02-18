using System;
using PMngOpeWrd.View;
using PMngOpeWrd.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Dynamic;
using System.Data;

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

            employee.EmployeeId = employeeView.employeeId;
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
                if (employeeView.isNewEmployee == "true")
                {
                    employeeView.transactionStatusSuccess = "Employee has been Registered Successfully";
                }
                else
                {
                    employeeView.transactionStatusSuccess = "Employee has been Updated Successfully";
                }
            }
            else
            {
                if (employeeView.isNewEmployee == "true")
                {
                    employeeView.transactionStatusFail = "Employee Registration has been Failed";
                }
                else
                {
                    employeeView.transactionStatusFail = "Employee Update has been Failed";
                }

            }


            ClearEmployeeData();
        }

        public void GetEmployeeById()
        {

            DataTable patientData = employeeModel.GetEmployeeById(employeeView.employeeId);
            employeeView.firstName = patientData.Rows[0]["FirstName"].ToString();
            employeeView.lastName = patientData.Rows[0]["LastName"].ToString();
            employeeView.employeeType = patientData.Rows[0]["EmployeeType"].ToString();
            employeeView.NIC = patientData.Rows[0]["NIC"].ToString();
            employeeView.address = patientData.Rows[0]["Address"].ToString();
            employeeView.mobilePhone = patientData.Rows[0]["MobilePhone"].ToString();
            employeeView.landPhone = patientData.Rows[0]["LandPhone"].ToString();
            employeeView.email = patientData.Rows[0]["Email"].ToString();
            employeeView.isActive = patientData.Rows[0]["IsActive"].ToString();
            employeeView.isNewEmployee = "false";
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