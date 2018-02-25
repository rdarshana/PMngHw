using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMngOpeWrd.View;
using PMngOpeWrd.Model;
using System.Dynamic;
using System.Data;

namespace PMngOpeWrd.Presenter
{
    public class TheatorRegistrationPresenter
    {
        ITheatorRegistrationView theatorView;
        TheatorModel theatorModel;

        public TheatorRegistrationPresenter(ITheatorRegistrationView view)
        {
            theatorView = view;
            theatorModel = new TheatorModel();
        }

        internal void RegisterTheator()
        {
            dynamic theator = new ExpandoObject();
            bool transactionStatus = false;

            theator.theatorId = theatorView.theatorId;
            theator.description = theatorView.description;
            theator.isActive = theatorView.isActive;
            theator.isNewTheator = theatorView.isNewTheator;

            transactionStatus = theatorModel.RegisterTheator(theator);


            if (transactionStatus)
            {
                if (theatorView.isNewTheator == "true")
                {
                    theatorView.transactionStatusSuccess = "Theator has been Registered Successfully";
                }
                else
                {
                    theatorView.transactionStatusSuccess = "Theator has been Updated Successfully";
                }

                ClearTheaterData();
            }
            else
            {
                if (theatorView.isNewTheator == "true")
                {
                    theatorView.transactionStatusFail = "Theator Registration has been Failed";
                }
                else
                {
                    theatorView.transactionStatusFail = "Theator Update has been Failed";
                }

            }
        }

        internal void LoadNextTheatorId()
        {
            theatorView.theatorId = theatorModel.GetNextTheatorId();
        }
        
        private void ClearTheaterData()
        {
            theatorView.isActive = "true";
            theatorView.description = string.Empty;
            LoadNextTheatorId();
        }

        internal void ClearTheaterInfomation()
        {
            ClearTheaterData();
        }

        internal void LoadAllTheaterData()
        {
            FillTheaterGrid();
        }

        private void FillTheaterGrid()
        {
            theatorView.theatorData = theatorModel.GetAllTheatorData();
        }

        internal void GetTheaterById()
        {
            DataTable theaterData = theatorModel.GetTheatorById(theatorView.theatorId);
            theatorView.theatorId = theaterData.Rows[0]["TheatorId"].ToString();
            theatorView.description = theaterData.Rows[0]["Description"].ToString();
            theatorView.isActive = theaterData.Rows[0]["IsActive"].ToString();
            theatorView.isNewTheator = "false";
        }
    }
}