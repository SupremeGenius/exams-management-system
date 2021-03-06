﻿using System;
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

        public async Task<Guid> CreateNew(Guid userId)
        {
            var professor = Professor.Create(
                userId: userId
                );

            await repository.AddNewAsync(professor);
            await repository.SaveAsync();

            return professor.Id;
        }

        public async Task UpdateAsync(Guid id, Professor professorUpdated)
        {
            var professorToUpdate = await repository.FindByIdAsync<Professor>(id);

            await repository.TryUpdateModelAsync(
                professorToUpdate,
                professorUpdated
            );
            await repository.SaveAsync();
        }

        public Task<List<ProfessorDetailsModel>> GetAll() => GetAllProfessorDetails().ToListAsync();

        public Task<ProfessorDetailsModel> FindByTitle(string title) => GetAllProfessorDetails().SingleOrDefaultAsync(p => p.Title == title);

        public Task<ProfessorDetailsModel> FindById(Guid id) => GetAllProfessorDetails().SingleOrDefaultAsync(p => p.Id == id);


        private IQueryable<ProfessorDetailsModel> GetAllProfessorDetails() => repository.GetAll<Professor>()
            .Select(p => new ProfessorDetailsModel
            {
                Id = p.Id,
                UserId = p.UserId, 
                Title = p.Title,
                Name = p.Name
            });
    }
}
