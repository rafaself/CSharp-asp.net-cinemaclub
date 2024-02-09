
using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Models;

public class Address
{
    [Key]
    [Required]
    public int ID { get; set; }

    [Required(ErrorMessage = "O campo rua é obrigatório.")]
    public required string Street { get; set; }

    [Required(ErrorMessage = "O campo número é obrigatório.")]
    public int Number { get; set; }
}