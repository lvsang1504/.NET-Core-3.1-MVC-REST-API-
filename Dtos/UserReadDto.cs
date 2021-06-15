using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos 
{
    public class UserReadDto
    {
        public int Id { get; set; }

        public string IdStudent { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Class { get; set; }

        public string Phone { get; set; }
    }
}