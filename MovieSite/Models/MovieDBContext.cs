using Microsoft.EntityFrameworkCore;
using MovieSite.Models;

public class MovieDBContext : DbContext
{
  
    public MovieDBContext(DbContextOptions<MovieDBContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
}