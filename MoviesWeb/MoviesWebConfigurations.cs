using MoviesWeb.Models;
using System.Data.Entity.ModelConfiguration;

namespace MoviesWeb
{
    public class MoviesWebConfigurations : EntityTypeConfiguration<Movie>
    {
        public MoviesWebConfigurations()
        {
            this.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}