using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EMS.Business
{
    public class UpdateGradeModel
    {
        [Required]
        public float Nota { get; set; }

        public Guid ExamId { get; set; }

        public Guid StudentId { get; set; }
    }
}
