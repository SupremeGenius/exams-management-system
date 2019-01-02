using System.ComponentModel.DataAnnotations;

namespace EMS.Business
{
    public class UpdateCourseModel
    {
        [MaxLength(20)]
        public string Title { get; set; }

        [MaxLength(10)]
        public string UniversityYear { get; set; }

        public int StudentYear { get; set; }

        public int Semester { get; set; }
    }
}
