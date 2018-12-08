using System.ComponentModel.DataAnnotations;

namespace EMS.Business
{
    public class CreatingStudentModel
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
