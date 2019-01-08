using System.Threading.Tasks;
using EMS.Business;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using AutoMapper;
using EMS.Domain.Entities;

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

        [HttpPut("{id:guid}", Name = "UpdateProfessor")]
        public async Task<IActionResult> UpdateProfessor([FromBody] CreatingProfessorModel createProfessorModel, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var professorModel = Mapper.Map<CreatingProfessorModel, Professor>(createProfessorModel);

            var response = await this.professorService.UpdateAsync(id, professorModel);
            if (response)
            {
                return Ok("User updated");
            }
            return NoContent();
        }
        
        [HttpDelete("{id:guid}", Name = "DeleteProfessor")]
        public async Task<IActionResult> DeleteProfessor(Guid id)
        {

            var response = await this.professorService.Delete(id);
            if (response)
            {
                return Ok("Professor deleted");
            }
            return StatusCode(409, "Professor could not be deleted");
        }
    }
}