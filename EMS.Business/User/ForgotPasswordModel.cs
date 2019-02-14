using System.ComponentModel.DataAnnotations;

namespace EMS.Business
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
