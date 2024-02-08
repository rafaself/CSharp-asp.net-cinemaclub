using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Models;

public class Cinema
{
    [Key]
    [Required]
    public int ID { get; set; }

    [Required(ErrorMessage = "O campo de nome é obrigatório.")]
    public string Nome { get; set; }

}