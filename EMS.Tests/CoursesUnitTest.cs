using EMS.Business;
using Xunit;
using Moq;
using exams_management_system.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using EMS.Domain;

namespace XUnitTestProject1
{
    public class CoursesUnitTest
    {
        private readonly UpdateCourseModel updateCourseModel;
        private readonly CreatingCourseModel createCourseModel;
        private readonly Mock<ICourseService> mockRepo;
        private readonly CoursesController controller;
        private readonly Course courseModel;

        public CoursesUnitTest()
        {
            updateCourseModel = new UpdateCourseModel();
            mockRepo = new Mock<ICourseService>();
            controller = new CoursesController(mockRepo.Object);
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

    }
}