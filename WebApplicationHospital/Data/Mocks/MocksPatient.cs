using System.Net.Http.Headers;
using WebApplicationHospital.Data.Interfaces;
using WebApplicationHospital.Data.Models;

namespace WebApplicationHospital.Data.Mocks
{
    public class MocksPatient : IAllPatients
    {
        public IEnumerable<Patient> Patients 
        {
            get { return APIReader.getPatients().Result;}
        }

        public Patient getObjectPatient(int idPatietn)
        {
            throw new NotImplementedException();
        }
    }
}
