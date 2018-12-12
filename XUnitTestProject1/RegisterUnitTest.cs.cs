using EMS.Business;
using Xunit;
using Moq;
using exams_management_system.Controllers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;

namespace XUnitTestProject1
{
    public class RegisterControllerTest
    {
        [Fact]
        public async Task Given_CreateUser_When_ModelIsValid_Then_OkStatusCode()
        {
            // Arrange
            var Mock = new Mock<IUserService>();
            var User = new CreatingUserModel();
            var Id = Task.FromResult(Guid.NewGuid());
            Mock.Setup(u => u.CreateNew(User)).Returns(Id);

            var Controller = new RegisterController(Mock.Object);

            // Act
            var Result = await Controller.CreateUser(User);

            // Assert
            Assert.IsType<OkObjectResult>(Result);
        }

    }
}