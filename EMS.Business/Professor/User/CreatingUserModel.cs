using System.ComponentModel.DataAnnotations;

namespace EMS.Business
{
    public class CreatingUserModel
    {
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [MaxLength(10)]
        public string Role { get; set; }

    }
}
