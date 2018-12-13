using System;
using EMS.Domain;
using EMS.Domain.Entities;

namespace EMS.Business
{
    public class ExamDetailsModel
    {
        public string Type { get; set; }

        public DateTime Date { get; set; }

        public Course Course { get; set; }

        public Professor Professor { get; set; }
        
        public Guid Id { get; internal set; }
  }
}
