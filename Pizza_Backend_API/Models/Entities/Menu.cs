using System.ComponentModel.DataAnnotations;

namespace PizzeriaAPI.Models.Entities
{
    public class Menu
    {
        [Key]
        public int MenuID { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public string Składniki { get; set; }
        public decimal Cena { get; set; }
        public bool Dostępność { get; set; }
    }
}