using System;
using System.ComponentModel.DataAnnotations;

namespace Commander.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(int.MaxValue)]
        public string Content { get; set; }

        [Required]
        [MaxLength(int.MaxValue)]
        public string IdStudent { get; set; }

        [Required]
        [MaxLength(int.MaxValue)]
        public string Image { get; set; }

        [Required]
        public DateTime TimeCreated { get; set; }

        [Required]
        public bool isRead { get; set; }

        [Required]
        public bool isDelete { get; set; }

    }
}