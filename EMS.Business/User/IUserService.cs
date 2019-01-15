using EMS.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.Business
{
    public interface IUserService
    {
        Task<List<UserDetailsModel>> GetAll();

        Task<UserDetailsModel> FindByEmail(String Email);

        Task<UserDetailsModel> FindById(Guid id);

        Task<Guid> CreateNew(CreatingUserModel newUser);

        Task<bool> UpdateAsync(Guid id, User userUpdated, string oldPassword = null);

        Task<bool> Delete(Guid id);
    }
}
