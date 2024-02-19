using System.Text.Json.Serialization;

namespace MedicalCRUD.Data.Models
{
    public class MedicalChart
    {
        public int Id { get; set; }
        public string Type { get; set; } // PDF or JPEG
        public string FilePath { get; set; }
        public int PatientId { get; set; }

        [JsonIgnore]
        public Patient Patient { get; set; }
    }
}
