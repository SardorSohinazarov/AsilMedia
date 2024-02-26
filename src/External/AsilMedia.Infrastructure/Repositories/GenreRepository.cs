using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Domain.Entities;
using AsilMedia.Domain.Exceptions.Genres;
using AsilMedia.Infrastructure1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AsilMedia.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GenreRepository(ApplicationDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<Genre> DeleteAsync(long id)
        {
            var model = await _dbContext.Genres.FirstOrDefaultAsync(x => x.Id == id);

            if (model is null)
                throw new GenreNotFoundException();

            return model;
        }

        public async Task<Genre> InsertAsync(Genre gen)
        {
            EntityEntry<Genre> entry = await _dbContext.Genres.AddAsync(gen);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<List<Genre>> SelectAllAsync()
            => await _dbContext.Genres.ToListAsync();

        public async Task<Genre> SelectByIdAsync(long id)
        {
            var model = await _dbContext.Genres.FirstOrDefaultAsync(x => x.Id == id);

            if (model is null)
                throw new GenreNotFoundException();

            return model;
        }

        public async Task<Genre> UpdateAsync(Genre gen, long id)
        {
            var model = await _dbContext.Genres.FirstOrDefaultAsync(x => x.Id == id);

            if (model is null)
                throw new GenreNotFoundException();

            model.Name = gen.Name;

            EntityEntry<Genre> entry = _dbContext.Genres.Update(model);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
