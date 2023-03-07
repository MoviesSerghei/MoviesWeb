using MoviesWeb.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace MoviesWeb
{
        public class MoviesWebDBInitializer : DropCreateDatabaseAlways<MoviesWebContext>
        {
                protected override void Seed(MoviesWebContext context)
                {
                        var genres = new List<Genre>();

                        genres.Add(new Genre()
                        {
                                Name = "Комедия"
                        });
                        genres.Add(new Genre()
                        {
                                Name = "Трагедия"
                        });
                        genres.Add(new Genre()
                        {
                                Name = "Трагикомедия"
                        });
                        genres.Add(new Genre()
                        {
                                Name = "Боевик"
                        });
                        genres.Add(new Genre()
                        {
                                Name = "Фэнтэзи"
                        });
                        genres.Add(new Genre()
                        {
                                Name = "Научная Фантастика"
                        });
                        context.Genres.AddRange(genres);
                         base.Seed(context);
                        var movies = new List<Movie>();

                        movies.Add(new Movie()
                        {
                                Name = "movie1",
                                Date = System.DateTime.Now,
                                Image = "",
                                GenreID = 1,
                                Description = "Description sdfsdf",
                                Rate = 1,
                                Favorite = false,
                                   
                        });

                        context.Movies.AddRange(movies);

                        base.Seed(context);
                }
        }
}