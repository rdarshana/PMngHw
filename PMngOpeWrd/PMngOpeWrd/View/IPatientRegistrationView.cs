using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMngOpeWrd.View
{
    public interface IPatientRegistrationView
    {
        string firstName { get; set; }
        string lastName { get; set; }
        string  NIC { get; set; }
        string address { get; set; }
        string mobilePhone { get; set; }
        string landPhone { get; set; }
        string email { get; set; }
        string gender { get; set; }
        string maritalStatus { get; set; }
        string emergencyContact { get; set; }
        string dateOfBirth { get; set; }

    }
}
