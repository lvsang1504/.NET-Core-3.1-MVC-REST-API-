using System;

namespace Commander.Dtos
{
    public class PeriodicReportItemReadDto
    {
        public int Id { get; set; }

        public string TopicCode { get; set; }

        public string IdStudent { get; set; }

        public string Field { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public DateTime DateStarted { get; set; }
        public DateTime DateEnd { get; set; }

    }
}