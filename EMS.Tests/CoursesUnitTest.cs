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
    public class CoursesFixture : IDisposable
    {
        public readonly UpdateCourseModel updateCourseModel;
        public readonly CreatingCourseModel createCourseModel;
        public readonly Mock<ICourseService> mockRepo;
        public readonly CoursesController controller;
        public readonly Course courseModel;

        public CoursesFixture()
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

        public void Dispose()
        {
            Mapper.Reset();
        }
    }

    public class CoursesUnitTest : IClassFixture<CoursesFixture>
    {
        CoursesFixture coursesFixture;

        public CoursesUnitTest(CoursesFixture coursesFixture)
        {
            this.coursesFixture = coursesFixture;
        }

        public void Dispose()
        {
            Mapper.Reset();
        }

        [Fact]
        public async Task Given_CreateCourse_When_ModelIsValid_Then_OkStatusCode()
        {
            // Arrange
            var Guid = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            var Id = Task.FromResult(Guid);
            coursesFixture.mockRepo.Setup(u => u.CreateNew(coursesFixture.createCourseModel)).Returns(Id);

            // Act
            var Result = (OkObjectResult)await coursesFixture.controller.CreateCourse(coursesFixture.createCourseModel);

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
            coursesFixture.mockRepo.Setup(u => u.CreateNew(coursesFixture.createCourseModel)).Returns(id);

            coursesFixture.controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = await coursesFixture.controller.CreateCourse(coursesFixture.createCourseModel);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public async Task Given_GetCourseById_When_IdIsValid_Then_OkStatusCode()
        {
            var guid = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            coursesFixture.mockRepo.Setup(u => u.FindById(guid)).Returns(Task.FromResult(new CourseDetailsModel()));

            // Act
            var result = await coursesFixture.controller.GetCourseById(guid);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Given_GetCourseById_When_IdIsValidButNoCourseFound_Then_BadStatusCode()
        {
            coursesFixture.mockRepo.Setup(u => u.FindById(It.IsIn<Guid>())).Returns(Task.FromResult<CourseDetailsModel>(null));

            var controller = new CoursesController(coursesFixture.mockRepo.Object);

            // Act
            var result = (StatusCodeResult)await controller.GetCourseById(It.IsAny<Guid>());

            // Assert
            Assert.Equal(422, result.StatusCode);
        }

        [Fact]
        public async Task Given_UpdateCourse_When_ModelIsValid_Then_OkStatusCode()
        {
            // Arrange
            coursesFixture.mockRepo.Setup(u => u.Update(It.IsAny<Guid>(), It.IsAny<Course>())).
                Returns(Task.FromResult(true));

            //Act
            var result = await coursesFixture.controller.UpdateCourse(coursesFixture.updateCourseModel, It.IsAny<Guid>());

            //Arrange
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Given_UpdateCourse_When_ModelIsInvalid_Then_BadStatusCode()
        {
            // Arrange
            coursesFixture.mockRepo.Setup(u => u.Update(It.IsAny<Guid>(), It.IsAny<Course>())).
                Returns(Task.FromResult(true));

            //Act
            coursesFixture.controller.ModelState.AddModelError("id", "1234");
            var result = await coursesFixture.controller.UpdateCourse(coursesFixture.updateCourseModel, It.IsAny<Guid>());

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public async Task Given_DeleteCourse_When_IdIsValid_Then_OkStatusCode()
        {
            //Arrange
            coursesFixture.mockRepo.Setup(u => u.Delete(It.IsAny<Guid>())).Returns(Task.FromResult(true));

            //Act
            var result = await coursesFixture.controller.DeleteCourse(It.IsAny<Guid>());

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Given_DeleteCourse_When_IdIsValid_Then_Status409Conflict()
        {
            //Arrange
            coursesFixture.mockRepo.Setup(u => u.Delete(It.IsAny<Guid>())).Returns(Task.FromResult(false));

            //Act
            var result = (StatusCodeResult)await coursesFixture.controller.DeleteCourse(It.IsAny<Guid>());

            //Assert
            Assert.Equal(StatusCodes.Status409Conflict, result.StatusCode);
        }
    }
}