using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Data;

public class MovieContext : DbContext
{

    public MovieContext(DbContextOptions<MovieContext> opts) : base(opts)
    {

    }
    
    public DbSet<Movie> Movies { get; set; }


}