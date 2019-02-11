using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public class StudentCourse
    {
        public Guid StudentId { get; private set; }

        public Student Student { get; private set; }

        public Guid CourseId { get; private set; }

        public Course Course { get; private set; }

        public StudentCourse()
        {

        }

        public StudentCourse(Student student, Course course)
        {
            StudentId = student.Id;
            Student = student;
            CourseId = course.Id;
            Course = course;
        }

    }
}
