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
                nota: newGrade.Nota,
                examId: newGrade.ExamId,
                studentId: newGrade.StudentId);

            await this.repository.AddNewAsync(grade);
            await this.repository.SaveAsync();

            return grade.Id;
        }

        public Task<List<GradeDetailsModel>> GetAll() => AllGradeDetails.ToListAsync();

        public Task<GradeDetailsModel> FindById(Guid id) => AllGradeDetails.SingleOrDefaultAsync(g => g.Id == id);

        public Task<GradeDetailsModel> FindByStudentId(Guid id) => AllGradeDetails.SingleOrDefaultAsync(g => g.ExamId == id);

        public Task<GradeDetailsModel> FindByExamId(Guid id) => AllGradeDetails.SingleOrDefaultAsync(g => g.StudentId == id);
        
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
                await repository.SaveAsync();
                await repository.RemoveAsync<Grade>(grade);
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
              Nota = g.Nota,
              ExamId = g.ExamId,
              StudentId = g.StudentId
          });
        
    }
}