using MedicalCRUD.Data.Dto.MedicalCharts;

namespace MedicalCRUD.Data.Services.MedicalCharts
{
    public interface IChartSerices
    {
        public List<MedicalChartsDTO> Get();
        public MedicalChartsDTO GetById(int id);
        public MedicalChartsDTO Create(AddMedicalChartsDTO addMedicalChartsDTO);
        public MedicalChartsDTO UpdateCharts(MedicalChartsDTO medicalChartsDTO);
        public bool DeleteChart(int id);
    }
}
