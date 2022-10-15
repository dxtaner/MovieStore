using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
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
                    new Director{Name="Christopher",Surname=" Nolan", DirectedMovies={}},
                    new Director{Name="Quentin",Surname="Tarantino"},
                    new Director{Name="Emnith",Surname="Samalayabnr"},
                    new Director{Name="Raci",Surname="Şaşmaz"},
                    new Director{Name="Asi",Surname="Beya"}

                };

                if (context.Directors.Any())
                {
                    return;
                }
                context.Directors.AddRange(directors);

                List<Actor> actors = new List<Actor>(){
                    new Actor {Name="Polat", Surname="Alemdar", PlayedMovies={}},
                    new Actor {Name="Fattih", Surname="Terim"},
                    new Actor {Name="Bruce",Surname="Wayne"},
                    new Actor {Name="Crihis",Surname="Yaolo"},
                };

                if (context.Actors.Any())
                {
                    return;
                }
                context.Actors.AddRange(actors);


                List<Movie> movies = new List<Movie>(){
                    new Movie{Title="Dark Knight Rises",PublishDate=DateTime.Now.AddYears(-9),GenreId=6,DirectorID=1,Price=230,
                    Actors = new List<Actor>(){actors[2],actors[3]
                        }
                    },
                    new Movie{Title="KVP",PublishDate=DateTime.Now.AddYears(-20),GenreId=5,DirectorID=4,Price=150,
                    Actors = new List<Actor>(){
                        actors[0],actors[1]
                        }
                    }
                };

                if (context.Movies.Any())
                {
                    return;
                }
                context.Movies.AddRange(movies);

                List<Customer> customers = new List<Customer>(){
                    new Customer{Name="Hasan",Surname="Ali"
                    },
                    new Customer
                    {
                        Name = "Beril",
                        Surname = "Cemre"
                    }
                };

                if (context.Customers.Any())
                {
                    return;
                }
                context.Customers.AddRange(customers);

                List<BoughtMovie> boughtMovies = new List<BoughtMovie>(){
                    new BoughtMovie{CustomerID=1,MovieID=1,BoughtMovieDate=DateTime.Now,Price=movies[0].Price, isActive=true},
                    new BoughtMovie{CustomerID=2,MovieID=2,BoughtMovieDate=DateTime.Now,Price=movies[2].Price, isActive=true},
                    new BoughtMovie{CustomerID=1,MovieID=2,BoughtMovieDate=DateTime.Now,Price=movies[1].Price, isActive=true}
                };

                if (context.BoughtMovies.Any())
                {
                    return;
                }
                context.BoughtMovies.AddRange(boughtMovies);


                context.SaveChanges();
            }
        }
    }
}