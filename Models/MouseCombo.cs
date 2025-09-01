using System.ComponentModel.DataAnnotations;

namespace Ratmon.Models;

public class MouseCombo
{
    [Key]
    public int Id { get; set; }
    //Napięcie przewodu
    public double V { get; set; }

    //Rezystancja przewodu
    public double Ω { get; set; }

    //Dane binarne Refrectograms
    public required List<Reflectogram> Reflectograms { get; set; }
}
