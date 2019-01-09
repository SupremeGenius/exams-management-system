using EMS.Business;
using EMS.Domain.Entities;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EMS.Tests
{
    public class StudentEntityUnitTest
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
            var guid = new Guid("5e10b03b-f239-44ed-ba22-d2149a1e105e");
            var expectedGuid = new Guid("ef4ce858-23f8-4807-9d76-db3823207f86");

            var student = Student.Create(guid);

            // TODO: somehow mock expectedStudent (or a StudentService)
            var expectedStudent = Student.Create(expectedGuid);


            student.Update(expectedStudent);

           
            Assert.Equal(student.FatherInitial, expectedStudent.FatherInitial);
        }
    }
}
