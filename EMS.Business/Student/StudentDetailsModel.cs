using EMS.Domain;
using System.ComponentModel.DataAnnotations;

namespace EMS.Business
{
    public class StudentDetailsModel
    {
        [Required]
        public User User { get; set; }

        [Required]
        [MaxLength(1)]
        public string FatherInitial { get; set; }
    }
}
