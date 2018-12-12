using EMS.Business;
using Xunit;
using Moq;
using exams_management_system.Controllers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public async Task CreateUser_when_registering()
        {
            // Arrange
            var expected_id = "b27cf5c3-9834-40ef-8648-e8fc4a9400f0";
            var mock = new Mock<IUserService>();
            var user = new CreatingUserModel();
            var id = Task.FromResult(Guid.NewGuid());
            mock.Setup(u => u.CreateNew(user)).Returns(id);

            var controller = new RegisterController(mock.Object);

            // Act
            var result = await controller.CreateUser(user);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
        }
    }
}
