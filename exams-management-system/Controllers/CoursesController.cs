using System.Threading.Tasks;
using EMS.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using EMS.Domain;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

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
                return Ok(new List<CourseDetailsModel>());
            }

            return Ok(Courses);
        }

        [HttpGet("{id:guid}", Name = "GetCourseById")]
        public async Task<IActionResult> GetCourseById(Guid id)
        {
            var course = await this.courseService.FindById(id);

            if (course == null)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity);
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await this.courseService.FindById(id);
            if (course == null)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity);
            }

            var courseModel = Mapper.Map<UpdateCourseModel, Course>(updateCourseModel);
            var response = await this.courseService.Update(id, courseModel);
            if (response)
            {
                return Ok("Course updated");
            }
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete("{id:guid}", Name = "DeleteCourse")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {

            var response = await this.courseService.Delete(id);
            if (response)
            {
                return Ok("Course deleted");
            }
            return StatusCode(StatusCodes.Status409Conflict);
        }
    }
}