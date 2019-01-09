using EMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EMS.Tests.Users
{
    public class UserEntityTest
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
            var email = "gabigorgan@gmail.com";
            var password = "12345";
            var role = "Student";

            var expectedUser = User.Create(email, password, role);
            var userToUpdate = new User();
            userToUpdate.Update(expectedUser);

            Assert.Equal(userToUpdate.Name, expectedUser.Name);
        }
    }
}
