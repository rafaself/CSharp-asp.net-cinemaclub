using System.ComponentModel.DataAnnotations;

public class CreateSessionDto
{
    [Required(ErrorMessage = "É necessário informar o ID do filme.")]
    public int MovieID { get; set; }
}