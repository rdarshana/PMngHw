using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMngOpeWrd.View
{
    public interface IOperationNoteView
    {
        int surgeryId { get; set; }
        string patientId { set; }
        string NIC { set; }
        string doctor { set; }
        string description { set; }
        string surgeryNote { get; set; }
        string surgeryStatus { get; set; }
    }
}
