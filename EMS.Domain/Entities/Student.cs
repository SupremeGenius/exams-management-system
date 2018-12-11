using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public class Student : Entity
    {
        public User User { get; set; }
            
        public string FatherInitial { get; set; }

        private List<Course> Courses { get; set; }

        private List<Exam> Exams { get; set; }
    }
}
