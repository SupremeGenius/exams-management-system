using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public class Student : User
    {
        public string FatherInitial { get; set; }

        private List<Course> Courses { get; set; }

        private List<Exam> Exams { get; set; }
    }
}
