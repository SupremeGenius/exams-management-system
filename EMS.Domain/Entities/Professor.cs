using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public class Professor : Entity
    {
        public User User { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public List<CourseProfessor> CourseProfessors { get; set; }

        public List<Exam> Exams { get; set; }

        public static Professor Create(Guid userId, string name, string title, List<CourseProfessor> courseProfessors, List<Exam> exams) => new Professor
        {
            UserId = userId,
            Name = name,
            Title = title,
            CourseProfessors = courseProfessors,
            Exams = exams
        };
    }
}
