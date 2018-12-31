using EMS.Business;
using Xunit;
using Moq;
using exams_management_system.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace XUnitTestProject1
{
    public class LoginControllerTest
    {
   
        [Fact]
        public async Task Given_FindUser_When_ModelIsValid_Then_OkStatusCode()
        {
            // Arrange
            var newModel = new CreatingUserModel();
            var mockRepo = new Mock<IUserService>();
            var expectedModel = Task.FromResult(new UserDetailsModel());
            mockRepo.Setup(u => u.FindByEmail(newModel.Email)).Returns(expectedModel);
            var controller = new LoginController(mockRepo.Object);

            // Act
            var result = await controller.FindUser(newModel);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Given_FindUser_When_ModelIsInvalid_Then_BadStatusCode()
        {
            // Arrange
            var newModel = new CreatingUserModel();
            var mockRepo = new Mock<IUserService>();
            var expectedModel = Task.FromResult(new UserDetailsModel());
            mockRepo.Setup(u => u.FindByEmail(newModel.Email)).Returns(expectedModel);

            var controller = new LoginController(mockRepo.Object);
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
            var newModel = new CreatingUserModel();
            var mockRepo = new Mock<IUserService>();
            var expectedResult = Task.FromResult((UserDetailsModel)null);
            mockRepo.Setup(u => u.FindByEmail(newModel.Email)).Returns(expectedResult);
            var controller = new LoginController(mockRepo.Object);

            //Act
            var result = (StatusCodeResult)await controller.FindUser(newModel);

            //Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task Given_CreateUser_When_ModelIsValid_Then_Status422UnprocessableEntity()
        {
            var mockRepo = new Mock<IUserService>();
            var user = new CreatingUserModel();
            user.Password = "alabalaportocala";
            var userDetails = Task.FromResult(new UserDetailsModel());
            mockRepo.Setup(u => u.FindByEmail(user.Email)).Returns(userDetails);

            var controller = new LoginController(mockRepo.Object);

            // Act
            var result = (StatusCodeResult)await controller.FindUser(user);

            // Assert
            Assert.Equal(422, result.StatusCode);
        }
    }
}