using System;
using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class TopicCreateDto
    {
        [Required]
        [MaxLength(int.MaxValue)]
        public string TopicCode { get; set; }

        [Required]
        [MaxLength(int.MaxValue)]
        public string Name { get; set; }

        [Required]
        [MaxLength(int.MaxValue)]
        public string Field { get; set; }

        [Required]
        [MaxLength(int.MaxValue)]
        public string Content { get; set; }

        [Required]
        [MaxLength(int.MaxValue)]
        public string Image { get; set; }

        [Required]
        [MaxLength(int.MaxValue)]
        public string Type { get; set; }

        [Required]
        public int Budget { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public DateTime AcceptanceTime { get; set; }

        [MaxLength(int.MaxValue)]
        public string Note { get; set; }
    }
}