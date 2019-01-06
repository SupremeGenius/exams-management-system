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
    public class UsersUnitTest : IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;

        private readonly UpdateUserModel updateUserModel;
        private readonly Mock<IUserService> mockRepo;
        private readonly UsersController controller;
        private readonly User userModel;

        public UsersUnitTest()
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

        [Fact]
        public async Task Given_UpdateUser_When_ModelIsValid_Then_OkStatusCode()
        {
            // Arrange
            mockRepo.Setup(u => u.UpdateAsync(It.IsAny<Guid>(), It.IsAny<User>(),It.IsAny<string>())).
                Returns(Task.FromResult(true));

            //Act
            var result = await controller.UpdateUser(updateUserModel, It.IsAny<Guid>());

            //Arrange
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Given_UpdateUser_When_ModelIsValid_Then_NoContentStatusCode()
        {
            // Arrange
            mockRepo.Setup(u => u.UpdateAsync(It.IsAny<Guid>(), userModel, "")).Returns(Task.FromResult(true));

            //Act
            var result = await controller.UpdateUser(updateUserModel, It.IsAny<Guid>());

            //Arrange
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Given_UpdateUser_When_ModelIsInValid_Then_BadModel()
        {
            // Arrange
            mockRepo.Setup(u => u.UpdateAsync(It.IsAny<Guid>(), userModel, "")).Returns(Task.FromResult(true));
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
            mockRepo.Setup(u => u.Delete(It.IsAny<Guid>())).Returns(Task.FromResult(true));

            //Act
            var result = await controller.DeleteUser(It.IsAny<Guid>());

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Given_DeleteUser_When_IdIsValid_Then_Status409Conflict()
        {
            //Arrange
            mockRepo.Setup(u => u.Delete(It.IsAny<Guid>())).Returns(Task.FromResult(false));

            //Act
            var result =(StatusCodeResult)await controller.DeleteUser(It.IsAny<Guid>());

            //Assert
            Assert.Equal(StatusCodes.Status409Conflict, result.StatusCode);
        }

        public void Dispose()
        {
            Dispose(true);

            // Use SupressFinalize in case a subclass 
            // of this type implements a finalizer.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                Mapper.Reset();
                //
            }
            disposed = true;
        }
    }
}
