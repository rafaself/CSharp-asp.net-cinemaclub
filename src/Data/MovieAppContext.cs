using FirstApi.Models;
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Data;

public class MovieAppContext : DbContext
{
    public MovieAppContext(DbContextOptions<MovieAppContext> opts) : base(opts)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Session>()
            .HasKey(session => new { session.MovieID, session.CinemaID });

        builder.Entity<Session>()
            .HasOne(session => session.Cinema)
            .WithMany(cinema => cinema.Sessions)
            .HasForeignKey(session => session.CinemaID);
    
        builder.Entity<Session>()
            .HasOne(session => session.Movie)
            .WithMany(movie => movie.Sessions)
            .HasForeignKey(session => session.MovieID);

        builder.Entity<Address>()
            .HasOne(address => address.Cinema)
            .WithOne(cinema => cinema.Address)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Session> Sessions { get; set; }
}