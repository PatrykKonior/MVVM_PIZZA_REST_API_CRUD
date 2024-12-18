using System.ComponentModel.DataAnnotations;

namespace PizzeriaAPI.Models.Entities
{
    public class Opinie
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Opinia { get; set; }

        [Required]
        [MaxLength(255)]
        public string Klient { get; set; }
    }
}