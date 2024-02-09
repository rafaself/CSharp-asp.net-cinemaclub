using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Models;

public class Session
{
    [Key]
    [Required]
    public int ID { get; set; }
    [Required]
    public int MovieID { get; set; }
    public virtual Movie Movie { get; set; }
}