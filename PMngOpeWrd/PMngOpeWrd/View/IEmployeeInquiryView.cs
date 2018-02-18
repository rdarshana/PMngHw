using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PMngOpeWrd.View
{
    public interface IEmployeeInquiryView
    {
        string employeeId { get; set; }
        DataTable employeeData { set; }
        string searchColumn { get; }
        string searchValue { get; set; }
    }
}