using System.ComponentModel.DataAnnotations;

namespace PizzeriaAPI.Models.Entities
{
    public class Dostawcy
    {
        [Key] 
        public int DostawcaID { get; set; }
        public string Nazwa { get; set; }
        public string KontaktEmail { get; set; }
        public string KontaktTelefon { get; set; }
        public string Adres { get; set; }
        public string Miasto { get; set; }
        public string KodPocztowy { get; set; }
        public string Kraj { get; set; }
    }
}