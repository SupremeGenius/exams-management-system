using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EMS.Domain;
using EMS.Domain.Entities;

namespace EMS.Business
{
    public sealed class ProfessorService : IProfessorService
    {
        private readonly IRepository repository;

        public ProfessorService(IRepository repository) => this.repository = repository;

        public async Task<Guid> CreateNew(ProfessorDetailsModel newProfessor)
        {
            var professor = Professor.Create(
                userId: newProfessor.UserId//,
                //title: newProfessor.Title,
                //courseProfessors: newProfessor.CourseProfessors,
                //exams: newProfessor.Exams
                );

            await this.repository.AddNewAsync(professor);
            await this.repository.SaveAsync();

            return professor.Id;
        }

        public async Task<bool> UpdateAsync(Guid id, Professor professorUpdated)
        {
            var professorToUpdate = await this.repository.FindByIdAsync<Professor>(id);

            if (await repository.TryUpdateModelAsync<Professor>(
                professorToUpdate,
                professorUpdated
            ))
            {
                await repository.SaveAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(Guid id)
        {
            var professor = await this.repository.FindByIdAsync<Professor>(id);
            var user = await this.repository.FindByIdAsync<User>(professor.UserId);

            await repository.RemoveAsync<Professor>(professor);
            await repository.RemoveAsync<User>(user);
            await repository.SaveAsync();
            return true;
        }

        public Task<List<ProfessorDetailsModel>> GetAll() => GetAllProfessorDetails().ToListAsync();

        public Task<ProfessorDetailsModel> FindByTitle(string title) => GetAllProfessorDetails().SingleOrDefaultAsync(p => p.Title == title);

        public Task<ProfessorDetailsModel> FindById(Guid id) => GetAllProfessorDetails().SingleOrDefaultAsync(p => p.Id == id);


        private IQueryable<ProfessorDetailsModel> GetAllProfessorDetails() => this.repository.GetAll<Professor>()
            .Select(p => new ProfessorDetailsModel
            {
                Id = p.Id,
                //User = p.User,
                UserId = p.UserId, 
                Title = p.Title,
                CourseProfessors = p.CourseProfessors,
                Exams = p.Exams

            });
    }
}
