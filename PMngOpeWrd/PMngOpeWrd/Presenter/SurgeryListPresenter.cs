using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMngOpeWrd.Model;
using PMngOpeWrd.View;
using System.Dynamic;

namespace PMngOpeWrd.Presenter
{
    public class SurgeryListPresenter
    {
        ISurgeryListView surgeryView;
        SurgeryListModel surgeryModel;

        /// <summary>
        /// constructor of the patient presenter
        /// </summary>
        /// <param name="view"></param>
        public SurgeryListPresenter(ISurgeryListView view)
        {
            surgeryView = view;
            surgeryModel = new SurgeryListModel();
        }

        public void FillPatientGrid()
        {
            dynamic filterData = new ExpandoObject();
            filterData.searchColumn = surgeryView.searchColumn;
            filterData.searchValue = surgeryView.searchValue;
            surgeryView.surgeryData = surgeryModel.GetAllSurgeryApprovalData(filterData);
        }

        internal void ClearFilter()
        {
            surgeryView.searchColumn = "searchColumn";
            surgeryView.searchValue = string.Empty;
            FillPatientGrid();
        }
    }
}