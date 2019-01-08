using EMS.Domain;
using Xunit;

namespace EMS.Tests
{
    public class CoursesDomainUnitTest
    {
        [Fact]
        public void Given_Create_When_ModelIsValid_Then_Create()
        {
            var course = Course.Create("BD", "2017-2018", 2, 1);
            var expectedCourse = new Course()
            {
                Title = "BD",
                UniversityYear = "2017-2018",
                StudentYear = 2,
                Semester = 1
            };
            Assert.Equal(course.Title, expectedCourse.Title);
            Assert.Equal(course.UniversityYear, expectedCourse.UniversityYear);
            Assert.Equal(course.StudentYear, expectedCourse.StudentYear);
            Assert.Equal(course.Semester, expectedCourse.Semester);
        }

        [Fact]
        public void Given_Update_When_ModelIsValid_Then_Update()
        {
            var toBeUpdated = Course.Create("Mate", "2014-2015", 1, 3);
            var forUpdate= new Course()
            {
                Title = "BD",
                UniversityYear = "2017-2018",
                StudentYear = 2,
                Semester = 1
            };
            toBeUpdated.Update(forUpdate);
            Assert.Equal(toBeUpdated.Title, forUpdate.Title);
            Assert.Equal(toBeUpdated.UniversityYear, forUpdate.UniversityYear);
            Assert.Equal(toBeUpdated.StudentYear, forUpdate.StudentYear);
            Assert.Equal(toBeUpdated.Semester, forUpdate.Semester);
        }

    }
}
