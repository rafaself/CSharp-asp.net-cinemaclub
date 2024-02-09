using System.ComponentModel.DataAnnotations;
using FirstAPI.Validations;

namespace FirstAPI.Data.Dtos;

public class CreateCinemaDto
{
    [Required(ErrorMessage = "O nome do cinema é obrigatório.")]
    public string name { get; set; }

    [Required(ErrorMessage = "O ID do endereço do cinema é obrigatório.")]
    [EnsureNonZero(ErrorMessage = "O número deve ser diferente de zero.")]
    public int AddressID { get; set; }
}