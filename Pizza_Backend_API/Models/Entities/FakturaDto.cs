namespace PizzeriaAPI.Models.Entities;

public class FakturaDto
{
    public int FakturaID { get; set; }
    public int ZamówienieID { get; set; }
    public DateTime DataWystawienia { get; set; }
    public string WystawionaNa { get; set; }
    public string OpisDotyczy { get; set; }
    public decimal? KwotaNetto { get; set; }
    public decimal? VAT { get; set; }
    public decimal? KwotaBrutto { get; set; }
}