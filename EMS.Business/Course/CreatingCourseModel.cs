using EMS.Domain;
using EMS.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMS.Business
{
    public class CreatingCourseModel
    {
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        [MaxLength(50)]
        public List<CourseProfessor> CourseProfessors { get; set; }

        [Required]
        [MaxLength(50)]
        public List<Exam> Exams { get; set; }

        [Required]
        [MaxLength(10)]
        public string UniversityYear { get; set; }

        [Required]
        [MaxLength(10)]
        public int StudentYear { get; set; }

        [Required]
        [MaxLength(10)]
        public int Semester { get; set; }
    }
}
