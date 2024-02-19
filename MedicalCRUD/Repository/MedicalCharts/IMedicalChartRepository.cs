using MedicalCRUD.Data.Models;

namespace MedicalCRUD.Repository.MedicalCharts
{
    public interface IMedicalChartRepository
    {
        public List<MedicalChart> GetAllChart();
        public MedicalChart GetChartById(int id);
        public void AddChart(MedicalChart medicalChart);
        public void SaveChart();
        public MedicalChart UpdateDeleteChart(int id);
        public void DeleteChart(MedicalChart medicalChart);
    }
}
