using EMS.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.Persistence
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<EMSContext>(opt => opt.UseSqlServer(connectionString));
            services.AddScoped<IRepository>(provider => provider.GetService<EMSContext>());

            return services;
        }
    }
}
