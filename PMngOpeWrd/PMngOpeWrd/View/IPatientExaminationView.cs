using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMngOpeWrd.View
{
    public interface IPatientExaminationView
    {
        string patientId { get; set; }
        DataTable patientData { set; }
        string firstName { get; set; }
        string lastName { get; set; }
        string NIC { get; set; }
        string complain { get; set; }
        string examination { get; set; }
        string diagnosis { get; set; }
        string drugs { get; set; }
        string isNewExamine { get; set; }
        string transactionStatusSuccess { set; }
        string transactionStatusFail { set; }
    }
}