using System.Threading.Tasks;
using EMS.Business;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace exams_management_system.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;

        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public String Get ()
        {
            return "asdasdasda";
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreatingCourseModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courseId = await this.courseService.CreateNew(model);
            return Ok(courseId);

        }
    }
}