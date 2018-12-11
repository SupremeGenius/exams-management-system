using System;
using System.Linq;
using System.Threading.Tasks;
using EMS.Domain;
using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EMS.Persistence
{
    public sealed class EMSContext : DbContext, IRepository
    {
        public EMSContext(DbContextOptions<EMSContext> options)
            : base(options) => Database.Migrate();

        internal DbSet<User> Users { get; private set; }
        internal DbSet<Student> Students { get; private set; }
        internal DbSet<Professor> Professors { get; private set; }

        public IQueryable<TEntity> GetAll<TEntity>()
            where TEntity : Entity => Set<TEntity>().AsNoTracking();

        public async Task<TEntity> FindByIdAsync<TEntity>(Guid id)
            where TEntity : Entity =>
            // here we don't await for the response, we just return the task from SingleOrDefault.
            // and, that task is going to be awaited later where is needed.
            await Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id);

        public async Task AddNewAsync<TEntity>(TEntity entity)
            where TEntity : Entity => await Set<TEntity>().AddAsync(entity);

        public async Task SaveAsync() => await SaveChangesAsync();
    }
}
