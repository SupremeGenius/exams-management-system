using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain
{
    public class Exam : Entity
    {
        public string Type { get; set; }

        public DateTime Date { get; set; }

        public Course Course { get; set; }

        public Professor Professor { get; set; }
    }
}
