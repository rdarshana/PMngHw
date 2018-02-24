using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMngOpeWrd.View
{
    public interface ITheatorRegistrationView
    {
        string theatorId { get; set; }
        string description { get; set; }
        string isNewTheator { get; set; }
        DataTable theatorData { get; set; }
        string isActive { get; set; }
        string transactionStatusSuccess { set; }
        string  transactionStatusFail { set;}
    }
}
