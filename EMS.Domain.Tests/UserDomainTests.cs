using Xunit;

namespace EMS.Domain.Tests
{
    public class UserEntityTests
    {
        [Fact]
        public void Given_Create_When_ArgumentIsValid_ThenCreateUser()
        {
            var email = "gabigorgan@gmail.com";
            var password = "12345";
            var role = "Student";

            var expectedUser = User.Create(email, password, role);
            
            Assert.Equal(expectedUser.Email, email);
            Assert.Equal(expectedUser.Password, password);
            Assert.Equal(expectedUser.Role, role);
        }
        [Fact]
        public void Given_Update_When_ArgumentIsValid_ThenUpdateUser()
        {
            //Arrange
            var email = "gabigorgan@gmail.com";
            var password = "12345";
            var role = "Student";

            //Act
            var expectedUser = User.Create(email, password, role);
            var userToUpdate = new User();
            userToUpdate.Update(expectedUser);

            //Assert
            Assert.Equal(userToUpdate.Password, expectedUser.Password);
        }
    }
}
