using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMngOpeWrd.Model
{
    public interface ITheatorModel
    {
        string GetNextTheatorId();
        bool RegisterTheator(dynamic theator);
        DataTable GetTheatorById(string theatorId);
        DataTable GetAllTheatorData();
    }
}
