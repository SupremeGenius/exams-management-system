using EMS.Domain.Entities;
using System;
using Xunit;


namespace EMS.Domain.Tests
{
    public class ExamDomainTests
    {
        [Fact]
        public void Given_Create_WhenArgumentIsValid_ThenCreateExam()
        {
            DateTime date = new DateTime(2019, 1, 1);
            var professorId = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            var courseId = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");

            var exam = Exam.Create("partial", date, courseId, professorId, "C309");
            Assert.Equal(exam.Type, "partial");
            Assert.Equal(exam.Date, date);
            Assert.Equal(exam.CourseId, courseId);
            Assert.Equal(exam.ProfessorId, professorId);
        }

        [Fact]
        public void Given_Update_When_ModelIsValid_Then_Update()
        {
            DateTime date = new DateTime(2019, 1, 1);
            DateTime dateForUpdate = new DateTime(2019, 1, 2);
            var professorId = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");
            var professorIdforUpdate = new Guid("857d85b0-7af4-40fd-8d38-e1c643121098");
            var courseId = new Guid("cee66981-ca9e-44f6-919f-9abbf4ad8cb0");
            var courseIdforUpdate = new Guid("63962739-929a-443a-9e2c-e1ecfc7fb74c");

            var toBeUpdated = Exam.Create("partial", date, courseId, professorId,"C309");
            var forUpdate = Exam.Create("restanta", dateForUpdate, courseIdforUpdate, professorIdforUpdate, "C308");
            toBeUpdated.Update(forUpdate);
            Assert.Equal(toBeUpdated.Type, forUpdate.Type);
            Assert.Equal(toBeUpdated.Date, forUpdate.Date);
            Assert.Equal(toBeUpdated.CourseId, forUpdate.CourseId);
            Assert.Equal(toBeUpdated.ProfessorId, forUpdate.ProfessorId);
            Assert.Equal(toBeUpdated.Room, forUpdate.Room);
        }
    }
}
