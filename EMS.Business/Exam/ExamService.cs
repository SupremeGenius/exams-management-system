using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Domain;
using Microsoft.EntityFrameworkCore;

namespace EMS.Business
{
    public sealed class ExamService : IExamService
    {
        private readonly IRepository repository;

        public ExamService(IRepository repository) => this.repository = repository;

        public async Task<Guid> CreateNew(CreatingExamModel newExam)
        {
            var exam = Exam.Create(
                type: newExam.Type,
                date: newExam.Date,
                courseId: newExam.CourseId,
                professorId: newExam.ProfessorId);

            await this.repository.AddNewAsync(exam);
            await this.repository.SaveAsync();

            return exam.Id;
        }

        public Task<ExamDetailsModel> FindById(Guid id) => AllExamDetails.SingleOrDefaultAsync(e => e.Id == id);

        public Task<List<ExamDetailsModel>> GetAll() => AllExamDetails.ToListAsync();

        public Task<ExamDetailsModel> FindByTime(DateTime date) => AllExamDetails.SingleOrDefaultAsync(e => e.Date == date);

        public async Task<bool> Update(Guid id, Exam updatedExam)

        {
            var examToUpdate = await this.repository.FindByIdAsync<Exam>(id);

            if (await repository.TryUpdateModelAsync<Exam>(
                    examToUpdate,
                    updatedExam
                    ))
            {
                await repository.SaveAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(Guid id)
        {
            var exam = await this.repository.FindByIdAsync<Exam>(id);

            await repository.RemoveAsync<Exam>(exam);
            await repository.SaveAsync();
            return true;
        }
        
        private IQueryable<ExamDetailsModel> AllExamDetails => this.repository.GetAll<Exam>()
          .Select(e => new ExamDetailsModel
          {
              Id = e.Id,
              Type = e.Type,
              Date = e.Date,
              CourseId = e.CourseId,
              ProfessorId = e.ProfessorId
          });
    }
}