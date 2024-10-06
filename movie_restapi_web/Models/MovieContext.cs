using Microsoft.EntityFrameworkCore;

namespace movie_restapi_web.Models
//namespace AspNetCoreWebAPI8.Models
{
    public class MovieContext:DbContext
    {
        public MovieContext()
        {
        }
        public MovieContext(DbContextOptions<MovieContext> options)
            :base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
