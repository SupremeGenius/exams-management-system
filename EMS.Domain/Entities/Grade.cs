using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public class Grade : Entity
    {
        public float Nota { get; private set; }

        public Exam Exam { get; private set; } // this is for code-first approach

        public Guid ExamId { get; private set; }

        public Student Student { get; private set; } // this is for code-first approach

        public Guid StudentId { get; private set; }
    }
}
