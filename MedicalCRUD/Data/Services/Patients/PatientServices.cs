using MedicalCRUD.Data.Contexts;
using MedicalCRUD.Data.Dto;
using MedicalCRUD.Data.Dto.MedicalCharts;
using MedicalCRUD.Data.Dto.Patients;
using MedicalCRUD.Data.Models;
using MedicalCRUD.Repository.Patients;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalCRUD.Data.Services.Patients
{
    public class PatientServices : IPatientServices
    {
        private readonly IPatientRepository pRepo;
        public PatientServices(IPatientRepository pRepo)
        {
            this.pRepo = pRepo;
        }

        public List<PatientDTO> GetP()
        {
            var patientModel = pRepo.GetPatient();

            var patientDto = new List<PatientDTO>();
            foreach (var p in patientModel)
            {
                patientDto.Add(new PatientDTO()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Gender = p.Gender,
                    DOB = p.DOB,
                    email = p.email,
                    MRN = p.MRN,
                    Phone = p.Phone,
                    MedicalCharts = p.MedicalCharts.Select(mc => new MedicalChartsDTO
                    {
                        Id = mc.Id,
                        Type = mc.Type,
                        FilePath = mc.FilePath,
                        PatientId = mc.PatientId,

                    }).ToList()

                });
            }
            return patientDto;
        }

        public PatientDTO GetById(int id)
        {
            var patientModel = pRepo.FindPatient(id);
            if (patientModel == null)
            {
                return null;
            }

            var patientDto = new PatientDTO
            {
                Id = patientModel.Id,
                Name = patientModel.Name,
                Gender = patientModel.Gender,
                DOB = patientModel.DOB,
                email = patientModel.email,
                MRN = patientModel.MRN,
                Phone = patientModel.Phone,
                MedicalCharts = patientModel.MedicalCharts.Select(mc => new MedicalChartsDTO
                {
                    Id = mc.Id,
                    Type = mc.Type,
                    FilePath = mc.FilePath,
                    PatientId = mc.PatientId,
                }).ToList()

            };
            return patientDto;
        }
        public PatientDTO GetByName(string name)
        {
            var patientModels = pRepo.FindPatientByName(name);

            var patientModel = patientModels.FirstOrDefault();

            if (patientModel == null)
            {
                return null; 
            }
            var patientDto = new PatientDTO
            {
                Id = patientModel.Id,
                Name = patientModel.Name,
                Gender = patientModel.Gender,
                DOB = patientModel.DOB,
                email = patientModel.email,
                MRN = patientModel.MRN,
                Phone = patientModel.Phone,
                MedicalCharts = patientModel.MedicalCharts.Select(mc => new MedicalChartsDTO
                {
                    Id = mc.Id,
                    Type = mc.Type,
                    FilePath = mc.FilePath,
                    PatientId = mc.PatientId,
                }).ToList()

            };
            return patientDto;
        }

        public PatientDTO Create(AddPatientDTO addPatientDTO)
        {
            var patientModel = new Patient
            {
                Name = addPatientDTO.Name,
                Gender = addPatientDTO.Gender,
                DOB = addPatientDTO.DOB,
                email = addPatientDTO.email,
                MRN = addPatientDTO.MRN,
                Phone = addPatientDTO.Phone,
                MedicalCharts = new List<MedicalChart>()
            };
            if (addPatientDTO.MedicalCharts != null && addPatientDTO.MedicalCharts.Any())
            {
                foreach (var medicalChartDto in addPatientDTO.MedicalCharts)
                {
                    var medicalChartModel = new MedicalChart
                    {
                        FilePath = medicalChartDto.FilePath,
                        Type = medicalChartDto.Type,
                    };
                    patientModel.MedicalCharts.Add(medicalChartModel);
                }
            }
            pRepo.AddPatient(patientModel);
            pRepo.Changes();

            var patientDto = new PatientDTO
            {
                Id = patientModel.Id,
                Name = patientModel.Name,
                Gender = patientModel.Gender,
                DOB = patientModel.DOB,
                email = patientModel.email,
                MRN = patientModel.MRN,
                Phone = patientModel.Phone,
                MedicalCharts = patientModel.MedicalCharts.Select(mc => new MedicalChartsDTO
                {
                    Id = mc.Id,
                    Type = mc.Type,
                    FilePath = mc.FilePath,
                    PatientId = mc.PatientId
                }).ToList()
            };

            return patientDto;
        }

        public UpdatePatientDTO UpdatePatient(UpdatePatientDTO updatePatientDTO)
        {
            var patient = pRepo.UpdateDeletePatient(updatePatientDTO.Id);
            if (patient == null) return null;

            patient.Id = updatePatientDTO.Id;
            patient.Name = updatePatientDTO.Name;
            patient.email = updatePatientDTO.email;
            patient.Gender = updatePatientDTO.Gender;
            patient.MRN = updatePatientDTO.MRN;
            patient.DOB = updatePatientDTO.DOB;
            patient.Phone = updatePatientDTO.Phone;

            var p = new UpdatePatientDTO

            {
                Id = patient.Id,
                Name = patient.Name,
                email = patient.email,
                Gender = patient.Gender,
                MRN = patient.MRN,
                Phone = patient.Phone,
                DOB = patient.DOB
            };

            pRepo.Changes();
            return p;
        }

        public bool DeletePatient(int id)
        {
            var patient = pRepo.UpdateDeletePatient(id);
            if (patient == null) return false;
            pRepo.Deletepatient(patient);
            pRepo.Changes();
            return true;
        }
    }
}
