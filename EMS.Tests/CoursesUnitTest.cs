using EMS.Business;
using Xunit;
using Moq;
using exams_management_system.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using EMS.Domain;
using Microsoft.AspNetCore.Http;
using AutoMapper;

namespace XUnitTestProject1
{
    public class CoursesUnitTest : IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;

        private readonly UpdateCourseModel updateCourseModel;
        private readonly CreatingCourseModel createCourseModel;
        private readonly Mock<ICourseService> mockRepo;
        private readonly CoursesController controller;
        private readonly Course courseModel;

        public CoursesUnitTest()
        {
            updateCourseModel = new UpdateCourseModel();
            createCourseModel = new CreatingCourseModel();
            mockRepo = new Mock<ICourseService>();
            controller = new CoursesController(mockRepo.Object);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UpdateCourseModel, Course>();
            });
            courseModel = Mapper.Map<UpdateCourseModel, Course>(updateCourseModel);
        }

        [Fact]
        public async Task Given_CreateCourse_When_ModelIsValid_Then_OkStatusCode()
        {
            // Arrange
            var Guid = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            var Id = Task.FromResult(Guid);
            mockRepo.Setup(u => u.CreateNew(createCourseModel)).Returns(Id);

            // Act
            var Result = (OkObjectResult)await controller.CreateCourse(createCourseModel);

            // Assert
            Assert.IsType<OkObjectResult>(Result);
            Assert.Equal(Id.Result, Result.Value);
        }
        [Fact]
        public async Task Given_CreateCourse_When_ModelIsInvalid_Then_BadStatusCode()
        {
            // Arrange
            var guid = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            var id = Task.FromResult(guid);
            mockRepo.Setup(u => u.CreateNew(createCourseModel)).Returns(id);

            controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = await controller.CreateCourse(createCourseModel);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public async Task Given_GetCourseById_When_IdIsValid_Then_OkStatusCode()
        {
            var guid = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            mockRepo.Setup(u => u.FindById(guid)).Returns(Task.FromResult(new CourseDetailsModel()));

            // Act
            var result = await controller.GetCourseById(guid);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Given_GetCourseById_When_IdIsValidButNoCourseFound_Then_BadStatusCode()
        {
            mockRepo.Setup(u => u.FindById(It.IsIn<Guid>())).Returns(Task.FromResult<CourseDetailsModel>(null));

            var controller = new CoursesController(mockRepo.Object);

            // Act
            var result = (StatusCodeResult)await controller.GetCourseById(It.IsAny<Guid>());

            // Assert
            Assert.Equal(422, result.StatusCode);
        }

        [Fact]
        public async Task Given_UpdateCourse_When_ModelIsValid_Then_OkStatusCode()
        {
            // Arrange
            mockRepo.Setup(u => u.Update(It.IsAny<Guid>(), It.IsAny<Course>())).
                Returns(Task.FromResult(true));

            //Act
            var result = await controller.UpdateCourse(updateCourseModel, It.IsAny<Guid>());

            //Arrange
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Given_UpdateCourse_When_ModelIsInvalid_Then_BadStatusCode()
        {
            // Arrange
            mockRepo.Setup(u => u.Update(It.IsAny<Guid>(), It.IsAny<Course>())).
                Returns(Task.FromResult(true));

            //Act
            controller.ModelState.AddModelError("id", "1234");
            var result = await controller.UpdateCourse(updateCourseModel, It.IsAny<Guid>());

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public async Task Given_DeleteCourse_When_IdIsValid_Then_OkStatusCode()
        {
            //Arrange
            mockRepo.Setup(u => u.Delete(It.IsAny<Guid>())).Returns(Task.FromResult(true));

            //Act
            var result = await controller.DeleteCourse(It.IsAny<Guid>());

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Given_DeleteCourse_When_IdIsValid_Then_Status409Conflict()
        {
            //Arrange
            mockRepo.Setup(u => u.Delete(It.IsAny<Guid>())).Returns(Task.FromResult(false));

            //Act
            var result = (StatusCodeResult)await controller.DeleteCourse(It.IsAny<Guid>());

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