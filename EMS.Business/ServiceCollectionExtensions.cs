using EMS.Business;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Business
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IExamService, ExamService>();
            services.AddTransient<ICourseService, CourseService>();

            return services;
        }
    }
}
