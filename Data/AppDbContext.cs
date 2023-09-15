using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Data
{
    public class AppDbContext: IdentityDbContext<UserModel>   
    { 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.MovieId,
                am.ActorId

            });

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);

            modelBuilder.Entity<Cinema>()
                .HasMany(b => b.Movies)
                .WithOne(b => b.Cinema)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Producer>()
                .HasMany(b => b.Movies)
                .WithOne(b => b.Producer)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<UserModel> Userss { get; set; }
      
    }
}
