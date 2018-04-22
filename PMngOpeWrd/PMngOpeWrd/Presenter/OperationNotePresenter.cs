using PMngOpeWrd.Model;
using PMngOpeWrd.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PMngOpeWrd.Presenter
{
    public class OperationNotePresenter
    {
        IOperationNoteView operationView;
        SurgeryModel surgeryModel;

        public OperationNotePresenter(IOperationNoteView view)
        {
            operationView = view;
            surgeryModel = new SurgeryModel();
        }

        internal void GetSurgeryDetailsById()
        {
            DataTable surgeryData = surgeryModel.GetSurgeryDetailsBySurgeryId(operationView.surgeryId);
            operationView.surgeryId = Convert.ToInt32(surgeryData.Rows[0]["SurgeryId"].ToString());
            operationView.patientId = surgeryData.Rows[0]["PatientId"].ToString();
            operationView.NIC = surgeryData.Rows[0]["NIC"].ToString();
            operationView.doctor = surgeryData.Rows[0]["Surgeon"].ToString();
            operationView.description = surgeryData.Rows[0]["Description"].ToString();
            operationView.surgeryNote = surgeryData.Rows[0]["PostOperationMng"].ToString();
            operationView.surgeryStatus = surgeryData.Rows[0]["Status"].ToString();
        }

        internal void SubmitPostSurgery()
        {
            bool status = surgeryModel.UpdatePostSurgery(operationView.surgeryId, operationView.surgeryNote, operationView.surgeryStatus );
        }
    }    
}   