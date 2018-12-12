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
    public class LoginControllerTest
    {
   
        [Fact]
        public async Task Given_FindUser_When_ModelIsValid_Then_OkStatusCode()
        {
            // Arrange
            var newModel = new CreatingUserModel();
            var expectedModel = new UserDetailsModel();
            var mockRepo = new Mock<IUserService>();
            var Email = Task.FromResult(expectedModel);
            mockRepo.Setup(u => u.FindByEmail(newModel.Email)).Returns(Email);
            var controller = new LoginController(mockRepo.Object);

            // Act
            var result = await controller.FindUser(newModel);

            // Assert
            var badRequestResult = Assert.IsType<OkObjectResult>(result);
        }
    }
}