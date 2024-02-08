using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Data;

public class FilmeContext : DbContext
{

    public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts)
    {

    }
    
    public DbSet<Filme> Filmes { get; set; }


}