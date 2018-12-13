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
            type     : newExam.Type,
            date     : newExam.Date,
            course   : newExam.Course,
            professor: newExam.Professor);

        await this.repository.AddNewAsync(exam);
        await this.repository.SaveAsync();
        
        return exam.Id;
    }

    public Task<ExamDetailsModel> FindById(Guid Id) => AllExamDetails.SingleOrDefaultAsync(e => e.Id == Id);

    public Task<List<ExamDetailsModel>> GetAll() => AllExamDetails.ToListAsync();

    private IQueryable<ExamDetailsModel> AllExamDetails => this.repository.GetAll<Exam>()
      .Select(e => new ExamDetailsModel
      {
        Id        = e.Id,
        Type      = e.Type,
        Date      = e.Date,
        Course    = e.Course,
        Professor = e.Professor
      });
  }
}