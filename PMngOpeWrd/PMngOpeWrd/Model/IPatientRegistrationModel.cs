using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using System.Data;

namespace PMngOpeWrd.Model
{
    public interface IPatientRegistrationModel
    {
        bool InsertPatientData(dynamic patient);
        DataTable GetAllPatientData();
        DataTable GetPatientById(string patientId);
        bool DeletePatientBySelectedId(string patientId);

        string GetNextPatientId();
    }
}
