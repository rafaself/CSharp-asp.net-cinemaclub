
using System.ComponentModel.DataAnnotations;
using FirstApi.Models;

namespace FirstAPI.Models;

public class Address
{
    [Key]
    [Required]
    public int ID { get; set; }

    [Required(ErrorMessage = "O campo rua é obrigatório.")]
    public string Street { get; set; }

    [Required(ErrorMessage = "O campo número é obrigatório.")]
    public int Number { get; set; }

    public virtual Cinema Cinema { get; set; }
}