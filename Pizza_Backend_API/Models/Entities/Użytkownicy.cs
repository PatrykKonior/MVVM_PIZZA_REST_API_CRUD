using System.ComponentModel.DataAnnotations;

namespace PizzeriaAPI.Models.Entities
{
    public class Użytkownicy
    {
        [Key]
        public int UżytkownikID { get; set; }
        public string Imię { get; set; }
        public string Nazwisko { get; set; }
        public string Login { get; set; }
        public string HasłoHash { get; set; }
        public string Email { get; set; }
        public string PoziomDostępu { get; set; }
        public DateTime DataRejestracji { get; set; }
    }
}