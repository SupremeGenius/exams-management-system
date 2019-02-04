﻿using System;

namespace EMS.Business
{
    public class ExamDetailsModel
    {
        public string Type { get; set; }

        public string CourseName { get; set; }

        public DateTime Date { get; set; }
      
        public Guid CourseId { get; set; }

        public Guid ProfessorId { get; set; }

        public string Room { get; set; }

        public Guid Id { get; internal set; }
  }
}
