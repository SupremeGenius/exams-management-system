using EMS.Business;
using Xunit;
using Moq;
using exams_management_system.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EMS.Tests
{
    public class RegisterControllerTest
    {
        private readonly CreatingUserModel newModel;
        private readonly Mock<IUserService> mockRepo;
        private readonly Mock<IProfessorService> mockRepoProf;
        private readonly RegisterController controller;
        private readonly Guid guid;

        public RegisterControllerTest()
        {
            newModel = new CreatingUserModel();
            mockRepo = new Mock<IUserService>();
            mockRepoProf = new Mock<IProfessorService>();
            controller = new RegisterController(mockRepo.Object, mockRepoProf.Object);
            guid = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
        }
        [Fact]
        public async Task Given_CreateUser_When_ModelIsValid_Then_OkStatusCode()
        {
            // Arrange
            mockRepo.Setup(u => u.CreateNew(newModel)).Returns(Task.FromResult(guid));

            // Act
            var result = await controller.CreateUser(newModel);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task Given_CreateUser_When_ModelIsInvalid_Then_BadStatusCode()
        {
            // Arrange
            mockRepo.Setup(u => u.CreateNew(newModel)).Returns(Task.FromResult(guid));
            controller.ModelState.AddModelError("email", "Required");

            // Act
            var result = await controller.CreateUser(newModel);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public async Task Given_CreateUser_When_ModelIsValid_Then_Status422UnprocessableEntity()
        {
            mockRepo.Setup(u => u.FindByEmail(newModel.Email)).Returns(Task.FromResult(new UserDetailsModel()));
            
            // Act
            var result = (StatusCodeResult) await controller.CreateUser(newModel);

            // Assert
            Assert.Equal(422, result.StatusCode);
        }

    }
}