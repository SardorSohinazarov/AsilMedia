using AsilMedia.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AsilMedia.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
            => Database.Migrate();

        public DbSet<Film> Films { get; set; }
        public DbSet<FilmMaker> FilmMakers { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Film>()
                .HasMany(x => x.Actors)
                .WithMany(x => x.Films)
                .UsingEntity<ActorFilm>();
        }
    }
}
