using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Data.Dtos;

public class ReadCinemaDto
{
    public int ID { get; set; }

    [Required(ErrorMessage = "O campo de nome é obrigatório.")]
    public string Nome { get; set; }
}

public class UpdateCinemaDto
{
    [Required(ErrorMessage = "O campo de nome é obrigatório.")]
    public string Nome { get; set; }
}