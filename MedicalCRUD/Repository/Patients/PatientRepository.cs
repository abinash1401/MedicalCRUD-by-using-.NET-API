using MedicalCRUD.Data.Contexts;
using MedicalCRUD.Data.Dto.Patients;
using MedicalCRUD.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalCRUD.Repository.Patients
{
    public class PatientRepository : IPatientRepository
    {
        private readonly MedicalDbContext dbContext;

        public PatientRepository(MedicalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public List<Patient> GetPatient()
        {
           return dbContext.Patients.Include(p => p.MedicalCharts).ToList();
        }

        public Patient FindPatient(int id)
        {
            return dbContext.Patients.Include(p => p.MedicalCharts).FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<Patient> FindPatientByName(string name)
        {
            return dbContext.Patients.Include(p => p.MedicalCharts).Where(p => p.Name.Contains(name));
        }

        public void AddPatient(Patient patientModel)
        {
             dbContext.Patients.Add(patientModel);
        }
        public void Changes()
        {
            dbContext.SaveChanges();
        }
        public Patient UpdateDeletePatient(int id)
        {
            return dbContext.Patients.FirstOrDefault(p => p.Id == id);
        }
        public void Deletepatient(Patient patient)
        {
            dbContext.Patients.Remove(patient);
        }
    }
}
