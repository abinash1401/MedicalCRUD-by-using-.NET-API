using MedicalCRUD.Data.Dto.MedicalCharts;

namespace MedicalCRUD.Data.Dto.Patients
{
    public class AddPatientDTO
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public int Phone { get; set; }
        public string email { get; set; }
        public string MRN { get; set; }
        public List<MedicalChartsDTO> MedicalCharts { get; set; }
    }
}
