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
    public class LoginPresenter
    {
        ILoginView loginView;
        LoginModel loginModel;

        public LoginPresenter(ILoginView view)
        {
            loginView = view;
            loginModel = new LoginModel();
        }

        internal void AuthenticateUser()
        {
            dynamic login = new ExpandoObject();
            login.userName = loginView.userName;
            login.password = loginView.password;
            dynamic logedInDetails = loginModel.AuthenticateUser(login);
            if (logedInDetails.valid) {
                loginView.name = logedInDetails.name;
                loginView.userName = loginView.userName;
                loginView.userRole = logedInDetails.userType;
                loginView.errorMessage = string.Empty;
                loginView.showErrorMessage = false;
                loginView.isValidLogin = true;
            }
            else
            {
                loginView.errorMessage = "Invalid login, please try again";
                loginView.showErrorMessage = true;
            }
        }
    }
}