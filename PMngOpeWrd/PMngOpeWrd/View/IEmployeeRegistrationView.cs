using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMngOpeWrd.View
{
    public interface IEmployeeRegistrationView
    {
        string employeeType { get; set; }
        string employeeId { get; set; }
        string firstName { get; set; }
        string password { get; set; }
        string lastName { get; set; }
        string NIC { get; set; }
        string address { get; set; }
        string mobilePhone { get; set; }
        string landPhone { get; set; }
        string email { get; set; }
        string isActive { get; set; }
        string isNewEmployee { get; set; }
        string transactionStatusSuccess { set; }
        string transactionStatusFail { set; }
        bool employeeRegistration { set; }
        bool employeeUpdate { set;  }
        string removeQueryString { set; }
        bool employeeTypeEnable { set; }
    }
}
