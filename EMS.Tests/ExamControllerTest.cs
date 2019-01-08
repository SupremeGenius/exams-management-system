using EMS.Business;
using Xunit;
using Moq;
using exams_management_system.Controllers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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
            mockRepo.Setup(e => e.GetAll())
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
            mockRepo.Setup(e => e.CreateNew(createExamModel)).Returns(Id);

            // Act
            var Result = (OkObjectResult)await controller.CreateExam(createExamModel);

            // Assert
            Assert.IsType<OkObjectResult>(Result);
            Assert.Equal(Id.Result, Result.Value);
        }
    }
}