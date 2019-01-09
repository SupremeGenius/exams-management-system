using EMS.Business;
using EMS.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EMS.Tests.Users
{
    public class UserServiceTest
    {
        private readonly User user;
        private readonly CreatingUserModel creatingUserModel;
        private readonly Mock<IRepository> mockRepo;
        private readonly UserService userService;
        private readonly Guid guid;

        public UserServiceTest()
        {
            user = new User();
            creatingUserModel = new CreatingUserModel();
            mockRepo = new Mock<IRepository>();
            userService = new UserService(mockRepo.Object);
            guid = new Guid("265c5fbe-bea2-4d1a-985e-301bafad739b");
        }

        //[Fact]
        //public async Task Given_CreateNew_When_ModelIsValid_Then_ReturnUserId()
        //{
        //    //mockRepo.Setup(u => u.AddNewAsync(user)).Returns(Task.FromResult(guid));

        //    var userId = await userService.CreateNew(creatingUserModel);

        //    Assert.Equal(guid, userId);
        //}

    }
}
