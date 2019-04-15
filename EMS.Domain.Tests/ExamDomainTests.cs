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
            var courseId = new Guid("ef7e98df-26ed-4b21-b874-c3a2815d18ac");

            var exam = Exam.Create("partial", date, courseId, "C309");
            Assert.Equal(exam.Type, "partial");
            Assert.Equal(exam.Date, date);
            Assert.Equal(exam.CourseId, courseId);
        }

        [Fact]
        public void Given_Update_When_ModelIsValid_Then_Update()
        {
            DateTime date = new DateTime(2019, 1, 1);
            DateTime dateForUpdate = new DateTime(2019, 1, 2);
            var courseId = new Guid("cee66981-ca9e-44f6-919f-9abbf4ad8cb0");
            var courseIdforUpdate = new Guid("63962739-929a-443a-9e2c-e1ecfc7fb74c");

            var toBeUpdated = Exam.Create("partial", date, courseId,"C309");
            var forUpdate = Exam.Create("restanta", dateForUpdate, courseIdforUpdate, "C308");
            toBeUpdated.Update(forUpdate);
            Assert.Equal(toBeUpdated.Type, forUpdate.Type);
            Assert.Equal(toBeUpdated.Date, forUpdate.Date);
            Assert.Equal(toBeUpdated.CourseId, forUpdate.CourseId);
            Assert.Equal(toBeUpdated.Room, forUpdate.Room);
        }
    }
}
