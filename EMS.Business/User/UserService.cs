using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EMS.Domain;

namespace EMS.Business
{
  public sealed class UserService : IUserService
    {
        private readonly IRepository repository;

        public UserService(IRepository repository) => this.repository = repository;

        public async Task<Guid> CreateNew(CreatingUserModel newUser)
        {
            var user = User.Create(
                email: newUser.Email,
                password: newUser.Password,
                role: newUser.Role);

            await this.repository.AddNewAsync(user);
            await this.repository.SaveAsync();

            return user.Id;
        }

        public async Task<bool> UpdateAsync(Guid id, User userUpdated, string oldPassword = null)
        {
            var userToUpdate = await this.repository.FindByIdAsync<User>(id);
            var userCopy = userToUpdate;

            if (oldPassword != null && oldPassword != userToUpdate.Password)
            {
                return false; //wrong password
            }

            if (await repository.TryUpdateModelAsync<User>(
                    userToUpdate,
                    userUpdated
                    ))
            {
                if (userToUpdate == userCopy)
                    return false; //nothing has changed
                await repository.SaveAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(Guid id)
        {
            var user = await this.repository.FindByIdAsync<User>(id);

            await repository.RemoveAsync<User>(user);
            await repository.SaveAsync();
            return true;
        }

        public Task<List<UserDetailsModel>> GetAll() => AllUserDetails.ToListAsync();

        public Task<UserDetailsModel> FindByEmail(string email) => AllUserDetails.SingleOrDefaultAsync(s => s.Email == email);

        public Task<UserDetailsModel> FindById(Guid id) => AllUserDetails.SingleOrDefaultAsync(s => s.Id == id);

        private IQueryable<UserDetailsModel> AllUserDetails => this.repository.GetAll<User>()
            .Select(c => new UserDetailsModel
            {
                Id = c.Id,
                Email = c.Email,
                Password = c.Password,
                Role = c.Role
            });
    }
}
