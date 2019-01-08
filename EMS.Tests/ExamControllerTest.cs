using EMS.Business;
using Xunit;
using Moq;
using exams_management_system.Controllers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
namespace EMS.Tests
{
 public class ExamControllerTest
    {
        private readonly CreatingExamModel createExamModel;
        private readonly UpdateExamModel updateExamModel;
        private readonly Mock<IExamService> mockRepo;
        private readonly ExamsController controller;

        public ExamControllerTest()
        {
            createExamModel = new CreatingExamModel();
            updateExamModel = new UpdateExamModel();
            mockRepo = new Mock<IExamService>();
            controller = new ExamsController(mockRepo.Object);
        }

        [Fact]
        public async Task Given_GetExams_When_ModelIsValid_Then_OkStatusCode()
        {
            // Arrange
            mockRepo
            .Setup(e => e.GetAll())
            .ReturnsAsync(new List<ExamDetailsModel>());

            //Act
            var result = await controller.GetExams();

            //Arrange
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Given_CreateExam_When_ModelIsValid_Then_OkStatusCode()
        {
            // Arrange
            var examGuid = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            var Id = Task.FromResult(examGuid);
            mockRepo
            .Setup(e => e.CreateNew(createExamModel))
            .Returns(Id);

            // Act
            var Result = (OkObjectResult)await controller.CreateExam(createExamModel);

            // Assert
            Assert.IsType<OkObjectResult>(Result);
            Assert.Equal(Id.Result, Result.Value);
        }

        [Fact]
        public async Task Given_CreateExam_When_ModelIsInvalid_Then_BadStatusCode()
        {
            // Arrange
            var guid = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            var id = Task.FromResult(guid);
            mockRepo
            .Setup(e => e.CreateNew(createExamModel))
            .Returns(id);

            controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = await controller.CreateExam(createExamModel);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

            [Fact]
            public async Task Given_GetExamById_When_IdIsValid_Then_OkStatusCode()
            {
                var guid = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
                mockRepo
                .Setup(e => e.FindById(guid))
                .Returns(Task.FromResult(new ExamDetailsModel()));

                // Act
                var result = await controller.GetExamById(guid);

                // Assert
                Assert.IsType<OkObjectResult>(result);
            }
        [Fact]
        public async Task Given_GetExamById_When_IdIsValidButNoExamFound_Then_BadStatusCode()
        {
            mockRepo
            .Setup(e => e.FindById(It.IsIn<Guid>()))
            .Returns(Task.FromResult<ExamDetailsModel>(null));

            // Act
            var result = (StatusCodeResult)await controller.GetExamById(It.IsAny<Guid>());

            // Assert
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }

 }
}