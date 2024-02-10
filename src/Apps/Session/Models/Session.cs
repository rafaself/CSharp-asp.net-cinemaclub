using System.ComponentModel.DataAnnotations;
using FirstApi.Models;

namespace FirstAPI.Models;

public class Session
{
    [Key]
    [Required]
    public int ID { get; set; }
    [Required]
    public int MovieID { get; set; }
    public virtual Movie Movie { get; set; }
    [Required]
    public int CinemaID { get; set; }
    public virtual Cinema Cinema { get; set; }
}