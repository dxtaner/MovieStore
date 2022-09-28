using Microsoft.EntityFrameworkCore;
using WebApi.Entites;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                // Look for any book.
                if (context.Movies.Any())
                {
                    return;   // Data was already seeded
                }

                List<Genre> genres = new List<Genre>(){
                    new Genre { GenreName = "Love" },
                    new Genre { GenreName = "Noval" },
                    new Genre { GenreName = "ScienceFiction" },
                    new Genre { GenreName = "Fii" },
                    new Genre { GenreName = "Turkish" },
                    new Genre { GenreName = "Action" }
                };

                if (context.Genres.Any())
                {
                    return;
                }
                context.Genres.AddRange(genres);

                List<Director> directors = new List<Director>(){
                    new Director{Name="Christopher",Surname=" Nolan"},
                    new Director{Name="Quentin",Surname="Tarantino"},
                    new Director{Name="Emnith",Surname="Samalayabnr"}
                };

                context.Directors.AddRange(directors);


                List<Actor> actors = new List<Actor>(){
                    new Actor {Name="Polat", Surname="Alemdar"},
                    new Actor {Name="Fattih", Surname="Terim"},
                    new Actor {Name="Bruce",Surname="Wayne"},
                    new Actor {Name="Crihis",Surname="Yaolo"},
                };

                context.Actors.AddRange(actors);



                context.SaveChanges();
            }
        }
    }
}