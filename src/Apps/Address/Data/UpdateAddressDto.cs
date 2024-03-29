using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Data.Dtos;

public class UpdateAddressDto {
    [Required(ErrorMessage = "O campo rua é obrigatório.")]
    public string Street;

    [Required(ErrorMessage = "O campo número é obrigatório.")]
    public int Number;
}