using System.Threading.Tasks;
using EMS.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using EMS.Domain;

namespace exams_management_system.Controllers
{
    [VersionedRoute("api/students", 1)]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentService StudentService;

        public StudentsController(IStudentService studentService)
        {
            this.StudentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await this.StudentService.GetAll();

            if (students.Count == 0)
            {
                return Ok("No students have been found!");
            }

            return Ok(students);
        }

        [HttpGet("{id:guid}", Name = "GetStudentById")]
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            var student = await this.StudentService.FindById(id);

            if (student == null)
            {
                return StatusCode(422);
            }

            return Ok(student);
        }
    }
}