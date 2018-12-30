using System.Threading.Tasks;
using EMS.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using EMS.Domain;

namespace exams_management_system.Controllers
{
    [VersionedRoute("api/courses")]
    [ApiController]
    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;

        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var Courses = await this.courseService.GetAll();

            if (Courses.Count == 0)
            {
                return Ok("No exams have been found!");
            }

            return Ok(Courses);
        }

        [HttpGet("{id:guid}", Name = "GetCourseById")]
        public async Task<IActionResult> GetCourseById(Guid id)
        {
            var course = await this.courseService.FindById(id);

            if (course == null)
            {
                return StatusCode(422);
            }

            return Ok(course);
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

        [HttpPut("{id:guid}", Name = "UpdateCourse")]
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseModel updateCourseModel, Guid id)
        {
            var courseModel = Mapper.Map<UpdateCourseModel, Course>(updateCourseModel);
            var response = await this.courseService.Update(id, courseModel);
            if (response)
            {
                return Ok("Course updated");
            }
            return NoContent();
        }

        [HttpDelete("{id:guid}", Name = "DeleteCourse")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            var response = await this.courseService.Delete(id);
            if (response)
            {
                return Ok("Course deleted");
            }
            return StatusCode(409, "Course could not be deleted");
        }
    }
}