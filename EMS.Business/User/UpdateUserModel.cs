using System.ComponentModel.DataAnnotations;


namespace EMS.Business
{
    public class UpdateUserModel
    {
        [MaxLength(50)]
        public string OldPassword { get; set; }

        [MaxLength(50)]
        public string NewPassword { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
    }
}
