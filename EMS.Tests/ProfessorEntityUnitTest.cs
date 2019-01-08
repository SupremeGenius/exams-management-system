using EMS.Domain.Entities;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EMS.Tests
{
    public class ProfessorEntityUnitTest
    {

        [Fact]
        public void Given_Create_WhenArgumentIsValid_ThenCreateProfessor()
        {
            var guid = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            var expectedProfessor = Professor.Create(guid);

            Assert.Equal(guid, expectedProfessor.UserId);
        }

        /*[Fact]
        public void Given_Update_WhenArgumentIsValid_ThenUpdateProfessor()
        {
            var guid = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            var expectedGuid = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ad");
            var expectedProfessor = Professor.Create(expectedGuid);
            var professor = Professor.Create(guid);

            professor.Update(expectedProfessor);
            
            Assert.Equal(professor.Title, expectedProfessor.Title);
        }*/
    }
}
