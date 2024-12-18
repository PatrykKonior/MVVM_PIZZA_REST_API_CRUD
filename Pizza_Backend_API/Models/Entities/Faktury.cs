using System;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaAPI.Models.Entities
{
    public class Faktury
    {
        [Key]
        public int FakturaID { get; set; }
        public int ZamówienieID { get; set; }
        public DateTime DataWystawienia { get; set; }
        public string WystawionaNa { get; set; }
        public string OpisDotyczy { get; set; }
        public decimal? KwotaNetto { get; set; }
        public decimal? VAT { get; set; }
        public decimal? KwotaBrutto { get; set; }
        
        // Relacja do Zamówienia
        public Zamówienia? Zamówienie { get; set; }
    }
}