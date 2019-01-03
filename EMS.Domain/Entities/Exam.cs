using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain
{
    public class Exam : Entity, IUpdatable<Exam>
    {
        public string Type { get; set; }

        public DateTime Date { get; set; }

        public Guid CourseId { get; set; }

        public Guid ProfessorId { get; set; }

        public static Exam Create(string type, DateTime date, Guid courseId, Guid professorId) => new Exam
        {
             Type      = type,
             Date      = date,
             CourseId    = courseId,
             ProfessorId = professorId,
        };

        public void Update(Exam updatedEntity)
        {
            Type = updatedEntity.Type == null ? Type : updatedEntity.Type;
            Date = updatedEntity.Date == null ? Date : updatedEntity.Date;
            CourseId = updatedEntity.CourseId == null ? CourseId : updatedEntity.CourseId;
            ProfessorId = updatedEntity.ProfessorId == null ? ProfessorId : updatedEntity.ProfessorId;
        }
  }
}
