using EMS.Domain.Entities;
using System;
using Xunit;

namespace EMS.Domain.Tests
{
    public class ProfessorDomainTests
    {

        [Fact]
        public void Given_Create_WhenArgumentIsValid_ThenCreateProfessor()
        {
            var guid = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            var expectedProfessor = Professor.Create(guid);

            Assert.Equal(guid, expectedProfessor.UserId);
        }

        [Fact]
        public void Given_Update_When_ModelIsValid_Then_Update()
        {
            var guidtbu = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            var guidfu = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");

            var toBeUpdated = Professor.Create(guidtbu);
            var forUpdate = Professor.Create(guidfu);
            toBeUpdated.Update(forUpdate);
            Assert.Equal(toBeUpdated.Title, forUpdate.Title);
            Assert.Equal(toBeUpdated.Name, forUpdate.Name);
        }
    }
}
