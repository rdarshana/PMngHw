using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMngOpeWrd.View
{
    public interface IWardRegistrationView
    {
        string wardNo { get; set; }
        string owner { get; set; }
        string isNewWard { get; set; }
        string type { get; set; }
        int noOfBeds { get; set; }
        string isActive { get; set; }
        DataTable wardData { set; }
        string transactionStatusSuccess { set; }
        string transactionStatusFail { set; }
    }
}
