using EMS.Domain.Entities;
using System;
using Xunit;

namespace EMS.Domain.Tests
{
    public class GradeDomainTests
    {

        [Fact]
        public void Given_Create_WhenArgumentIsValid_ThenCreateGrade()
        {
            var examId = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            var studentId = new Guid("8c9a1f54-db8f-4e87-8ab6-6235c4639ab9");
            var expectedGrade = Grade.Create(9,examId,studentId);

            //Assert.Equal(9, expectedGrade.Nota);
            Assert.Equal(examId, expectedGrade.ExamId);
            Assert.Equal(studentId, expectedGrade.StudentId);
        }

        [Fact]
        public void Given_Update_When_ModelIsValid_Then_Update()
        {
            var examId = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            var examIdforUpdate = new Guid("857d85b0-7af4-40fd-8d38-e1c643121098");
            var studentId = new Guid("cee66981-ca9e-44f6-919f-9abbf4ad8cb0");
            var studentIdforUpdate = new Guid("63962739-929a-443a-9e2c-e1ecfc7fb74c");

            var toBeUpdated = Grade.Create(5, examId, studentId );
            var forUpdate = Grade.Create(6, examIdforUpdate, studentIdforUpdate);
            toBeUpdated.Update(forUpdate);
            //Assert.Equal(toBeUpdated.Nota, forUpdate.Nota);
            Assert.Equal(toBeUpdated.ExamId, forUpdate.ExamId);
            Assert.Equal(toBeUpdated.StudentId, forUpdate.StudentId);
        }
    }
}
