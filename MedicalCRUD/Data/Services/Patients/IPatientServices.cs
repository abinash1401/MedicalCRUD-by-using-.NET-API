using MedicalCRUD.Data.Dto.Patients;
using MedicalCRUD.Data.Models;

namespace MedicalCRUD.Data.Services.Patients
{
    public interface IPatientServices
    {
        public List<PatientDTO> GetP();
        public PatientDTO GetById(int id);
        public PatientDTO GetByName(string name);
        public PatientDTO Create(AddPatientDTO addPatientDTO);
        public UpdatePatientDTO UpdatePatient(UpdatePatientDTO updatePatientDTO);
        public bool DeletePatient(int id);
    }
}
