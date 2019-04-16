using System;

namespace EMS.Business
{
    public class GradeDetailsModel
    {
        public float Value { get; set; }

        public string ExamName { get; set; }

        public string StudentName { get; set; }

        public Guid Id { get; internal set; }
    }
}