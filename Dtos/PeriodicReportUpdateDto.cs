using System;
using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class PeriodicReportItemUpdateDto
    {

        [Required]
        [MaxLength(int.MaxValue)]
        public string TopicCode { get; set; }

        [Required]
        [MaxLength(int.MaxValue)]
        public string IdStudent { get; set; }

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
        public DateTime DateStarted { get; set; }

        [Required]
        public DateTime DateEnd { get; set; }

    }
}