using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.Business
{
    public interface IGradeService
    {
        Task<List<GradeDetailsModel>> GetAll();

        Task<GradeDetailsModel> FindById(Guid id);

        Task<Guid> CreateNew(CreatingGradeModel newGrade);

        Task<bool> Update(Guid id, Domain.Grade examModel);

        Task<bool> Delete(Guid id);
    }
}
