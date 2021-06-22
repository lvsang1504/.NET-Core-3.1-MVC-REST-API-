using System;
using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class NotificationUpdateDto
    {

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