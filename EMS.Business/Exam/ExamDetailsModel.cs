using System;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.Domain;
using EMS.Domain.Entities;

namespace EMS.Business
{
    public class ExamDetailsModel
    {
        public string Type { get; set; }

        public DateTime Date { get; set; }
      
        public Guid CourseId { get; set; }

        public Guid ProfessorId { get; set; }

        public Guid Id { get; internal set; }
  }
}
