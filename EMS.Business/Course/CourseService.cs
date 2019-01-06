﻿using System;
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

        public async Task<bool> Update(Guid id, Course updatedCourse)
        {
            var courseToUpdate = await this.repository.FindByIdAsync<Course>(id);

            if (courseToUpdate == null) return false;

            if (await repository.TryUpdateModelAsync<Course>(
                    courseToUpdate,
                    updatedCourse
                    ))
            {
                await repository.SaveAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(Guid id)
        {
            var course = await this.repository.FindByIdAsync<Course>(id);

            await repository.RemoveAsync<Course>(course);
            await repository.SaveAsync();
            return true;
        }
    }
}
