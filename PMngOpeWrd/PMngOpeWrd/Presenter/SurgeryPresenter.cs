using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMngOpeWrd.View;
using PMngOpeWrd.Model;
using System.Dynamic;

namespace PMngOpeWrd.Presenter
{
    public class SurgeryPresenter
    {
        ISurgeryView surgeryView;
        SurgeryModel surgeryModel;
        WardModel wardModel;

        public SurgeryPresenter(ISurgeryView view)
        {
            surgeryView = view;
            surgeryModel = new SurgeryModel();
            wardModel = new WardModel();
        }

        internal void LoadWardOwners()
        {
            surgeryView.wardDoctors = surgeryModel.LoadWardOwners();

        }

        internal void LoadWardsByDoctor()
        {
            surgeryView.Wards = surgeryModel.LoadWardsByDoctor(surgeryView.doctor);
        }
    }
}