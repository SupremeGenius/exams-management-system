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
        internal DbSet<Exam> Exams { get; private set; }
        internal DbSet<Course> Courses { get; private set; }

        public IQueryable<TEntity> GetAll<TEntity>()
            where TEntity : Entity => Set<TEntity>().AsNoTracking();

        public async Task<TEntity> FindByIdAsync<TEntity>(Guid id)
            where TEntity : Entity =>
            await Set<TEntity>().SingleOrDefaultAsync(e => e.Id == id);

        public async Task<bool> TryUpdateModelAsync<TEntity>(TEntity entityToUpdate, TEntity updatedEntity)
             where TEntity : IUpdatable<TEntity>
        {
                    entityToUpdate.Update(updatedEntity);
                    return true;
        }

        public async Task AddNewAsync<TEntity>(TEntity entity)
            where TEntity : Entity => await Set<TEntity>().AddAsync(entity);

        public async Task SaveAsync() => await SaveChangesAsync();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseProfessor>()
                .HasKey(cp => new { cp.CourseId, cp.ProfessorId });
            modelBuilder.Entity<CourseProfessor>()
                .HasOne(cp => cp.Course)
                .WithMany(c => c.CourseProfessors)
                .HasForeignKey(cp => cp.CourseId);
            modelBuilder.Entity<CourseProfessor>()
                .HasOne(cp => cp.Professor)
                .WithMany(p => p.CourseProfessors)
                .HasForeignKey(cp => cp.ProfessorId);
        }
    }
}
