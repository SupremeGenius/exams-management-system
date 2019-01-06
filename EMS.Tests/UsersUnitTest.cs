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
    public class UsersFixture : IDisposable
    {
        public readonly UpdateUserModel updateUserModel;
        public readonly Mock<IUserService> mockRepo;
        public readonly UsersController controller;
        public readonly User userModel;

        public UsersFixture()
        {
            updateUserModel = new UpdateUserModel();
            mockRepo = new Mock<IUserService>();
            controller = new UsersController(mockRepo.Object);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UpdateUserModel, User>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.NewPassword));
            });
            userModel = Mapper.Map<UpdateUserModel, User>(updateUserModel);
        }

        public void Dispose()
        {
            Mapper.Reset();
        }
    }

    public class UsersUnitTest : IClassFixture<UsersFixture>
    {
        UsersFixture usersFixture;

        public UsersUnitTest(UsersFixture usersFixture)
        {
            this.usersFixture = usersFixture;
        }

        public void Dispose()
        {
            Mapper.Reset();
        }

        [Fact]
        public async Task Given_UpdateUser_When_ModelIsValid_Then_OkStatusCode()
        {
            // Arrange
            usersFixture.mockRepo.Setup(u => u.UpdateAsync(It.IsAny<Guid>(), It.IsAny<User>(),It.IsAny<string>())).
                Returns(Task.FromResult(true));

            //Act
            var result = await usersFixture.controller.UpdateUser(usersFixture.updateUserModel, It.IsAny<Guid>());

            //Arrange
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Given_UpdateUser_When_ModelIsValid_Then_NoContentStatusCode()
        {
            // Arrange
            usersFixture.mockRepo.Setup(u => u.UpdateAsync(It.IsAny<Guid>(), usersFixture.userModel, "")).Returns(Task.FromResult(false));

            //Act
            var result = await usersFixture.controller.UpdateUser(usersFixture.updateUserModel, It.IsAny<Guid>());

            //Arrange
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Given_UpdateUser_When_ModelIsInValid_Then_BadModel()
        {
            // Arrange
            usersFixture.mockRepo.Setup(u => u.UpdateAsync(It.IsAny<Guid>(), usersFixture.userModel, "")).Returns(Task.FromResult(true));
            usersFixture.controller.ModelState.AddModelError("password", "Required");

            //Act
            var result = await usersFixture.controller.UpdateUser(usersFixture.updateUserModel, It.IsAny<Guid>());

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public async Task Given_DeleteUser_When_IdIsValid_Then_OkStatusCode()
        {
            //Arrange
            usersFixture.mockRepo.Setup(u => u.Delete(It.IsAny<Guid>())).Returns(Task.FromResult(true));

            //Act
            var result = await usersFixture.controller.DeleteUser(It.IsAny<Guid>());

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Given_DeleteUser_When_IdIsValid_Then_Status409Conflict()
        {
            //Arrange
            usersFixture.mockRepo.Setup(u => u.Delete(It.IsAny<Guid>())).Returns(Task.FromResult(false));

            //Act
            var result =(StatusCodeResult)await usersFixture.controller.DeleteUser(It.IsAny<Guid>());

            //Assert
            Assert.Equal(StatusCodes.Status409Conflict, result.StatusCode);
        }
    }
}
