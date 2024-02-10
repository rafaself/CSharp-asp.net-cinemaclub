using System.ComponentModel.DataAnnotations;
using FirstApi.Models;

namespace FirstAPI.Models;

public class Session
{
    public int MovieID { get; set; }
    public virtual Movie Movie { get; set; }
    public int CinemaID { get; set; }
    public virtual Cinema Cinema { get; set; }
}