using System.ComponentModel.DataAnnotations;


namespace EMS.Business
{
    public class UpdateUserModel
    {
        [Required]
        [MaxLength(50)]
        public string OldPassword { get; set; }

        [Required]
        [MaxLength(50)]
        public string NewPassword { get; set; }
    }
}
