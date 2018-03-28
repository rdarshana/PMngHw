using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMngOpeWrd.View
{
    public interface ILoginView
    {
        string userName { get; set; }
        string password { get; }
        bool showErrorMessage { set; }
        string userRole { set; }
        string name { set; }
        string errorMessage { set; }
        bool isValidLogin { set; }
    }
}
