using System;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public Course Course { get; set; }

        [Required]
        public Professor Professor { get; set; }
    }
}
