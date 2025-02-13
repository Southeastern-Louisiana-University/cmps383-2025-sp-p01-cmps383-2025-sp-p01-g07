using System.ComponentModel.DataAnnotations;

namespace Selu383.SP25.Api.Models;

public class Theater
{
    public int Id { get; set; }

    [Required]
    [MaxLength(120)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Address { get; set; } = string.Empty;

    [Required]
    [Range(1, int.MaxValue)]
    public int SeatCount { get; set; }
}