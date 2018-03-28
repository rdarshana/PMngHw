using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMngOpeWrd.View;
using PMngOpeWrd.Presenter;

namespace PMngOpeWrd
{
    public partial class UserLogin : System.Web.UI.Page, ILoginView
    {
        LoginPresenter presenter;
        public string errorMessage
        {
            set
            {
                lblErrorMessage.Text = value;
            }
        }

        public bool showErrorMessage
        {
            set
            {
                lblErrorMessage.Visible = value;
            }
        }

        public bool isValidLogin
        {
            set
            {
                if (value)
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }

        public string name
        {
            set
            {
                Session["name"] = value;
            }
        }

        public string password
        {
            get
            {
                return txtPassword.Text.Trim();
            }
        }

        public string userName
        {
            get
            {
                return txtUserName.Text.Trim();
            }
            set
            {
                Session["id"] = value;
            }
        }

        public string userRole
        {
            set
            {
                Session["role"] = value;
            }
        }

        public UserLogin()
        {
            presenter = new LoginPresenter(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void txtLogin_Click(object sender, EventArgs e)
        {
            presenter.AuthenticateUser();
        }
    }
}