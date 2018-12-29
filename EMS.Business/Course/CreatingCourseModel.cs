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
        [MaxLength(10)]
        public string UniversityYear { get; set; }

        [Required]
        public int StudentYear { get; set; }

        [Required]
        public int Semester { get; set; }
    }
}
