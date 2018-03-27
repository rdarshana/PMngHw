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
            dynamic logedinDetails = loginModel.AuthenticateUser(login);
        }
    }
}