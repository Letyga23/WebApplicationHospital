using Microsoft.AspNetCore.Mvc;
using WebApplicationHospital.Data.Interfaces;

namespace WebApplicationHospital.Controllers
{
    public class PatientController : Controller
    {
        private readonly IAllPatients allPatients;

        public PatientController(IAllPatients iAllPatient)
        {
            allPatients = iAllPatient;
        }

        public ViewResult List()
        {
            var patients = allPatients.Patients;
            return View(patients);
        }
    }
}
