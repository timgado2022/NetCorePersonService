using System.ComponentModel.DataAnnotations;

namespace PersonService.Dtos
{
    public class PersonCreateDto
    {
        [Required]
        public string Name { get; set; }
 

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Mail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}