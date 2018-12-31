using EMS.Business;
using Xunit;
using Moq;
using exams_management_system.Controllers;
using System.Threading.Tasks;
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
            var guid = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            var mockRepo = new Mock<IUserService>();
            var user = new CreatingUserModel();
            var id = Task.FromResult(guid);
            mockRepo.Setup(u => u.CreateNew(user)).Returns(id);

            var controller = new RegisterController(mockRepo.Object);

            // Act
            var result =(OkObjectResult) await controller.CreateUser(user);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(id.Result, result.Value);
        }
        [Fact]
        public async Task Given_CreateUser_When_ModelIsInvalid_Then_BadStatusCode()
        {
            // Arrange
            var guid = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            var mockRepo = new Mock<IUserService>();
            var user = new CreatingUserModel();
            var id = Task.FromResult(guid);
            mockRepo.Setup(u => u.CreateNew(user)).Returns(id);
            
            var controller = new RegisterController(mockRepo.Object);
            controller.ModelState.AddModelError("email", "Required");

            // Act
            var result = await controller.CreateUser(user);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public async Task Given_CreateUser_When_ModelIsValid_Then_Status422UnprocessableEntity()
        {
            var mockRepo = new Mock<IUserService>();
            var user = new CreatingUserModel();
            var userDetails= Task.FromResult(new UserDetailsModel());
            mockRepo.Setup(u => u.FindByEmail(user.Email)).Returns(userDetails);

            var controller = new RegisterController(mockRepo.Object);

            // Act
            var result = (StatusCodeResult) await controller.CreateUser(user);

            // Assert
            Assert.Equal(422, result.StatusCode);
        }

    }
}