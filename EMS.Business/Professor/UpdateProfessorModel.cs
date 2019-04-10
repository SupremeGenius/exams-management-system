using System.ComponentModel.DataAnnotations;

namespace EMS.Business
{
    public class UpdateProfessorModel
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

    }
}
