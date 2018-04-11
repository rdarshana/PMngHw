using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMngOpeWrd.View
{
    public interface ISurgeryView
    {
        string patientId { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        string NIC { get; set; }
        string isNewSurgery { get; set; }
        string transactionStatusSuccess { set; }
        string transactionStatusFail { set; }
        int surgeryId { get; set; }
        //string noRecordFound { set; }
        string doctor { get; set; }
        string wardNo { get; set; }
        string admissionDate { get; set; }
        string surgeryDescription { get; set; }
        string surgeryDateFrom { get; set; }
        string surgeryDateTo { get; set; }
        string theatorId { get; set; }
        DataTable theators { set; }
        string noRecordFould { set; }
        string surgeonApproval { get; set; }
        string surgeonDescription { get; set; }
        string anesthetistApproval { get; set; }
        string anesthetistProblem { get; set; }
        string modeOfAnesthesia { get; set; }
        string directorApproval { get; set; }
        string directorDescription { get; set; }
        DataTable wardDoctors { set; }
        DataTable Wards { set; }
        DataTable availableTheators { set; }
    }
}