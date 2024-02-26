using AsilMedia.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AsilMedia.Infrastructure1
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
            => Database.Migrate();

        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<FilmMaker> FilmMakers { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }
}
