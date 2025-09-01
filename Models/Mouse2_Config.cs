using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Ratmon.Models;

public class Mouse2_Config
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }
    
    [DefaultValue(0)]
    public float Threshold { get; set; }
}
