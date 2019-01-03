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

namespace XUnitTestProject1
{
    public class UsersUnitTest
    {
        [Fact]
        public async Task Given_UpdateUser_When_ModelIsValid_Then_OkStatusCode()
        {
            // Arrange
            var updateUserModel = new UpdateUserModel();
            var mockRepo = new Mock<IUserService>();

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UpdateUserModel, User>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.NewPassword));
            });
            var userModel = Mapper.Map<UpdateUserModel, User>(updateUserModel);

            mockRepo.Setup(u => u.UpdateAsync(It.IsAny<Guid>(), It.IsAny<User>(),It.IsAny<string>())).
                Returns(Task.FromResult(true));

            var controller = new UsersController(mockRepo.Object);

            //Act
            var result = await controller.UpdateUser(updateUserModel, It.IsAny<Guid>());

            //Arrange
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Given_UpdateUser_When_ModelIsValid_Then_NoContentStatusCode()
        {
            // Arrange
            var updateUserModel = new UpdateUserModel();
            var oldPassword = "";
            var mockRepo = new Mock<IUserService>();
            var id = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            var true_value = Task.FromResult(true);

            var userModel = Mapper.Map<UpdateUserModel, User>(updateUserModel);

            mockRepo.Setup(u => u.UpdateAsync(id, userModel, oldPassword)).Returns(true_value);

            var controller = new UsersController(mockRepo.Object);

            //Act
            var result = await controller.UpdateUser(updateUserModel, id);

            //Arrange
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Given_UpdateUser_When_ModelIsInValid_Then_BadModel()
        {
            // Arrange
            var updateUserModel = new UpdateUserModel();
            var oldPassword = "";
            var mockRepo = new Mock<IUserService>();
            var id = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            var true_value = Task.FromResult(true);

            var userModel = Mapper.Map<UpdateUserModel, User>(updateUserModel);

            mockRepo.Setup(u => u.UpdateAsync(id, userModel, oldPassword)).Returns(true_value);

            var controller = new UsersController(mockRepo.Object);
            controller.ModelState.AddModelError("password", "Required");

            //Act
            var result = await controller.UpdateUser(updateUserModel, id);

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public async Task Given_DeleteUser_When_IdIsValid_Then_OkStatusCode()
        {
            //Arrange
            var mockRepo = new Mock<IUserService>();
            var true_result = Task.FromResult(true);
            mockRepo.Setup(u => u.Delete(It.IsAny<Guid>())).Returns(true_result);
            var controller = new UsersController(mockRepo.Object);

            //Act
            var result = await controller.DeleteUser(It.IsAny<Guid>());

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Given_DeleteUser_When_IdIsValid_Then_Status409Conflict()
        {
            //Arrange
            var mockRepo = new Mock<IUserService>();
            var false_result = Task.FromResult(false);
            mockRepo.Setup(u => u.Delete(It.IsAny<Guid>())).Returns(false_result);
            var controller = new UsersController(mockRepo.Object);

            //Act
            var result =(StatusCodeResult)await controller.DeleteUser(It.IsAny<Guid>());

            //Assert
            Assert.Equal(StatusCodes.Status409Conflict, result.StatusCode);
        }
    }
}
