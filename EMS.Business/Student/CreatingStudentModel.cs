using System.ComponentModel.DataAnnotations;
using System;

namespace EMS.Business
{
    public class CreatingStudentModel
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        [MaxLength(1)]
        public string FatherInitial { get; set; }
    }
}
