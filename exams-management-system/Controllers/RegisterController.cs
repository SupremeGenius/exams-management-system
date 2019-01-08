﻿using System.Threading.Tasks;
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
        private readonly IProfessorService professorService;

        public RegisterController(IUserService userService, IProfessorService professorService)
        {
            this.userService = userService;
            this.professorService = professorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreatingUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // add checking of the role (only stud or prof is allowed)
            var user = this.userService.FindByEmail(model.Email);
            if (user.Result == null)
            {
                var userId = await this.userService.CreateNew(model);
                if (model.Role == "Professor")
                {
                    await this.professorService.CreateNew(userId);
                }
                return Ok(userId);
            }

            return StatusCode(StatusCodes.Status422UnprocessableEntity);
        }
    }
}
