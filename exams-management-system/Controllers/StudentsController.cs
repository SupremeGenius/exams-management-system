using System.Threading.Tasks;
using EMS.Business;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace exams_management_system.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentService studentService;

        public StudentsController(IStudentService customerService) => this.studentService = customerService;

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var student = await this.studentService.GetAll();
            var json = JsonConvert.SerializeObject(student.ToArray());
            return Ok(json);
        }
    }
}