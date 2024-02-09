using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Data.Dtos;

public class UpdateCinemaDto
{
    [Required(ErrorMessage = "O nome do cinema é obrigatório.")]
    public string name { get; set; }
    public ReadAddressDto ReadAddressDto { get; set; }
}