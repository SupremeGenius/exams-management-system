using EMS.Business;
using Xunit;
using Moq;
using exams_management_system.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;

namespace XUnitTestProject1
{
    public class CoursesUnitTest
    {
        [Fact]
        public async Task Given_CreateCourse_When_ModelIsValid_Then_OkStatusCode()
        {
            // Arrange
            var Guid = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            var Mock = new Mock<ICourseService>();
            var Course = new CreatingCourseModel();
            var Id = Task.FromResult(Guid);
            Mock.Setup(u => u.CreateNew(Course)).Returns(Id);

            var Controller = new CoursesController(Mock.Object);

            // Act
            var Result =(OkObjectResult) await Controller.CreateCourse(Course);

            // Assert
            Assert.IsType<OkObjectResult>(Result);
            Assert.Equal(Id.Result, Result.Value);
        }
        [Fact]
        public async Task Given_CreateCourse_When_ModelIsInvalid_Then_BadStatusCode()
        {
            // Arrange
            var guid = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            var mockRepo = new Mock<ICourseService>();
            var course = new CreatingCourseModel();
            var id = Task.FromResult(guid);
            mockRepo.Setup(u => u.CreateNew(course)).Returns(id);

            var controller = new CoursesController(mockRepo.Object);
            controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = await controller.CreateCourse(course);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public async Task Given_GetCourseById_When_IdIsValid_Then_OkStatusCode()
        {
            var guid = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            var mockRepo = new Mock<ICourseService>();
            var course = new CourseDetailsModel();
            var courseResponse = Task.FromResult(course);
            mockRepo.Setup(u => u.FindById(guid)).Returns(courseResponse);

            var controller = new CoursesController(mockRepo.Object);

            // Act
            var result = await controller.GetCourseById(guid);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            // Assert.Equal(Id.Result, Result.Value);
        }

    }
}