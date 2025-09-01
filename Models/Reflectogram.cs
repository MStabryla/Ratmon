using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ratmon.Models;

public class Reflectogram
{
    [Key]
    public int Id { get; set; }

    [Required]
    public UInt16 SeriesNumber { get; set; }

    [Required]
    public required byte[] Bytes { get; set; }
    
}
