using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.Business
{
    public interface IProfessorService
    {
        Task<List<ProfessorDetailsModel>> GetAll();

        Task<ProfessorDetailsModel> FindByTitle(String Title);

        Task<ProfessorDetailsModel> FindById(Guid id);

        Task<Guid> CreateNew(ProfessorDetailsModel newProfessor);

        void Update(Guid id);

        void Delete(Guid id);
    }
}
