using MedicalCRUD.Data.Dto.MedicalCharts;
using MedicalCRUD.Data.Models;
using MedicalCRUD.Repository.MedicalCharts;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCRUD.Data.Services.MedicalCharts
{
    public class ChartServices : IChartSerices
    {
        private readonly IMedicalChartRepository mRepo;
        public ChartServices(IMedicalChartRepository mRepo)
        {
            this.mRepo = mRepo;
        }

        public List<MedicalChartsDTO> Get()
        {
            var chartModel = mRepo.GetAllChart();

            var chartsDto = new List<MedicalChartsDTO>();
            foreach (var c in chartModel)
            {
                chartsDto.Add(new MedicalChartsDTO()
                {
                    Id = c.Id,
                    Type = c.Type,
                    FilePath = c.FilePath,
                    PatientId = c.PatientId,
                });
            }

            return chartsDto;
        }

        public MedicalChartsDTO GetById(int id)
        {
            var chartModel = mRepo.GetChartById(id);
            if (chartModel == null)
            {
                return null;
            }

            var chartDto = new MedicalChartsDTO
            {
                Id = chartModel.Id,
                Type = chartModel.Type,
                FilePath = chartModel.FilePath,
                PatientId = chartModel.PatientId
            };
            return chartDto;
        }

        public MedicalChartsDTO Create(AddMedicalChartsDTO addMedicalChartsDTO)
        {
            var medicalCharts = new MedicalChart
            {
                Type = addMedicalChartsDTO.Type,
                FilePath = addMedicalChartsDTO.FilePath,
                PatientId = addMedicalChartsDTO.PatientId
            };

            mRepo.AddChart(medicalCharts);
            mRepo.SaveChart();


            var medicalChartsDto = new MedicalChartsDTO
            {
                Id = medicalCharts.Id,
                Type = medicalCharts.Type,
                FilePath = medicalCharts.FilePath,
                PatientId = medicalCharts.PatientId
            };

            return medicalChartsDto;
        }

        public MedicalChartsDTO UpdateCharts(MedicalChartsDTO medicalChartsDTO)
        {
            var charts = mRepo.UpdateDeleteChart(medicalChartsDTO.Id);
            if (charts == null) return null;

            charts.Type = medicalChartsDTO.Type;
            charts.FilePath = medicalChartsDTO.FilePath;
            charts.Id = medicalChartsDTO.Id;
            charts.PatientId = medicalChartsDTO.PatientId;

            var c = new MedicalChartsDTO

            {
                Id = charts.Id,
                Type = charts.Type,
                FilePath = charts.FilePath,
                PatientId = charts.PatientId
            };

            mRepo.SaveChart();
            return c;
        }

        public bool DeleteChart(int id)
        {
            var chart = mRepo.UpdateDeleteChart(id);
            if (chart == null) return false;
            mRepo.DeleteChart(chart);
            mRepo.SaveChart();
            return true;
        }
    }
}
