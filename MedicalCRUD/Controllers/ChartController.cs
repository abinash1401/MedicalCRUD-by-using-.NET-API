using MedicalCRUD.Data.Contexts;
using MedicalCRUD.Data.Dto.MedicalCharts;
using MedicalCRUD.Data.Models;
using MedicalCRUD.Data.Services.MedicalCharts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly IChartSerices cServices;
        public ChartController(IChartSerices cServices)
        {
            this.cServices = cServices;
        }

        [HttpGet]
        public IActionResult GetCharts()
        {
            List<MedicalChartsDTO> c = cServices.Get();
            return Ok(c);
        }

        [HttpGet("{id}")]
        public IActionResult GetChartsById(int id)
        {
            MedicalChartsDTO c = cServices.GetById(id);
            return Ok(c);
        }

        [HttpPost]
        public IActionResult CreateChart(AddMedicalChartsDTO addMedicalChartsDTO)
        {
            MedicalChartsDTO c = cServices.Create(addMedicalChartsDTO);
            return Ok(c);
        }

        [HttpPut]
        public IActionResult Update(MedicalChartsDTO medicalChartsDTO)
        {
            if (medicalChartsDTO.Id == 0 || medicalChartsDTO == null) return BadRequest();
            var u = cServices.UpdateCharts(medicalChartsDTO);
            if (u == null)
            {
                return NotFound();
            }
            return Ok(u);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();
            if (cServices.DeleteChart(id) == false) return NotFound();
            return NoContent();
        }
    }
}
