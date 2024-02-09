using System.ComponentModel.DataAnnotations;
using FirstAPI.Validations;

namespace FirstAPI.Data.Dtos;

public class CreateAddressDto
{

    [Required(ErrorMessage = "O campo rua é obrigatório.")]
    public string Street { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo número é obrigatório.")]
    [EnsureNonZero(ErrorMessage = "O número deve ser diferente de zero.")]
    public int? Number { get; set; }

}