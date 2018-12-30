using System.Threading.Tasks;
using EMS.Business;
using Microsoft.AspNetCore.Mvc;

namespace exams_management_system.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly IUserService userService;

        public LoginController(IUserService userService) => this.userService = userService;

        [HttpPost]
        public async Task<IActionResult> FindUser([FromBody] CreatingUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await this.userService.FindByEmail(model.Email);
            if (user == null)
            {
                return StatusCode(404);
            }
            if (user.Password == model.Password)
            {
                return Ok("User valid");
            }
            return StatusCode(422);
        }
    }
}