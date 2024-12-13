using System;
using System.ComponentModel.DataAnnotations;


namespace PizzeriaAPI.Models.Entities
{
    public class Kontakt
    {
        [Key]
        public int KontaktID { get; set; }
        public string Imię { get; set; }
        public string Email { get; set; }
        public string NumerTelefonu { get; set; }
        public string Wiadomość { get; set; }
        public DateTime DataDodania { get; set; }
    }
}