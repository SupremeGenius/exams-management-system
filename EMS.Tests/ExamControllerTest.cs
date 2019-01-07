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

        [Fact]
        public async Task Given_GetExams_When_ModelIsValid_Then_OkStatusCode()
        {
            // Arrange
            var NewModel = new CreatingExamModel();
            var ExpectedModel = new List<ExamDetailsModel>();
            var MockRepo = new Mock<IExamService>();
            var Exams = Task.FromResult(ExpectedModel);
            MockRepo.Setup(u => u.GetAll()).Returns(Exams);
            var Controller = new ExamsController(MockRepo.Object);

            // Act
            var result = await Controller.GetExams();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}