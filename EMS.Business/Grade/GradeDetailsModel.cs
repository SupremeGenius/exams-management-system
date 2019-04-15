using System;

namespace EMS.Business
{
    public class GradeDetailsModel
    {
        public float Value { get; set; }

        public string ExamName { get; set; }

        public Guid StudentId { get; set; }

        public Guid Id { get; internal set; }
    }
}