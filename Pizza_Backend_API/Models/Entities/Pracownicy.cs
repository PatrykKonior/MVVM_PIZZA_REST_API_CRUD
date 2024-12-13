using System;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaAPI.Models.Entities
{
    public class Pracownicy
    {
        [Key]
        public int PracownikID { get; set; }
        public string Imię { get; set; }
        public string Nazwisko { get; set; }
        public string Stanowisko { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public DateTime DataZatrudnienia { get; set; }
        public decimal Wynagrodzenie { get; set; }
    }
}