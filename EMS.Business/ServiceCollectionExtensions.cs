using AutoMapper;
using EMS.Business;
using EMS.Domain;
using EMS.Domain.Entities;
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
            services.AddTransient<IProfessorService, ProfessorService>();
            services.AddTransient<IStudentService, StudentService>();

            return services;
        }

        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UpdateUserModel, User>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.NewPassword));
                cfg.CreateMap<UpdateCourseModel, Course>();
                cfg.CreateMap<UpdateExamModel, Exam>();
                cfg.CreateMap<UpdateProfessorModel, Professor>();
                cfg.CreateMap<UpdateStudentModel, Student>();
            });
            return services;
        }
    }
}
