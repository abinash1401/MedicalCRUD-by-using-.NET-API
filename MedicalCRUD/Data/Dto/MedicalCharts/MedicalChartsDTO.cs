using Microsoft.AspNetCore.Mvc;

namespace MedicalCRUD.Data.Dto.MedicalCharts
{
    public class MedicalChartsDTO
    {
        public int Id { get; set; }
        public string Type { get; set; } // PDF or JPEG
        public string FilePath { get; set; }
        public int PatientId { get; set; }
    }


}
