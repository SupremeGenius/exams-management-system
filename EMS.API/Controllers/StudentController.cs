using System.Threading.Tasks;
using EMS.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using EMS.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace exams_management_system.Controllers
{
    [VersionedRoute("api/students", 1)]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentService StudentService;
        private readonly IGradeService gradeService;

        public StudentsController(IStudentService studentService, IGradeService gradeService)
        {
            this.StudentService = studentService;
            this.gradeService = gradeService;
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

        [HttpGet("{id:guid}/grades", Name = "GetGradeByStudentId")]
        public async Task<IActionResult> GetGradeByStudentId(Guid id)
        {
            var grade = await this.gradeService.FindByStudentId(id);

            if (grade == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return Ok(grade);
        }

        [HttpGet("{id:guid}", Name = "GetStudentById")]
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            var student = await this.gradeService.FindByStudentId(id);

            if (student.Count == 0)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPut("{id:guid}/exams/{examId:guid}", Name = "CheckExam")]
        public async Task<IActionResult> CheckExam(Guid id, Guid examId)
        {
            var student = await this.StudentService.CheckExam(id,examId);

            return Ok(student);
        }

        [HttpGet("{id:guid}/sendmail", Name = "SendMail")]
        public async Task<IActionResult> SendMail(Guid id)
        {
            var studentModelDetails = await this.StudentService.FindById(id);

            if (studentModelDetails == null)
            {
                return StatusCode(422);
            }

            SMTPClient.StudentSendMail(studentModelDetails);
            return Ok();
        }

        [HttpPut("{id:guid}", Name = "UpdateStudent")]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentModel createStudentModel, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentModel = Mapper.Map<UpdateStudentModel, Student>(createStudentModel);

            var response = await this.StudentService.UpdateAsync(id, studentModel);
            if (response)
            {
                return Ok("User updated");
            }
            return NoContent();
        }
    }
}