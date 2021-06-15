using System;

namespace Commander.Dtos
{
    public class TopicReadDto
    {
        public int Id { get; set; }

        public string TopicCode { get; set; }

        public string Name { get; set; }

        public string Field { get; set; }

        public string Content { get; set; }

        public string Image { get; set; }

        public string Type { get; set; }
        public int Budget { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime AcceptanceTime { get; set; }

        public string Note { get; set; }
    }
}