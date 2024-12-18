using System.ComponentModel.DataAnnotations;

namespace PizzeriaAPI.Models.Entities
{
    public class Magazyn
    {
        [Key]
        public int MagazynID { get; set; }
        public int TowarID { get; set; }
        public int Ilość { get; set; }
        public string Lokalizacja { get; set; }
        
        // Relacja do tabeli Towar
        public Towary? Towary { get; set; }
    }
}