using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exams_management_system.Controllers
{
    [Route("api/exams")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamService examService;

        public ExamsController(IExamService examService) => this.examService = examService;

        [HttpGet]
        public async Task<IActionResult> GetExams()
        {
            var exams = await this.examService.GetAll();

            if (exams.Count == 0)
            {
                return Ok("No exams have been found!");
            }

            return Ok(exams);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExam([FromBody] CreatingExamModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exam = this.examService.FindByTime(model.Date);
            if (exam.Result == null)
            {
                var examId = await this.examService.CreateNew(model);
                return Ok(examId);
            }

            return StatusCode(422);
        }
    }
}