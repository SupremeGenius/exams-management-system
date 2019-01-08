using AutoMapper;
using EMS.Business;
using EMS.Domain;
using exams_management_system.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EMS.Tests
{
 [Collection("EMS Collection")]
    public class UsersUnitTest
    {
        private readonly UpdateUserModel updateUserModel;
        private readonly Mock<IUserService> mockRepo;
        private readonly UsersController controller;
        private readonly User userModel;

        public UsersUnitTest()
        {
            updateUserModel = new UpdateUserModel();
            mockRepo = new Mock<IUserService>();
            controller = new UsersController(mockRepo.Object);
            userModel = Mapper.Map<UpdateUserModel, User>(updateUserModel);
        }

        [Fact]
        public async Task Given_UpdateUser_When_ModelIsValid_Then_OkStatusCode()
        {
            // Arrange
            mockRepo.Setup(u => u.FindById(It.IsAny<Guid>())).ReturnsAsync(new UserDetailsModel());
            mockRepo.Setup(u => u.UpdateAsync(It.IsAny<Guid>(), It.IsAny<User>(),It.IsAny<string>())).ReturnsAsync(true);

            //Act
            var result = await controller.UpdateUser(updateUserModel, It.IsAny<Guid>());

            //Arrange
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Given_UpdateUser_When_ModelIsValid_Then_NoContentStatusCode()
        {
            // Arrange
            mockRepo.Setup(u => u.FindById(It.IsAny<Guid>())).ReturnsAsync(new UserDetailsModel());
            mockRepo.Setup(u => u.UpdateAsync(It.IsAny<Guid>(), userModel, "")).ReturnsAsync(true);

            //Act
            var result = await controller.UpdateUser(updateUserModel, It.IsAny<Guid>());

            //Arrange
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Given_UpdateUser_When_ModelIsInValid_Then_BadModel()
        {
            // Arrange
            mockRepo.Setup(u => u.UpdateAsync(It.IsAny<Guid>(), userModel, "")).ReturnsAsync(true);
            controller.ModelState.AddModelError("password", "Required");

            //Act
            var result = await controller.UpdateUser(updateUserModel, It.IsAny<Guid>());

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public async Task Given_DeleteUser_When_IdIsValid_Then_OkStatusCode()
        {
            //Arrange
            mockRepo.Setup(u => u.FindById(It.IsAny<Guid>())).ReturnsAsync(new UserDetailsModel());
            mockRepo.Setup(u => u.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            //Act
            var result = await controller.DeleteUser(It.IsAny<Guid>());

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Given_DeleteUser_When_IdIsValid_Then_Status409Conflict()
        {
            //Arrange
            mockRepo.Setup(u => u.FindById(It.IsAny<Guid>())).ReturnsAsync(new UserDetailsModel());
            mockRepo.Setup(u => u.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

            //Act
            var result =(StatusCodeResult)await controller.DeleteUser(It.IsAny<Guid>());

            //Assert
            Assert.Equal(StatusCodes.Status409Conflict, result.StatusCode);
        }

    }
}
