using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public class Student : Entity, IUpdatable<Student>
    {
        public User User { get; private set; } //this is for code-first approach

        public Guid UserId { get; private set; }

        public string Name { get; private set; }

        public string RegistrationNumber { get; private set; }

        public string FatherInitial { get; private set; }

        public string Group { get; private set; }

        public List<StudentCourse> StudentCourses { get; private set; }

        public List<StudentExam> StudentExams { get; private set; }

        public static Student Create (Guid userId) => new Student
        {
            UserId = userId
        };

        public void Update(Student updatedEntity)
        {
            this.FatherInitial = String.Copy(updatedEntity.FatherInitial);
            this.Name = String.Copy(updatedEntity.Name);
            this.Group = String.Copy(updatedEntity.Group);
            this.RegistrationNumber = String.Copy(updatedEntity.RegistrationNumber);
        }
    }
}
