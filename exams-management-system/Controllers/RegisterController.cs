using System.Threading.Tasks;
using EMS.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exams_management_system.Controllers
{
    [VersionedRoute("api/[controller]", 1)]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService userService;

        public RegisterController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreatingUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = this.userService.FindByEmail(model.Email);
            if (user.Result == null)
            {
                var userId = await this.userService.CreateNew(model);
                return Ok(userId);
            }

            return StatusCode(StatusCodes.Status422UnprocessableEntity);
        }
    }
}