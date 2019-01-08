using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public class Professor : Entity, IUpdatable<Professor>
    {
        public User User { get; private set; } //this is for code-first approach

        public Guid UserId { get; private set; }

        public string Title { get; private set; }

        public List<CourseProfessor> CourseProfessors { get; private set; }

        public List<Exam> Exams { get; private set; }

        public static Professor Create(Guid userId) => new Professor
        {
            UserId = userId,
        };

        public void Update(Professor updatedProfessor)
        {
            this.Title = updatedProfessor.Title;
        }
    }
}
