using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.Business
{
  public interface IExamService
    {
        Task<List<ExamDetailsModel>> GetAll();

        Task<ExamDetailsModel> FindById(Guid Id);

        Task<Guid> CreateNew(CreatingExamModel newExam);
    }
}
