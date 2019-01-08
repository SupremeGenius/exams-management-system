﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public class Student : Entity
    {
        public User user { get; set; } //this is for code-first approach

        public Guid UserId { get; set; }
            
        public string FatherInitial { get; set; }

        private List<Course> Courses { get; set; }

        private List<Exam> Exams { get; set; }
    }
}
