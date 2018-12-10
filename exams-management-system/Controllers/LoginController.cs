using System.Threading.Tasks;
using EMS.Business;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace exams_management_system.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUserService userService;

        public LoginController(IUserService userService) => this.userService = userService;

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var user = await this.userService.GetAll();
            var json = JsonConvert.SerializeObject(user.ToArray());
            return Ok(json);
        }
    }
}