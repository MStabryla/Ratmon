using System.ComponentModel.DataAnnotations;

namespace Ratmon.Models;

public class Mouse2B
{
    [Key]
    public int Id { get; set; }
    //Napięcie przewodu
    public double V { get; set; }

    //Rezystancja przewodu
    public double Ω { get; set; }

    //Lokalizacja wycieku
    public float LeakLocation { get; set; }
}
