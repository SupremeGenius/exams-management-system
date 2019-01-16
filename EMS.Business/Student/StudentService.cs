using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EMS.Domain.Entities;
using EMS.Domain;
using Newtonsoft.Json.Linq;

namespace EMS.Business
{
        public sealed class StudentService : IStudentService
        {
            private readonly IRepository repository;

            public StudentService(IRepository repository) => this.repository = repository;

            public async Task<Guid> CreateNew(Guid userId,string json)
            {
                JObject response = JObject.Parse(json);
                string email = response["response"]["Email"].ToString();
                string rNumber = response["response"]["NrMatricol"].ToString();
                string group = response["response"]["Grupa"].ToString();
                string fInitial = response["response"]["FatherInitial"].ToString();
                var student = Student.Create(
                    userId: userId,
                    fInitial: fInitial,
                    group: group,
                    rnumber: rNumber
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