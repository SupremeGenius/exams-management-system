using EMS.Domain.Entities;
using System.Collections.Generic;

namespace EMS.Domain
{
    public class Course : Entity
    {
        public string Title { get; set; }

        public List<CourseProfessor> CourseProfessors { get; set; }

        public List<Exam> Exams { get; set; }

        public string UniversityYear { get; set; }

        public int StudentYear { get; set; }

        public int Semester { get; set; }

        public static Course Create(string title, List<CourseProfessor> courseProfessors, string universityYear, int studentYear, int semester) => new Course
        {
            Title = title,
            CourseProfessors = courseProfessors,
            UniversityYear = universityYear,
            StudentYear = studentYear,
            Semester = semester
        };
    }
}
