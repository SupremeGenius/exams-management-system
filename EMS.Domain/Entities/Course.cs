using EMS.Domain.Entities;
using System.Collections.Generic;

namespace EMS.Domain
{
    public class Course : Entity, IUpdatable<Course>
    {
        public string Title { get; private set; }

        public List<CourseProfessor> CourseProfessors { get; private set; }

        public List<Exam> Exams { get; private set; }

        public string UniversityYear { get; private set; }

        public int StudentYear { get; private set; }

        public int Semester { get; private set; }

        public static Course Create(string title, string universityYear, int studentYear, int semester) => new Course
        {
            Title = title,
            UniversityYear = universityYear,
            StudentYear = studentYear,
            Semester = semester
        };

        public void Update(Course updatedEntity)
        {
            Title = updatedEntity.Title == null ? Title : updatedEntity.Title;
            UniversityYear = updatedEntity.UniversityYear == null ? UniversityYear : updatedEntity.UniversityYear;
            StudentYear = updatedEntity.StudentYear == 0 ? StudentYear : updatedEntity.StudentYear;
            Semester = updatedEntity.Semester == 0 ? Semester : updatedEntity.Semester;
        }
    }
}
