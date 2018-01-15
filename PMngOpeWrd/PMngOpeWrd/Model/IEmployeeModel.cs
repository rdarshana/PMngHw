using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMngOpeWrd.Model
{
    public interface IEmployeeModel
    {
        string GetNextEmployeeId(string employeeType);
    }
}
