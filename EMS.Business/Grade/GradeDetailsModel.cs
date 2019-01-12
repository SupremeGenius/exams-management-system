using System;

namespace EMS.Business
{
    public class GradeDetailsModel
    {
        public float Nota { get; set; }

        public Guid ExamId { get; set; }

        public Guid StudentId { get; set; }

        public Guid Id { get; internal set; }
    }
}
