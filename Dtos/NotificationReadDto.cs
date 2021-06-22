using System;

namespace Commander.Dtos
{
    public class NotificationReadDto
    {

        public int Id { get; set; }
        public string Content { get; set; }

        public string IdStudent { get; set; }

        public string Image { get; set; }


        public DateTime TimeCreated { get; set; }

        public bool isRead { get; set; }

        public bool isDelete { get; set; }

    }
}