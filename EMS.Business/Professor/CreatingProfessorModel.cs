using System.ComponentModel.DataAnnotations;

namespace EMS.Business
{
    public class CreatingProfessorModel
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

    }
}
