using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain
{
    public class Exam : Entity
    {
        public string Type { get; set; }

        public DateTime Date { get; set; }

        public Guid CourseId { get; set; }

        public Course Course { get; set; }

        public Guid ProfessorId { get; set; }

        public Professor Professor { get; set; }

        public static Exam Create(string type, DateTime date, Guid courseId, Guid professorId) => new Exam
         {
             Type      = type,
             Date      = date,
             CourseId    = courseId,
             ProfessorId = professorId,

         };

    }
}
