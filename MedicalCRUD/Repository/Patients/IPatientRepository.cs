using MedicalCRUD.Data.Dto.Patients;
using MedicalCRUD.Data.Models;

namespace MedicalCRUD.Repository.Patients
{
    public interface IPatientRepository
    {
        public List<Patient> GetPatient();
        public Patient FindPatient(int id);
        public IEnumerable<Patient> FindPatientByName(string name);
        public void AddPatient(Patient patientModel);
        public void Changes();
        public Patient UpdateDeletePatient(int id);
        public void Deletepatient(Patient patient);
    }
}
