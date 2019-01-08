using AutoMapper;
using EMS.Business;
using EMS.Domain;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EMS.Tests
{
    public class EMSFixture : IDisposable
    {
        public EMSFixture()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UpdateCourseModel, Course>();
                cfg.CreateMap<CreatingProfessorModel, Professor>();
                cfg.CreateMap<UpdateUserModel, User>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.NewPassword));
            });
        }
        public void Dispose()
        {
            Mapper.Reset();
        }
    }

    [CollectionDefinition("EMS Collection")]
    public class DatabaseCollection : ICollectionFixture<EMSFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
