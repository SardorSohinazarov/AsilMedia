using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AsilMedia.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
            => _context = context;

        public async ValueTask<Genre> InsertGenreAsync(Genre genre)
        {
            var entry = await _context.AddAsync(genre);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public async ValueTask<Genre> SelectGenreByIdAsync(long id)
        {
            var storedGenre = await _context.Genres
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (storedGenre == null)
                throw new Exception($"Genre {id} was not found.");

            return storedGenre;
        }

        public async ValueTask<List<Genre>> SelectAllGenresAsync()
        {
            return await _context.Genres
                .AsNoTracking()
                .ToListAsync();
        }

        public async ValueTask<List<Genre>> SelectAllGenresAsync(List<long> ids)
        {
            return await _context.Genres
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();
        }

        public async ValueTask<Genre> UpdateGenreAsync(long id, Genre genre)
        {
            var storedGenre = await _context.Genres
                .FirstOrDefaultAsync(x => x.Id == id);

            if (storedGenre == null)
                throw new Exception($"Genre {id} was not found.");

            storedGenre.Name = genre.Name;

            var entry = _context.Update(storedGenre);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public async ValueTask<Genre> DeleteGenreAsync(long id)
        {
            var storedGenre = await _context.Genres
                .FirstOrDefaultAsync(x => x.Id == id);

            if (storedGenre == null)
                throw new Exception($"Genre {id} was not found.");

            var entry = _context.Remove(storedGenre);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
