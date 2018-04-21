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
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Session["name"] as string))
                {
                    lblUserName.Text = Session["name"].ToString();
                    var menu = Page.Master.FindControl("MainMenu") as Menu;
                    if (menu != null)
                    {
                        MenuItem parentPatientItem = menu.FindItem("patient");
                        MenuItem patientRegistration = menu.FindItem("patient/registration");
                        MenuItem patientInquiry = menu.FindItem("patient/inquiry");
                        MenuItem patientAdmission = menu.FindItem("patient/admission");
                        MenuItem patientExamination = menu.FindItem("patient/examination");
                        MenuItem patientAdmissionInquery = menu.FindItem("patient/admissionInquery");

                        MenuItem parentEmployeeItem = menu.FindItem("employee");
                        MenuItem employeeRegistration = menu.FindItem("employee/employeeRegistration");
                        MenuItem employeeInquiry = menu.FindItem("employee/employeeInquiry");

                        MenuItem parentSurgeryItem = menu.FindItem("surgery");
                        MenuItem surgeryRegistration = menu.FindItem("surgery/surgeryRegistration");
                        MenuItem surgeryList = menu.FindItem("surgery/surgeryList");

                        MenuItem parentRegistrationItem = menu.FindItem("registration");
                        MenuItem registrationTheators = menu.FindItem("surgery/theators");
                        MenuItem registrationWard = menu.FindItem("surgery/ward");

                        MenuItem parentApprovalItem = menu.FindItem("approval");

                        if (Session["role"] as string == "doctor")
                        {
                            parentEmployeeItem.ChildItems.Remove(employeeRegistration);
                            menu.Items.Remove(parentRegistrationItem);
                        }
                        else if (Session["role"] as string == "administrator")
                        {
                            menu.Items.Remove(parentPatientItem);
                            menu.Items.Remove(parentSurgeryItem);
                            menu.Items.Remove(parentApprovalItem);
                        }
                        else if (Session["role"] as string == "anesthetist" || Session["role"] as string == "director")
                        {
                            parentPatientItem.ChildItems.Remove(patientRegistration);
                            parentPatientItem.ChildItems.Remove(patientAdmission);
                            parentEmployeeItem.ChildItems.Remove(employeeRegistration);
                            parentSurgeryItem.ChildItems.Remove(surgeryRegistration);
                            menu.Items.Remove(parentRegistrationItem);
                        }
                        else
                        {
                            menu.Items.Remove(parentPatientItem);
                            menu.Items.Remove(parentSurgeryItem);
                            menu.Items.Remove(parentApprovalItem);
                            menu.Items.Remove(parentEmployeeItem);
                            menu.Items.Remove(parentRegistrationItem);
                        }
                    }
                }
                else
                {
                    Session.Clear();
                    Response.Redirect("UserLogin.aspx");
                }
            }
        }

        protected void txtLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("UserLogin.aspx");
        }
    }
}