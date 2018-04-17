using PMngOpeWrd.Model;
using PMngOpeWrd.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMngOpeWrd.Presenter
{
    public class AdmissionInqueryPresenter
    {
        IAdmissionInqueryView inquiryView;
        AdmissionModel inquiryModel;

        public AdmissionInqueryPresenter(IAdmissionInqueryView view)
        {
            inquiryView = view;
            inquiryModel = new AdmissionModel();
        }

        internal void FillPatientAdmissionGrid()
        {
            inquiryView.admissionData = inquiryModel.GetPatientAdmissionDetails("", "admitted");
        }

        internal void FillPatientAdmissionGridBySearchValues()
        {
            inquiryView.admissionData = inquiryModel.GetPatientAdmissionDetails(inquiryView.patientId, inquiryView.status);
        }
    }
}