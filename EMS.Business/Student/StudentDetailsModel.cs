using EMS.Domain;
using System;
using System.Collections.Generic;

namespace EMS.Business
{
    public class StudentDetailsModel
    {
        public Guid Id { get; set; } //this is for code-first approach

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Group { get; set; }

        public string RegistrationNumber { get; set; }

        public string FatherInitial { get; set; }

        public List<Course> Courses { get; set; }

        public List<Exam> Exams { get; set; }
    }
}
