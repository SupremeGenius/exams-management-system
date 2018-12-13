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

            return Ok(exams);
        }

        [HttpPost]
        public async Task<IActionResult> CerateExam([FromBody] CreatingExamModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var examId = await this.examService.CreateNew(model);

            return Ok(examId);
        }
    }
}