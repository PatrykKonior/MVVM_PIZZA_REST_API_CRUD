namespace PizzeriaAPI.Models.Entities;

public class MagazynDto
{
    public int MagazynID { get; set; }
    public int TowarID { get; set; }
    public string NazwaTowaru { get; set; }
    public string OpisTowaru { get; set; }
    public int Ilość { get; set; }
    public string Lokalizacja { get; set; }
}
