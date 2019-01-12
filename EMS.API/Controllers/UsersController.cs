﻿using System;
using System.Threading.Tasks;
using AutoMapper;
using EMS.Business;
using EMS.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace exams_management_system.Controllers
{
    [VersionedRoute("api/users", 1)]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPatch("{id:guid}", Name = "UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserModel updateUserModel, Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userModel = Mapper.Map<UpdateUserModel, User>(updateUserModel);

            var userId = await this.userService.FindById(id);
            if (userId == null)
            {
                return NotFound();
            }

            var response = await this.userService.UpdateAsync(id, userModel, updateUserModel.OldPassword);
            if (response)
            {
                return Ok("User updated");
            }
            return NoContent(); 
        }

        [HttpDelete("{id:guid}", Name = "DeleteUser")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await this.userService.FindById(id);
            if(user == null)
            {
                return NotFound();
            }

            var response = await this.userService.Delete(user.Id);
            if (response)
            {
                return Ok("User deleted");
            }
            return StatusCode(StatusCodes.Status409Conflict);
        }
    }
}