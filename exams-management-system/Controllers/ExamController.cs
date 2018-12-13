using System;
using System.Threading.Tasks;
using EMS.Business;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace exams_management_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : Controller
    {
        private readonly IExamService examService;

        public ExamController(IExamService examService) => this.examService = examService;
   
        [HttpGet]
        public async Task<IActionResult> FindExam(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var exam = await this.examService.FindById(id);
            if (exam == null)
            {
                return StatusCode(404);
            }

            return Ok("Curs valid");

            //return StatusCode(422);
        }
    }
}