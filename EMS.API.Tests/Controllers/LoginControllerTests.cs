using EMS.Business;
using Xunit;
using Moq;
using exams_management_system.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Tests
{
    public class LoginControllerTests
    {
        private readonly RegisterModel newModel;
        private readonly Mock<IUserService> mockRepo;
        private readonly LoginController controller;

        public LoginControllerTests()
        {
            newModel = new RegisterModel();
            mockRepo = new Mock<IUserService>();
            controller = new LoginController(mockRepo.Object);
        }
   
        [Fact]
        public async Task Given_FindUser_When_ModelIsValid_Then_OkStatusCode()
        {
            // Arrange
            mockRepo.Setup(u => u.FindByEmail(newModel.Email)).ReturnsAsync(new UserDetailsModel());

            // Act
            var result = await controller.FindUser(newModel);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Given_FindUser_When_ModelIsInvalid_Then_BadStatusCode()
        {
            // Arrange
            mockRepo.Setup(u => u.FindByEmail(newModel.Email)).ReturnsAsync(new UserDetailsModel());
            controller.ModelState.AddModelError("Role", "Required");

            // Act
            var result = await controller.FindUser(newModel);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public async Task Given_FindUser_When_ModelIsValid_Then_StatusCode422UnprocessableEntity()
        {
            //Arrange
            mockRepo.Setup(u => u.FindByEmail(newModel.Email)).ReturnsAsync((UserDetailsModel)null);

            //Act
            var result = (StatusCodeResult)await controller.FindUser(newModel);

            //Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task Given_CreateUser_When_ModelIsValid_Then_Status422UnprocessableEntity()
        {
            //Arrange
            var user = new RegisterModel
            {
                Password = "alabalaportocala"
            };
            mockRepo.Setup(u => u.FindByEmail(user.Email)).ReturnsAsync(new UserDetailsModel());

            // Act
            var result = (StatusCodeResult)await controller.FindUser(user);

            // Assert
            Assert.Equal(422, result.StatusCode);
        }
    }
}