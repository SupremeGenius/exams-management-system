using AutoMapper;
using EMS.Business;
using EMS.Domain;
using EMS.Domain.Entities;
using EMS.Tests;
using exams_management_system.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace EMS.Tests
{
    [Collection("EMS Collection")]
    public class ProfessorsUnitTest
    {
        private readonly CreatingProfessorModel creatingProfessorModel;
        private readonly Mock<IProfessorService> mockRepo;
        private readonly ProfessorController controller;
        private readonly Professor professorModel;

        public ProfessorsUnitTest()
        {
            creatingProfessorModel = new CreatingProfessorModel();
            mockRepo = new Mock<IProfessorService>();
            controller = new ProfessorController(mockRepo.Object);

            /*Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CreatingProfessorModel, Professor>();

            });*/
            professorModel = Mapper.Map<CreatingProfessorModel, Professor>(creatingProfessorModel);
        }

        [Fact]
        public async Task Given_GetProfessors_When_ThereAreNoProfessors_Then_OkStatusCode()
        {
            mockRepo.Setup(p => p.GetAll()).ReturnsAsync(new List<ProfessorDetailsModel>());

            // Act
            var result = await controller.GetProfessors();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Given_GetProfessors_When_ThereAreProfessors_Then_OkStatusCode()
        {
            var professors = new List<ProfessorDetailsModel>();
            professors.Add(new ProfessorDetailsModel());
            mockRepo.Setup(p => p.GetAll()).ReturnsAsync(professors);

            // Act
            var result = await controller.GetProfessors();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Given_GetProfessorById_When_IdIsValid_Then_OkStatusCode()
        {
            var guid = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            mockRepo.Setup(p => p.FindById(guid)).Returns(Task.FromResult(new ProfessorDetailsModel()));

            // Act
            var result = await controller.GetProfessorById(guid);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public async Task Given_GetProfessorById_When_IdIsValidButNoCourseFound_Then_BadStatusCode()
        {
            mockRepo.Setup(p => p.FindById(It.IsIn<Guid>())).Returns(Task.FromResult<ProfessorDetailsModel>(null));

            var controller = new ProfessorController(mockRepo.Object);

            // Act
            var result = (StatusCodeResult)await controller.GetProfessorById(It.IsAny<Guid>());

            // Assert
            Assert.Equal(422, result.StatusCode);
        }

        [Fact]
        public async Task Given_UpdateProfessor_When_ModelIsValid_Then_OkStatusCode()
        {
            // Arrange
            mockRepo.Setup(u => u.UpdateAsync(It.IsAny<Guid>(), It.IsAny<Professor>())).
                Returns(Task.FromResult(true));

            //Act
            var result = await controller.UpdateProfessor(creatingProfessorModel, It.IsAny<Guid>());

            //Arrange
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Given_UpdateProfessor_When_ModelIsValid_Then_NoContentStatusCode()
        {
            // Arrange
            mockRepo.Setup(u => u.UpdateAsync(It.IsAny<Guid>(), professorModel)).Returns(Task.FromResult(true));

            //Act
            var result = await controller.UpdateProfessor(creatingProfessorModel, It.IsAny<Guid>());

            //Arrange
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Given_UpdateProfessor_When_ModelIsInValid_Then_BadModel()
        {
            // Arrange
            mockRepo.Setup(u => u.UpdateAsync(It.IsAny<Guid>(), professorModel)).Returns(Task.FromResult(true));
            controller.ModelState.AddModelError("password", "Required");

            //Act
            var result = await controller.UpdateProfessor(creatingProfessorModel, It.IsAny<Guid>());

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

    }
}
