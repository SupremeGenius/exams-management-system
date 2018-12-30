using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EMS.Domain;

namespace EMS.Business
{
    public sealed class CourseService : ICourseService
    {
        private readonly IRepository repository;

        public CourseService(IRepository repository) => this.repository = repository;

        public async Task<Guid> CreateNew(CreatingCourseModel newCourse)
        {
            var course = Course.Create(
                title: newCourse.Title,
                universityYear: newCourse.UniversityYear,
                studentYear: newCourse.StudentYear,
                semester: newCourse.Semester);

            await this.repository.AddNewAsync(course);
            await this.repository.SaveAsync();

            return course.Id;
        }

        public Task<List<CourseDetailsModel>> GetAll() => GetAllCourseDetails().ToListAsync();

        public Task<CourseDetailsModel> FindByTitle(string title) => GetAllCourseDetails().SingleOrDefaultAsync(s => s.Title == title);

        public Task<CourseDetailsModel> FindById(Guid id) => GetAllCourseDetails().SingleOrDefaultAsync(s => s.Id == id);
        
        private IQueryable<CourseDetailsModel> GetAllCourseDetails() => this.repository.GetAll<Course>()
            .Select(c => new CourseDetailsModel
            {
                Id = c.Id,
                Title = c.Title,
                CourseProfessors = c.CourseProfessors,
                UniversityYear = c.UniversityYear,
                StudentYear = c.StudentYear,
                Semester = c.Semester
            });

        public void Update(Guid id)
        {
            
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
