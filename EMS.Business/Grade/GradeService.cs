using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Domain;
using Microsoft.EntityFrameworkCore;

namespace EMS.Business
{
    public sealed class GradeService : IGradeService
    {
        private readonly IRepository repository;

        public GradeService(IRepository repository) => this.repository = repository;

        public async Task<Guid> CreateNew(CreatingGradeModel newGrade)
        {
            var grade = Grade.Create(
                value: newGrade.Value,
                examId: newGrade.ExamId,
                studentId: newGrade.StudentId);

            await this.repository.AddNewAsync(grade);
            await this.repository.SaveAsync();

            return grade.Id;
        }

        public Task<List<GradeDetailsModel>> GetAll() => AllGradeDetails.ToListAsync();

        public Task<GradeDetailsModel> FindById(Guid id) => AllGradeDetails.SingleOrDefaultAsync(g => g.Id == id);

        public Task<List<GradeDetailsModel>> FindByExamId(Guid examId)
        => this.repository.GetAll<Grade>()
                .Where(g => g.ExamId == examId)
                .Include(g => g.Exam)
                .Include(g => g.Student)
                    .ThenInclude(s => s.StudentCourses)
                .Select(eg => new GradeDetailsModel
            {
                Id = eg.Id,
                ExamName = eg.Exam.Course.Title,
                StudentId = eg.Student.Id,
                Value = eg.Value
            }).ToListAsync();       

        public Task<List<GradeDetailsModel>> FindByStudentId(Guid studentId)
        => this.repository.GetAll<Grade>()
                .Where(g => g.StudentId == studentId)
                .Include(g => g.Exam)
                .Include(g => g.Student)
                    .ThenInclude(s => s.StudentCourses)
                .Select(eg => new GradeDetailsModel
                {
                    Id = eg.Id,
                    ExamName = eg.Exam.Course.Title,
                    StudentId = eg.Student.Id,
                    Value = eg.Value
                }).ToListAsync();


        public async Task<bool> Update(Guid id, Grade updatedGrade)
        {
            var gradeToUpdate = await this.repository.FindByIdAsync<Grade>(id);

            if (await repository.TryUpdateModelAsync<Grade>(
                    gradeToUpdate,
                    updatedGrade
                    ))
            {
                await repository.SaveAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(Guid id)
        {
            var grade = await this.repository.FindByIdAsync<Grade>(id);
            if (grade != null)
            {
                await repository.RemoveAsync(grade);
                await repository.SaveAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        private IQueryable<GradeDetailsModel> AllGradeDetails => this.repository.GetAll<Grade>()
          .Select(g => new GradeDetailsModel
          {
              Id = g.Id,
              Value = g.Value,
              ExamName = g.Exam.Course.Title,
              StudentId = g.Student.Id
          });


    }
}