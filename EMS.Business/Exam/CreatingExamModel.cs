using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain;
using EMS.Domain.Entities;

namespace EMS.Business
{
    public class CreatingExamModel
    {
        [Required]
        [MaxLength(10)]
        public string Type { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public Guid CourseId { get; set; }

        public Guid ProfessorId { get; set; }
    }
}
