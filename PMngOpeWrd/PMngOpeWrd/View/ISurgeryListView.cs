using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMngOpeWrd.View
{
    public interface ISurgeryListView
    {
        DataTable surgeryData { set; }
        string searchColumn { get; set; }
        string searchValue { get; set; }
        DataTable wardDoctors { set; }
        string doctor { get; set; }
        string status { get; set; }
        string surgeryStartFrom { get; set; }
        string surgeryStartTo { get; set; }
        string admissionFrom { get; set; }
        string admissionTo { get; set; }
    }
}
