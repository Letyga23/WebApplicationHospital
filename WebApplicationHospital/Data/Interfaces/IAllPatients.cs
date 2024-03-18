using WebApplicationHospital.Data.Models;

namespace WebApplicationHospital.Data.Interfaces
{
    public interface IAllPatients
    {
        IEnumerable<Patient> Patients { get; }
        Patient getObjectPatient(int idPatietn);
    }
}
