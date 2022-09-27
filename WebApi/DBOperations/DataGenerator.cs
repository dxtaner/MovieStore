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

                var actors = new List<Actor>{
                new Actor
                {

                },
                new Actor
                {

                },
                new Actor
                {

                }
                };

                context.Genres.AddRange(
                  new Genre
                  {
                      GenreName = "PersonalGrowth"
                  },
                  new Genre
                  {
                      GenreName = "ScienceFiction"
                  },
                  new Genre
                  {
                      GenreName = "Noval"
                  }
                );

                context.Directors.AddRange(
                new Director()
                {

                });

                context.Actors.AddRange(actors);


                context.SaveChanges();
            }
        }
    }
}