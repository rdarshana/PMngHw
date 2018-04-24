using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMngOpeWrd.View
{
    public interface IAdmissionView
    {
        string admissionId { get; set; }
        string wardNo { get; set; }
        DataTable Wards { set; }
        string transactionStatusSuccess { set; }
        string transactionStatusFail { set; }
        string patientId { get; set; }
        string isNewAdmission { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        string NIC { get; set; }
        string employeeId { get; }
        int availableBeds { set; }
        string admissionDescription { get; set; }
        string dischargeDescription { get; set; }
        string noRecordFould { set; }
        string admissionStatus { get; set; }
        string dataFrom { get; set; }
        dynamic admissionHistory { set; }
        bool wardNoEnable { set; }
        int surgeryId { get; set; }
        string surgeryNotification { get; set; }
    }
}
