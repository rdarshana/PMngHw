using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMngOpeWrd.Model
{
    public interface IEmployeeModel
    {
        string GetNextEmployeeId(string employeeType);
        bool RegisterEmployee(dynamic employee);
        DataTable GetEmployeeById(string employeeId);
        DataTable GetAllEmployeeData();
        DataTable GetEmployeeBySearchKey(string columnName, string searchValue);


    }
}
