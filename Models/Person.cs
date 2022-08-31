using System.ComponentModel.DataAnnotations;

namespace PersonService.Models
{
    public class Person
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public uint Age { get; set; }

        [Required]
        public string Mail { get; set; }

        [Required]
        public string Password { get; set; }


        [Required]
        public string wilaya { get; set; }

 

    }
}