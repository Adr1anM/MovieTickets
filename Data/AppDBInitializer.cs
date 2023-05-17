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
                            Logo = "http://dotnethow.net./images/cinemas/cinema-1.jpg",
                            Description = "This is the discription of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema2",
                            Logo = "http://dotnethow.net./images/cinemas/cinema-2.jpg",
                            Description = "This is the discription of the second cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpg",
                            Description = "This is the discription of the third cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema4",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpg",
                            Description = "This is the discription of the fourth cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema5",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpg",
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
                            ProfilePicture = "http://dotnethow.net/images/actors/actor-1.jpg"
                        },
                        new Actor() 
                        {
                            FullName ="Actor 1",
                            Bio = "This is the first actor",
                            ProfilePicture = "http://dotnethow.net/images/actors/actor-1.jpg"
                        },
                        new Actor() 
                        {
                            FullName ="Actor 1",
                            Bio = "This is the first actor",
                            ProfilePicture = "http://dotnethow.net/images/actors/actor-1.jpg"
                        },
                        new Actor() 
                        {
                            FullName ="Actor 1",
                            Bio = "This is the first actor",
                            ProfilePicture = "http://dotnethow.net/images/actors/actor-1.jpg"
                        },
                        new Actor() 
                        {
                            FullName ="Actor 1",
                            Bio = "This is the first actor",
                            ProfilePicture = "http://dotnethow.net/images/actors/actor-1.jpg"
                        }
                        
                    
                    });



                }
                //Producers
                if (!context.Producers.Any())
                {


                }
                //Movies
                if (!context.Movies.Any())
                {


                }
                //Actors_Movies
                if (!context.Actors_Movies.Any())
                {


                }
            }
        }
    }
}
