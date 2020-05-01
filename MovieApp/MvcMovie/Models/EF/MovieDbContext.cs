using System.Data.Entity;

namespace MvcMovie.Models.EF
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MovieDbContext>());
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
