using System.ComponentModel.DataAnnotations;

namespace EMS.Business
{
    public class UpdateStudentModel
    {
        [Required]
        [MaxLength(2)]
        public string FatherInitial { get; set; }
    }
}