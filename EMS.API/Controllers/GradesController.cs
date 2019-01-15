using System;
using System.Threading.Tasks;
using AutoMapper;
using EMS.Business;
using EMS.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exams_management_system.Controllers
{
    [VersionedRoute("api/grades", 1)]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IGradeService gradeService;

        public GradesController(IGradeService gradeService) => this.gradeService = gradeService;

        [HttpGet]
        public async Task<IActionResult> GetGrades()
        {
            var exams = await this.gradeService.GetAll();

            return Ok(exams);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGrade([FromBody] CreatingGradeModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gradeId = await this.gradeService.CreateNew(model);
            return Ok(gradeId);

        }

        [HttpGet("{id:guid}", Name = "GetGradeById")]
        public async Task<IActionResult> GetGradeById(Guid id)
        {
            var grade = await this.gradeService.FindById(id);

            if (grade == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return Ok(grade);
        }

        [HttpPut("{id:guid}", Name = "UpdateGrade")]
        public async Task<IActionResult> UpdateGrade([FromBody] UpdateGradeModel updateGradeModel, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var grade = await this.gradeService.FindById(id);
            if (grade == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            var gradeModel = Mapper.Map<UpdateGradeModel, Grade>(updateGradeModel);
            var response = await this.gradeService.Update(id, gradeModel);
            if (response)
            {
                return Ok("Grade updated");
            }

            return NoContent();
        }

        [HttpDelete("{id:guid}", Name = "DeleteGrade")]
        public async Task<IActionResult> DeleteGrade(Guid id)
        {
            var grade = await this.gradeService.FindById(id);
            if (grade == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            if (await this.gradeService.Delete(id))
            {
                return Ok("Grade deleted");
            }

            return StatusCode(StatusCodes.Status409Conflict, "Grade could not be deleted");
        }
    }
}