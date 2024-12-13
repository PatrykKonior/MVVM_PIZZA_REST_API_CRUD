using System;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaAPI.Models.Entities
{
    public class Zamówienia
    {
        [Key]
        public int ZamówienieID { get; set; }
        public int UżytkownikID { get; set; }
        public DateTime DataZamówienia { get; set; }
        public string Status { get; set; }
        public decimal KwotaCałkowita { get; set; }
    }
}