using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.Business
{
    public interface IUserService
    {
        Task<List<UserDetailsModel>> GetAll();

        Task<UserDetailsModel> FindByEmail(String email);

        Task<Guid> CreateNew(CreatingUserModel newUser);
    }
}
