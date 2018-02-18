using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMngOpeWrd.View;
using PMngOpeWrd.Model;

namespace PMngOpeWrd.Presenter
{
    public class EmployeeInquiryPresenter
    {
        IEmployeeInquiryView employeeView;
        EmployeeModel employeeModel;

        /// <summary>
        /// constructor of the patient presenter
        /// </summary>
        /// <param name="view"></param>
        public EmployeeInquiryPresenter(IEmployeeInquiryView view)
        {
            employeeView = view;
            employeeModel = new EmployeeModel();
        }

        //Get all ptient information
        public void FillPatientGrid()
        {
            employeeView.employeeData = employeeModel.GetAllEmployeeData();
        }

        public void GetEmployeeByKey()
        {
            employeeView.employeeData = employeeModel.GetEmployeeBySearchKey(employeeView.searchColumn, employeeView.searchValue);

        }

        public void ClearFilter()
        {
            employeeView.searchValue = string.Empty;
            FillPatientGrid();
        }
    }
}
