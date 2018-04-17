using PMngOpeWrd.Model;
using PMngOpeWrd.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMngOpeWrd.Presenter
{
    public class SurgeryApprovalPresenter
    {
        ISurgeryApprovalView surgeryView;
        SurgeryModel surgeruyModel;

        /// <summary>
        /// constructor of the patient presenter
        /// </summary>
        /// <param name="view"></param>
        public SurgeryApprovalPresenter(ISurgeryApprovalView view)
        {
            surgeryView = view;
            surgeruyModel = new SurgeryModel();
        }

        //Get all ptient information
        public void FillPatientGrid()
        {
            surgeryView.surgeryData = surgeruyModel.GetAllSurgeryApprovalData(surgeryView.userType, surgeryView.searchColumn, surgeryView.searchValue);
        }

        //public void GetEmployeeByKey()
        //{
        //    surgeryView.surgeryData = surgeruyModel.GetSurgeryBySearchKey(surgeryView.searchColumn, surgeryView.searchValue);

        //}

        public void ClearFilter()
        {
            surgeryView.searchValue = string.Empty;
            FillPatientGrid();
        }
    }
}