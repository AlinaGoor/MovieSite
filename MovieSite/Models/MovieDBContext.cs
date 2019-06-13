using Microsoft.EntityFrameworkCore;
using MovieSite.Models;

public class MovieDBContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
}