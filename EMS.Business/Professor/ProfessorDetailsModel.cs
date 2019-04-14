using EMS.Domain;
using System;
using System.Collections.Generic;

namespace EMS.Business
{
    public class ProfessorDetailsModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Title { get; set; }

        public List<ExamDetailsModel> Exams { get; set; }

        public CourseDetailsModel Course { get; internal set; }
    }
}
