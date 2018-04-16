using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMngOpeWrd.View
{
    public interface IAdmissionInqueryView
    {
        string patientId { get; set; }
        DataTable admissionData { set; }
        string status { get; set; }
    }
}
