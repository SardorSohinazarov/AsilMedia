using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AsilMedia.Infrastructure.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly ApplicationDbContext _context;

        public FilmRepository(ApplicationDbContext context)
            => _context = context;

        public async ValueTask<Film> InsertFilmAsync(Film film)
        {
            var entry = await _context.AddAsync(film);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public async ValueTask<Film> SelectFilmByIdAsync(long id)
        {
            var storedFilm = await _context.Films
                .AsNoTracking()
                .Include(x => x.FilmMaker)
                .Include(x => x.Actors)
                .Include(x => x.Genres)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (storedFilm == null)
                throw new Exception($"Film {id} was not found.");

            return storedFilm;
        }

        public async ValueTask<List<Film>> SelectAllFilmsAsync()
            => await _context.Films
            .AsNoTracking()
            .Include(x => x.FilmMaker)
            .Include(x => x.Actors)
            .Include(x => x.Genres)
            .ToListAsync();

        public async ValueTask<Film> UpdateFilmAsync(long id, Film film)
        {
            var storedFilm = await _context.Films
                .FirstOrDefaultAsync(x => x.Id == id);

            if (storedFilm == null)
                throw new Exception($"Film {id} was not found.");

            storedFilm.Title = film.Title;
            storedFilm.Description = film.Description;
            storedFilm.AgeRestriction = film.AgeRestriction;
            storedFilm.FilmMakerId = film.FilmMakerId;
            storedFilm.PublishedYear = film.PublishedYear;
            storedFilm.UpdatedAt = DateTime.Now;

            var entry = _context.Update(storedFilm);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public async ValueTask<Film> DeleteFilmAsync(long id)
        {
            var storedFilm = await _context.Films
                .FirstOrDefaultAsync(x => x.Id == id);

            if (storedFilm == null)
                throw new Exception($"Film {id} was not found.");

            var entry = _context.Remove(storedFilm);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
