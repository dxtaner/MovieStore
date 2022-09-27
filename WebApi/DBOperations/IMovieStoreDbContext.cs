using Microsoft.EntityFrameworkCore;
using WebApi.Entites;

namespace WebApi.DBOperations
{
    public class IMovieStoreDbContext
    {
        DbSet<Actor> Actors { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Director> Directors { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<Customer> Customers { get; set; }

        int SaveChanges();


    }
}