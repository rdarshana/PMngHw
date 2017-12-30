using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMngOpeWrd.View
{
    public interface IPatientInquiryView
    {
        string patientId { get; set; }
        DataTable patientsData { set; }
        string searchColumn { get; }
        string searchValue { get; }
    }
}
