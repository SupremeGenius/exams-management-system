using System.Threading.Tasks;
using EMS.Business;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace exams_management_system.Controllers
{
    [Route("api/professors")]
    [ApiController]
    public class ProfessorController : Controller
    {
        private readonly IProfessorService professorService;

        public ProfessorController(IProfessorService professorService)
        {
            this.professorService = professorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfessors()
        {
            var Professors = await this.professorService.GetAll();

            if (Professors.Count == 0)
            {
                return Ok("No professors have been found!");
            }

            return Ok(Professors);
        }

        [HttpGet("{id:guid}", Name = "GetProfessorById")]
        public async Task<IActionResult> GetProfessorById(Guid id)
        {
            var professor = await this.professorService.FindById(id);

            if (professor == null)
            {
                return StatusCode(422);
            }

            return Ok(professor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfessor([FromBody] ProfessorDetailsModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var professorId = await this.professorService.CreateNew(model);
            return Ok(professorId);

        }

        [HttpPut("{id:guid}", Name = "UpdateProfessor")]
        public async Task<IActionResult> UpdateProfessor(Guid id)
        {

            this.professorService.Update(id);
            return Ok();
        }

        [HttpDelete("{id:guid}", Name = "DeleteProfessor")]
        public async Task<IActionResult> DeleteProfessor(Guid id)
        {

            this.professorService.Delete(id);
            return Ok();
        }
    }
}