using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain
{
    public class Grade : Entity, IUpdatable<Grade>
    {
        public float Nota { get; private set; }

        public Exam Exam { get; private set; } // this is for code-first approach

        public Guid ExamId { get; private set; }

        public Student Student { get; private set; } // this is for code-first approach

        public Guid StudentId { get; private set; }

        public static Grade Create(float nota, Guid examId, Guid studentId) => new Grade
        {
            Nota = nota,
            ExamId = examId,
            StudentId = studentId,
        };

        public void Update(Grade updatedEntity)
        {
            Nota = updatedEntity.Nota == null ? Nota : updatedEntity.Nota;
            ExamId = updatedEntity.ExamId == null ? ExamId : updatedEntity.ExamId;
            StudentId = updatedEntity.StudentId == null ? StudentId : updatedEntity.StudentId;
        }
    }
}
