using System;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaAPI.Models.Entities
{
    public class Towary
    {
        [Key]
        public int TowarID { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public decimal? CenaZakupu { get; set; }
        public decimal? CenaSprzedaży { get; set; }
        public DateTime DataDodania { get; set; }
    }
}