using EMS.Business;
using Xunit;
using Moq;
using exams_management_system.Controllers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Tests
{
    public class ExamControllerTest
    {
        private readonly UpdateExamModel updateExamModel;
        private readonly Mock<IExamService> mockRepo;
        private readonly ExamsController controller;

        public ExamControllerTest()
        {
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
    }
}