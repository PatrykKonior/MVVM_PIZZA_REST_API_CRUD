using System;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaAPI.Models.Entities
{
    public class ZamówieniaFirmowe
    {
        [Key]
        public int ZamówienieFirmoweID { get; set; }
        public int PracownikID { get; set; }
        public DateTime DataZamówienia { get; set; }
        public string Opis { get; set; }
        public string Status { get; set; } // np. Zakończone, W trakcie
    }
}