using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Models;

public class Movie
{
    [Key]
    [Required]
    public int ID { get; set; }

    [Required(ErrorMessage = "O título do movie é obrigatório")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "O gênero do movie é obrigatório")]
    [MaxLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 caracteres.")]
    public string Genre { get; set; } = string.Empty;

    [Required]
    [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos.")]
    public int Duration { get; set; }

    public virtual ICollection<Session> Sessions { get; set; }
}