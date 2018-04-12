using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMngOpeWrd.View
{
    public interface ISurgeryApprovalView
    {
        string employeeId { get; set; }
        DataTable surgeryData { set; }
        string searchColumn { get; }
        string searchValue { get; set; }
        string userType { get; }
    }
}
