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
                var student = Student.Create(
                    userId: userId
                    );

                await this.repository.AddNewAsync(student);
                await this.repository.SaveAsync();

                return student.Id;
            }

        public async Task<bool> UpdateAsync(Guid id, Student studentUpdated)
        {
            var studentToUpdate = await this.repository.FindByIdAsync<Student>(id);

            if (await repository.TryUpdateModelAsync<Student>(
                    studentToUpdate, studentUpdated))
            {
                await repository.SaveAsync();
                return true;
            }

            return false;
        }

        public Task<List<StudentDetailsModel>> GetAll() => GetAllStudentDetails().ToListAsync();

            public Task<StudentDetailsModel> FindById(Guid id) => GetAllStudentDetails().SingleOrDefaultAsync(p => p.Id == id);


            private IQueryable<StudentDetailsModel> GetAllStudentDetails() => this.repository.GetAll<Student>()
                    .Select(c => new StudentDetailsModel
                    {
                        Id = c.Id,
                        UserId = c.UserId,
                        FatherInitial = c.FatherInitial,
                        Name = c.Name,
                        Group = c.Group,
                        RegistrationNumber = c.RegistrationNumber,
                    });
        }
}