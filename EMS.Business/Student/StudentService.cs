using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EMS.Domain.Entities;
using EMS.Domain;

namespace EMS.Business
{
  public sealed class StudentService : IStudentService
    {
        private readonly IRepository repository;

        public StudentService(IRepository repository) => this.repository = repository;

        public async Task<Guid> CreateNew(Guid userId)
        {
            User studentUser = await repository.FindByIdAsync<User>(userId);

            var student = Student.Create(
                userId: userId
                );

            await this.repository.AddNewAsync(student);
            await this.repository.SaveAsync();

            return student.Id;
        }

        public Task<List<StudentDetailsModel>> GetAll() => AllStudentDetails.ToListAsync();

        public Task<StudentDetailsModel> FindById(Guid id) => AllStudentDetails.SingleOrDefaultAsync(s => s.User.Id == id);

        private IQueryable<StudentDetailsModel> AllStudentDetails => this.repository.GetAll<Student>()
            .Select(c => new StudentDetailsModel
            {
                User = c.User,
                FatherInitial = c.FatherInitial
            });
    }
}
