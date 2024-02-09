using System.ComponentModel.DataAnnotations;
using FirstAPI.Models;

namespace FirstApi.Models;

public class Cinema
{

    [Key]
    [Required]
    public int ID { get; set; }

    [Required(ErrorMessage = "O nome do cinema é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O nome do cinema não pode possuir mais de 50 caracteres.")]
    public required string Name { get; set; }

    public int AddressID { get; set; }
    public virtual Address Address { get; set; }

}