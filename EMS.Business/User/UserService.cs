using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public Task<List<UserDetailsModel>> GetAll() => GetAllUserDetails().ToListAsync();

        public Task<UserDetailsModel> FindByEmail(string email)
        {
            return GetAllUserDetails().SingleOrDefaultAsync(s => s.Email == email);
        }

        private IQueryable<UserDetailsModel> GetAllUserDetails() => this.repository.GetAll<User>()
            .Select(c => new UserDetailsModel
            {
                Id = c.Id,
                Email = c.Email,
                Password = c.Password
            });
    }
}
