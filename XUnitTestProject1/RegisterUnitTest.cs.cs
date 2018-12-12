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
            var Guid = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            var Mock = new Mock<IUserService>();
            var User = new CreatingUserModel();
            var Id = Task.FromResult(Guid);
            Mock.Setup(u => u.CreateNew(User)).Returns(Id);

            var Controller = new RegisterController(Mock.Object);

            // Act
            var Result =(OkObjectResult) await Controller.CreateUser(User);

            // Assert
            Assert.IsType<OkObjectResult>(Result);
            Assert.Equal(Id.Result, Result.Value);
        }
        [Fact]
        public async Task Given_CreateUser_When_ModelIsInvalid_Then_OkStatusCode()
        {

        }

    }
}