using System.ComponentModel.DataAnnotations;

namespace MedicalCRUD.Data.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public int Phone { get; set; }
        public string email { get; set; }
        public string MRN { get; set; }
        public ICollection<MedicalChart> MedicalCharts { get; set; } 
    }
}
