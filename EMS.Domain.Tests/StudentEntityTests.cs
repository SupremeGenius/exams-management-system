using EMS.Domain.Entities;
using System;
using Xunit;

namespace EMS.Domain.Tests
{
    public class StudentEntityTests
    {
        // TODO: mock StudentService

        [Fact]
        public void Given_Create_WhenArgumentIsValid_ThenCreateStudent_Positive()
        {
            var guid = new Guid("6f43b564-4e81-4135-b8e5-47db470cf111");
            var expectedStudent = Student.Create(guid);

            Assert.Equal(guid, expectedStudent.UserId);
        }

        //[Fact]
        public void Given_Update_WhenArgumentIsValid_ThenUpdateProfessor_Positive()
        {
            //Arrange
            var guid = new Guid("5e10b03b-f239-44ed-ba22-d2149a1e105e");
            var expectedGuid = new Guid("ef4ce858-23f8-4807-9d76-db3823207f86");
            var student = Student.Create(guid);
            var expectedStudent = Student.Create(expectedGuid);

            //Arrange
            student.Update(expectedStudent);
    
            //Assert
            Assert.Equal(student.FatherInitial, expectedStudent.FatherInitial);
        }
    }
}
