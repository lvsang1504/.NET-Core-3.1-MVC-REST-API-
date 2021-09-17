using System;
using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class RegisterReadDto
    {
        public int Id { get; set; }
        public int IdTopic { get; set; }
        public string IdStudent { get; set; }
        public int Role { get; set; }
        public int BrowseTopic { get; set; }
    }
}