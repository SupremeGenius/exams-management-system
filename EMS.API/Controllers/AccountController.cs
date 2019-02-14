using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EMS.Business;
using exams_management_system;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EMS.API.Controllers
{
    [VersionedRoute("api/[controller]/[action]", 1)]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();

        [HttpGet]
        public async Task<ServiceContract> SendHttpRequest(string link, string json)
        {
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(link, httpContent);
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ServiceContract>(responseString);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            string json = JsonConvert.SerializeObject(model);

            var result = await SendHttpRequest("http://localhost:8000/api/account/register", json);

            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            string json = JsonConvert.SerializeObject(model);

            var result = await SendHttpRequest("http://localhost:8000/api/account/login", json);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            string json = JsonConvert.SerializeObject(model);

            var result = await SendHttpRequest("http://localhost:8000/api/account/resetpassword", json);

            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
        {
            string json = JsonConvert.SerializeObject(model);

            var result = await SendHttpRequest("http://localhost:8000/api/account/forgotpassword", json);

            return Ok(result);
        }

    }
}