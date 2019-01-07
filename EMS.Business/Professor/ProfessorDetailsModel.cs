using EMS.Domain;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EMS.Business
{
    public class ProfessorDetailsModel
    {
        public Guid Id { get; set; }

        public User User { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public List<CourseProfessor> CourseProfessors { get; set; }

        public List<Exam> Exams { get; set; }
    }
}
