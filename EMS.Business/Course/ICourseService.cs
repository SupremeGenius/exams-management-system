using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.Business
{
    public interface ICourseService
    {
       Task<List<CourseDetailsModel>> GetAll();

       Task<CourseDetailsModel> FindByTitle(String Title);

        Task<Guid> CreateNew(CreatingCourseModel newCourse);
    }
}
