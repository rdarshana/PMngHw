using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMngOpeWrd.Model
{
    public interface IWardModel
    {
        string GetNextWardId();
        bool RegisterWard(dynamic ward);
        DataTable GetWardById(string wardNo);
        DataTable GetAllWardData();
        DataTable LoadWardOwners();
    }
}
