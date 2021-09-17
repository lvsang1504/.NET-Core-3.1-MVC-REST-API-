using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class Register
    {
        [Key]
        public int Id { get; set; }
        public int IdTopic { get; set; }

        [MaxLength(255)]
        public string IdStudent { get; set; }

        [Required]
        public int Role { get; set; }
        [Required]
        public int BrowseTopic { get; set; }
    }
}