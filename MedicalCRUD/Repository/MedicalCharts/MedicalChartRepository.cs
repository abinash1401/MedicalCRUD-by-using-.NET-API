using MedicalCRUD.Data.Contexts;
using MedicalCRUD.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalCRUD.Repository.MedicalCharts
{
    public class MedicalChartRepository : IMedicalChartRepository
    {
        private readonly MedicalDbContext dbContext;
        public MedicalChartRepository(MedicalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<MedicalChart> GetAllChart()
        {
           return dbContext.MedicalCharts.ToList();
        }

        public MedicalChart GetChartById(int id)
        {
            return dbContext.MedicalCharts.FirstOrDefault(mc => mc.Id == id);
        }
        public void AddChart(MedicalChart medicalChart)
        {
            dbContext.MedicalCharts.Add(medicalChart);
        }
        public MedicalChart UpdateDeleteChart(int id)
        {
            return dbContext.MedicalCharts.FirstOrDefault(p => p.Id == id);
        }
        public void DeleteChart(MedicalChart medicalChart)
        {
            dbContext.MedicalCharts.Remove(medicalChart);
        }
        public void SaveChart()
        {
            dbContext.SaveChanges();
        }
    }
}
