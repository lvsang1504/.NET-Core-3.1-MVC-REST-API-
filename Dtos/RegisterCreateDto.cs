using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class RegisterCreateDto
    {
        public int IdTopic { get; set; }
        
        [MaxLength(255)]
        public string IdStudent { get; set; }

        [Required]
        public int Role { get; set; }

        [Required]
        public int BrowseTopic { get; set; }
    }
}