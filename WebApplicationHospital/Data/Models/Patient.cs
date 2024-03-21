using System.Text.Json.Serialization;

namespace WebApplicationHospital.Data.Models
{
    public class Patient
    {
        public int Id_Patient { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string PassportData { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PatientPhoto { get; set; }

        public Patient() { }

        public Patient(object[] patientData)
        {
            Id_Patient = Convert.ToInt32(patientData[0]);
            LastName = Convert.ToString(patientData[1]);
            FirstName = Convert.ToString(patientData[2]);
            Patronymic = Convert.ToString(patientData[3]);
            PassportData = Convert.ToString(patientData[4]);
            DateOfBirth = Convert.ToString(patientData[5]);
            Gender = Convert.ToString(patientData[6]);
            Address = Convert.ToString(patientData[7]);
            PhoneNumber = Convert.ToString(patientData[8]);
            Email = Convert.ToString(patientData[9]);

            if (patientData[10] != DBNull.Value)
            {
                byte[] varbinaryData = (byte[])patientData[10];
                PatientPhoto = Convert.ToBase64String(varbinaryData);
            }
        }
    }
}
