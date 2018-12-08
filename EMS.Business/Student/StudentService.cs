using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EMS.Domain;

namespace EMS.Business
{
    public sealed class StudentService : IStudentService
    {
        private readonly IRepository repository;

        public StudentService(IRepository repository) => this.repository = repository;

        public async Task<Guid> CreateNew(CreatingStudentModel newStudent)
        {
            var student = Student.Create(
                firstName: newStudent.FirstName,
                lastName: newStudent.LastName,
                email: newStudent.Email);

            await this.repository.AddNewAsync(student);
            await this.repository.SaveAsync();

            return student.Id;
        }

        public Task<List<StudentDetailsModel>> GetAll() => GetAllStudentsDetails().ToListAsync();

        public Task<StudentDetailsModel> FindById(Guid id)
        {
            return GetAllStudentsDetails().SingleOrDefaultAsync(s => s.Id == id);
        }

        private IQueryable<StudentDetailsModel> GetAllStudentsDetails() => this.repository.GetAll<Student>()
            .Select(c => new StudentDetailsModel
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
            });
    }
}
