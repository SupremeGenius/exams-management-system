using System.IO;
using System.Net;
using System.Threading.Tasks;
using EMS.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace exams_management_system.Controllers
{
    [VersionedRoute("api/register", 1)]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IProfessorService professorService;
        private readonly IStudentService studentService;

        public RegisterController(IUserService userService, IProfessorService professorService, IStudentService studentService)
        {
            this.userService = userService;
            this.professorService = professorService;
            this.studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreatingUserModel model)
        {
            var response = "";
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // add checking of the role (only stud or prof is allowed)
            var user = this.userService.FindByEmail(model.Email);
            WebRequest webRequest = WebRequest.Create("http://localhost:3000?email="+model.Email);
            WebResponse httpResponse = webRequest.GetResponse();
            using (var reader = new StreamReader(httpResponse.GetResponseStream()))
            {
                response = reader.ReadToEnd();
            }
            JObject jsonResponse = JObject.Parse(response);
            if (user.Result == null)
            {
                var userId = await this.userService.CreateNew(model);
                if (model.Role == "Professor")
                {
                    await this.professorService.CreateNew(userId);
                }
                else
                {
                    await this.studentService.CreateNew(userId, response);
                }

                return Ok(userId);
            }

            return StatusCode(StatusCodes.Status422UnprocessableEntity);
        }
    }
}
