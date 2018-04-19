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
        SurgeryListModel surgeryListModel;
        SurgeryModel surgeryModel;

        /// <summary>
        /// constructor of the patient presenter
        /// </summary>
        /// <param name="view"></param>
        public SurgeryListPresenter(ISurgeryListView view)
        {
            surgeryView = view;
            surgeryListModel = new SurgeryListModel();
            surgeryModel = new SurgeryModel();
        }

        internal void LoadWardOwners()
        {
            surgeryView.wardDoctors = surgeryModel.LoadWardOwners();
        }

        public void FillPatientGrid()
        {
            dynamic filterData = new ExpandoObject();
            filterData.searchColumn = surgeryView.searchColumn;
            filterData.searchValue = surgeryView.searchValue;
            filterData.doctor = surgeryView.doctor;
            filterData.surgeryFrom = surgeryView.surgeryStartFrom;
            filterData.surgeryTo = surgeryView.surgeryStartTo;
            filterData.admissionFrom = surgeryView.admissionFrom;
            filterData.admissionTo = surgeryView.admissionTo;
            filterData.surgeryStatus = surgeryView.status;
            surgeryView.surgeryData = surgeryListModel.GetAllSurgeryApprovalData(filterData);
        }

        internal void ClearFilter()
        {
            surgeryView.searchColumn = "searchColumn";
            surgeryView.searchValue = string.Empty;
            surgeryView.doctor = "default";
            surgeryView.status = "default";
            surgeryView.surgeryStartFrom = string.Empty;
            surgeryView.surgeryStartTo = string.Empty;
            surgeryView.admissionFrom = string.Empty;
            surgeryView.admissionTo = string.Empty;

            FillPatientGrid();
        }
    }
}