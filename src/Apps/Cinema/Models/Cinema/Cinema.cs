using System.ComponentModel.DataAnnotations;

namespace FirstApi.Models;

public class Cinema {

    [Key]
    [Required]
    public int ID;

    [Required(ErrorMessage = "O nome do cinema é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O nome do cinema não pode possuir mais de 50 caracteres.")]
    public required string name;

}