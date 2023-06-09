﻿using OnlineShop.Models;
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
                            Logo = "https://thumbs.dreamstime.com/z/abstract-cinema-lor-template-isolated-white-background-79853753.jpg",
                            Description = "This is the discription of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema2",
                            Logo = "https://img.freepik.com/premium-vector/cinema-logo-with-popcorn_23-2147494040.jpg",
                            Description = "This is the discription of the second cinemA"
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
                            ProfilePicture = "https://static.hdrezka.ac/i/2023/3/4/z160d01daedc7it94w55y.jpg\r\n"
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
                            Bio = "This is the fifth actor",
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
                        Bio = "This is the fifth Producer",
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
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 1,
                            ProducerId = 1,
                            MovieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerId = 4,
                            MovieCategory = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 1,
                            ProducerId = 2,
                            MovieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerId = 3,
                            MovieCategory = MovieCategory.Cartoon
                        },
                        new Movie()
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            ImageUrl = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerId = 5,
                            MovieCategory = MovieCategory.Drama
                        }

                    });
                    context.SaveChanges();

                }
                //Actors_Movies 
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 1
                        },

                         new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 2
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 2
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 3
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 4
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 5
                        },


                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieId = 6
                        },
                    });
                    context.SaveChanges();

                }
            }
        }
    }
}
