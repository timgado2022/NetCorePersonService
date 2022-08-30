using System.ComponentModel.DataAnnotations;

namespace PersonService.Dtos
{
    public class PersonCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Cost { get; set; }
    }
}