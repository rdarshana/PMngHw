using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMngOpeWrd
{
    public partial class PMng : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["name"] as string))
            {
                lblUserName.Text = Session["name"].ToString();
            }
            else
            {
                Session.Clear();
                Response.Redirect("UserLogin.aspx");
            }
         
        }

        protected void txtLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("UserLogin.aspx");
        }
    }
}