using MoviesWeb.Models;
using System.Data.Entity;

namespace MoviesWeb
{
    public class MoviesWebContext : DbContext
    {
        public MoviesWebContext()// : base("MoviesServer")
                {
            Database.SetInitializer<MoviesWebContext>(new MoviesWebDBInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Adds configurations for Student from separate class
            modelBuilder.Configurations.Add(new MoviesWebConfigurations());

            modelBuilder.Entity<Movie>()
                .ToTable("Movie");

            modelBuilder.Entity<Genre>()
                        .ToTable("Genre");
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        }
}