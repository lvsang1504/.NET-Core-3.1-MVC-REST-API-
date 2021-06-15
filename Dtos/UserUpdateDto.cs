using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos 
{
    public class UserUpdateDto
    {
        [Required]
        [MaxLength(10)]
        public string IdStudent { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Class { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}