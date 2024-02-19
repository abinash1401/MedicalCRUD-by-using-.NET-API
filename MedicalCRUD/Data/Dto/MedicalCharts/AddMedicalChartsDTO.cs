namespace MedicalCRUD.Data.Dto.MedicalCharts
{
    public class AddMedicalChartsDTO
    {
        public string Type { get; set; } // PDF or JPEG
        public string FilePath { get; set; }
        public int PatientId { get; set; }
    }
}
