using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Ratmon.Models;

public class Mas2
{
    [Key]
    public int Id { get; set; }
    //Temperatura
    public double C { get; set; }

    //Wilgotność
    public float Humidity { get; set; }
}
