using PMngOpeWrd.Model;
using PMngOpeWrd.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace PMngOpeWrd.Presenter
{
    public class WardRegistrationPresenter
    {
        IWardRegistrationView wardView;
        WardModel wardModel;

        public WardRegistrationPresenter(IWardRegistrationView view)
        {
            wardView = view;
            wardModel = new WardModel();
        }

        internal void RegisterWard()
        {
            dynamic ward = new ExpandoObject();
            bool transactionStatus = false;

            ward.wardNo = wardView.wardNo;
            ward.owner = wardView.owner;
            ward.wardType = wardView.type;
            ward.noOfBeds = wardView.noOfBeds;
            ward.isNewWard = wardView.isNewWard;
            ward.isActive = wardView.isActive;

            transactionStatus = wardModel.RegisterWard(ward);

            if (transactionStatus)
            {
                if (wardView.isNewWard == "true")
                {
                    wardView.transactionStatusSuccess = "Theator has been Registered Successfully";
                }
                else
                {
                    wardView.transactionStatusSuccess = "Theator has been Updated Successfully";
                }

                ClearWardData();
            }
            else
            {
                if (wardView.isNewWard == "true")
                {
                    wardView.transactionStatusFail = "Theator Registration has been Failed";
                }
                else
                {
                    wardView.transactionStatusFail = "Theator Update has been Failed";
                }
            }
        }

        internal void LoadNextWardId()
        {
            wardView.wardNo = wardModel.GetNextWardId();
        }

        private void ClearWardData()
        {
            wardView.isNewWard = "true";
            wardView.owner = string.Empty;
            wardView.type = string.Empty;
            wardView.noOfBeds = 0;
            wardView.isActive = "true";
            wardView.isNewWard = "true";
            LoadNextWardId();
        }

        internal void ClearWardInfomation()
        {
            wardView.transactionStatusSuccess = string.Empty;
            wardView.transactionStatusFail = string.Empty;
            ClearWardData();
        }

        internal void LoadAllWardData()
        {
            FillWardGrid();
        }

        private void FillWardGrid()
        {
            wardView.wardData = wardModel.GetAllWardData();
        }

        internal void GetWardById()
        {
            string wartType = string.Empty;
            DataTable wardData = wardModel.GetWardById(wardView.wardNo);
            wardView.wardNo = wardData.Rows[0]["WardNo"].ToString();
            wardView.owner = wardData.Rows[0]["Owner"].ToString();
            wartType = wardData.Rows[0]["WardType"].ToString();
            wardView.type = wartType;
            wardView.noOfBeds = Convert.ToInt32(wardData.Rows[0]["NoOfBeds"].ToString());
            wardView.isActive = wardData.Rows[0]["IsActive"].ToString();
            wardView.isNewWard = "false";
        }

        internal void LoadWardOwners()
        {
            wardView.loadWardOwners = wardModel.LoadWardOwners();

        }
    }
}