using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Data.Dtos;

public class CreateCinemaDto
{
    [Required(ErrorMessage = "O nome do cinema é obrigatório.")]
    public string name = string.Empty;
}