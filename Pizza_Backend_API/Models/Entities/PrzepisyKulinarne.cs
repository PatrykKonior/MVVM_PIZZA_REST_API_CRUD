using System.ComponentModel.DataAnnotations;

namespace PizzeriaAPI.Models.Entities
{
    public class PrzepisyKulinarne
    {
        [Key]
        public int PrzepisID { get; set; }
        public string NazwaPrzepisu { get; set; }
        public string Składniki { get; set; }
        public string InstrukcjaPrzygotowania { get; set; }
        public int CzasPrzygotowania { get; set; } // w minutach
    }
}