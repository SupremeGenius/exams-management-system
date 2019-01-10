using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain
{
    public class Exam : Entity, IUpdatable<Exam>
    {
        public string Type { get; private set; }

        public DateTime Date { get; private set; }

        public Course Course { get; private set; } //this is for code-first approach

        public Guid CourseId { get; private set; }

        public Professor Professor { get; private set; } //this is for code-first approach

        public Guid ProfessorId { get; private set; }

        public string Room { get; private set; }

        public List<StudentExam> StudentExams { get; private set; }

        public static Exam Create(string type, DateTime date, Guid courseId, Guid professorId, string room) => new Exam
        {
             Type      = type,
             Date      = date,
             CourseId    = courseId,
             ProfessorId = professorId,
             Room = room,
        };

        public void Update(Exam updatedEntity)
        {
            Type = updatedEntity.Type == null ? Type : updatedEntity.Type;
            Date = updatedEntity.Date == null ? Date : updatedEntity.Date;
            CourseId = updatedEntity.CourseId == null ? CourseId : updatedEntity.CourseId;
            ProfessorId = updatedEntity.ProfessorId == null ? ProfessorId : updatedEntity.ProfessorId;
            Room = updatedEntity.Room == null ? Room : updatedEntity.Room;
        }
  }
}
