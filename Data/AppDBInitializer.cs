using OnlineShop.Models;
using OnlineShop.Data.Enum;
using System.Security.Cryptography.Xml;

namespace OnlineShop.Data
{
    public class AppDBInitializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Cinema
                if(!context.Cinemas.Any()) 
                {
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema1",
                            Logo = "http://dotnethow.net./images/cinemas/cinema-1.jpeg",
                            Description = "This is the discription of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema2",
                            Logo = "http://dotnethow.net./images/cinemas/cinema-2.jpeg",
                            Description = "This is the discription of the second cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the discription of the third cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema4",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the discription of the fourth cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema5",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the discription of the fifth cinema"
                        }
                    });
                    context.SaveChanges();

                }

                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    { 
                        new Actor() 
                        {
                            FullName ="Actor 1",
                            Bio = "This is the first actor",
                            ProfilePicture = "http://dotnethow.net/images/actors/actor-1.jpeg"
                        },
                        new Actor() 
                        {
                            FullName ="Actor 2",
                            Bio = "This is the second actor",
                            ProfilePicture = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor() 
                        {
                            FullName ="Actor 3",
                            Bio = "This is the third actor",
                            ProfilePicture = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor() 
                        {
                            FullName ="Actor 4",
                            Bio = "This is the fourth actor",
                            ProfilePicture = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor() 
                        {
                            FullName ="Actor 5",
                            Bio = "This is the fith actor",
                            ProfilePicture = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                        
                    
                    });
                    context.SaveChanges();

                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    { 
                     new Producer()
                     {
                        FullName = "Producer 1",
                        Bio = "This is the first Producer",
                        ProfilePicture = "http://dotnethow.net/images/producers/producer-1.jpeg "
                     }
                     ,
                     new Producer()
                     {
                        FullName = "Producer 2",
                        Bio = "This is the second Producer",
                        ProfilePicture = "http://dotnethow.net/images/producers/producer-2.jpeg "
                     }
                     ,new Producer()
                     {
                        FullName = "Producer 3",
                        Bio = "This is the third Producer",
                        ProfilePicture = "http://dotnethow.net/images/producers/producer-3.jpeg "
                     }
                     ,new Producer()
                     {
                        FullName = "Producer 4",
                        Bio = "This is the fourth Producer",
                        ProfilePicture = "http://dotnethow.net/images/producers/producer-4.jpeg "
                     }
                     ,new Producer()
                     {
                        FullName = "Producer 5",
                        Bio = "This is the fith Producer",
                        ProfilePicture = "http://dotnethow.net/images/producers/producer-5.jpeg "
                     },   
                    
                    });
                    context.SaveChanges(); 
                }
                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Harry Poter",
                            Description = "This is the Harry Poter movie description",
                            Price = 39.20,
                            ImageUrl  = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now.AddDays(1),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId =1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Action,


                        },

                        new Movie()
                        {
                            Name = "Elden Ring",
                            Description = "This is the Elden Ring movie description",
                            Price = 40.68,
                            ImageUrl  = "http://dotnethow.net/images/movies/movie-2.jpeg",
                            StartDate = DateTime.Now.AddDays(6),
                            EndDate = DateTime.Now.AddDays(-3),
                            CinemaId =2,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Comedy,


                        },
                        new Movie()
                        {
                            Name = "Odissea",
                            Description = "This is the Odissea movie description",
                            Price = 98.12,
                            ImageUrl  = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-4),
                            EndDate = DateTime.Now.AddDays(8),
                            CinemaId =3,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Drama,


                        },

                        new Movie()
                        {
                            Name = "Runner",
                            Description = "This is the Runner movie description",
                            Price = 10.42,
                            ImageUrl  = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now.AddDays(4),
                            EndDate = DateTime.Now.AddDays(9),
                            CinemaId =4,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Documentary,


                        },
                        new Movie()
                        {
                            Name = "Hobbit",
                            Description = "This is the Hobbit movie description",
                            Price = 65.05,
                            ImageUrl  = "http://dotnethow.net/images/movies/movie-5.jpeg",
                            StartDate = DateTime.Now.AddDays(-5),
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId =5,
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Cartoon,

                        },
                        new Movie()
                        {
                            Name = "Batman",
                            Description = "This is the Batman movie description",
                            Price = 12.22,
                            ImageUrl  = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-9),
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId =6,
                            ProducerId = 6,
                            MovieCategory = MovieCategory.Horror,

                        }

                    }) ;
                    context.SaveChanges();

                }
                //Actors_Movies
                if (!context.Actors_Movies.Any())
                {
                    context.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            AcotorId = 1,
                            MovieId = 1

                        },
                        new Actor_Movie()
                        {
                            AcotorId = 1,
                            MovieId = 3

                        },
                        new Actor_Movie()
                        {
                            AcotorId = 2,
                            MovieId = 1

                        },
                        new Actor_Movie()
                        {
                            AcotorId = 2,
                            MovieId = 4

                        },
                        new Actor_Movie()
                        {
                            AcotorId = 3,
                            MovieId = 1

                        },
                        new Actor_Movie()
                        {
                            AcotorId = 3,
                            MovieId = 2

                        },
                        new Actor_Movie()
                        {
                            AcotorId = 3,
                            MovieId = 5

                        },
                        new Actor_Movie()
                        {
                            AcotorId = 4,
                            MovieId = 2

                        },
                        new Actor_Movie()
                        {
                            AcotorId = 4,
                            MovieId = 3

                        },
                        new Actor_Movie()
                        {
                            AcotorId = 4,
                            MovieId = 4

                        },
                        new Actor_Movie()
                        {
                            AcotorId = 5,
                            MovieId = 2

                        },
                        new Actor_Movie()
                        {
                            AcotorId = 5,
                            MovieId = 3

                        },
                        new Actor_Movie()
                        {
                            AcotorId = 5,
                            MovieId = 4

                        },
                        new Actor_Movie()
                        {
                            AcotorId = 5,
                            MovieId = 5

                        },
                        new Actor_Movie()
                        {
                            AcotorId = 6,
                            MovieId = 3

                        },
                        new Actor_Movie()
                        {
                            AcotorId = 6,
                            MovieId = 4

                        },
                        new Actor_Movie()
                        {
                            AcotorId = 6,
                            MovieId = 5

                        }
                    });
                    context.SaveChanges();

                }
            }
        }
    }
}
