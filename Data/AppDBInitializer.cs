using OnlineShop.Models;

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
                        }



                    }) ; 



                }
                //Actors_Movies
                if (!context.Actors_Movies.Any())
                {


                }
            }
        }
    }
}
