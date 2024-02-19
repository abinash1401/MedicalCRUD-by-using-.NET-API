using MedicalCRUD.Data.Contexts;
using MedicalCRUD.Data.Dto.Patients;
using MedicalCRUD.Data.Models;
using MedicalCRUD.Data.Services.Patients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace MedicalCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientServices pServices;
        public PatientController(IPatientServices pServices)
        {
            this.pServices = pServices;
        }


        [HttpGet]
        public IActionResult GetPatient()
        {
            List<PatientDTO> p = pServices.GetP();
            return Ok(p);
        }

        [HttpGet("id/{{id}}")]
        public IActionResult GetPatientById(int id)
        {
            PatientDTO p = pServices.GetById(id);
            return Ok(p);
        }
        [HttpGet("name/{{name}}")]
        public IActionResult GetPatientName(string name)
        {
            PatientDTO p = pServices.GetByName(name);
            return Ok(p);
        }

        [HttpPost]
        public IActionResult CreatePatient(AddPatientDTO addPatientDTO)
        {
            PatientDTO p = pServices.Create(addPatientDTO);
            return Ok(p);
        }

        [HttpPut]
        public IActionResult Update(UpdatePatientDTO updatePatientDTO)
        {
            if (updatePatientDTO.Id == 0 || updatePatientDTO == null) return BadRequest();
            var u = pServices.UpdatePatient(updatePatientDTO);
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
            if (pServices.DeletePatient(id) == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
