using EMS.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.Business
{
    public interface ICourseService
    {
        Task<List<CourseDetailsModel>> GetAll();

        Task<CourseDetailsModel> FindByTitle(String Title);

        Task<CourseDetailsModel> FindById(Guid id);

        Task<Guid> CreateNew(CreatingCourseModel newCourse);

        Task<bool> Update(Guid id, Course updatedCourse);

        Task<bool> Delete(Guid id);
    }
}
