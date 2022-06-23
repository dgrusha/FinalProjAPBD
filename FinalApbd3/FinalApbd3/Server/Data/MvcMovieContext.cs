using FinalApbd3.Server.DTO;
using Microsoft.EntityFrameworkCore;

namespace FinalApbd3.Server.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
            : base(options)
        {

        }

        public DbSet<Movie> Movie { get; set; }
    }
}
