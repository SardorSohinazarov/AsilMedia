﻿using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Domain.Entities;
using AsilMedia.Domain.Exceptions.Genres;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AsilMedia.Infrastructure.Repositories
{
    public class GenreRespoitory : IGenreRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GenreRespoitory(ApplicationDbContext dbContext)
            => _dbContext = dbContext;

        public async Task<Genre> InsertAsync(Genre genre)
        {
            EntityEntry<Genre> entry = await _dbContext.Genres.AddAsync(genre);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<List<Genre>> SelectAllAsync()
            => await _dbContext.Genres.ToListAsync();

        public async Task<Genre> SelectByIdAsync(long id)
        {
            var model = await _dbContext.Genres
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (model is null)
                throw new GenreNotFoundException();

            return model;
        }

        public async Task<Genre> UpdateAsync(Genre genre, long id)
        {
            var storedGenre = await _dbContext.Genres.FirstOrDefaultAsync(x => x.Id == id);

            if (storedGenre is null)
                throw new GenreNotFoundException();

            storedGenre.Name = genre.Name;

            EntityEntry<Genre> entry = _dbContext.Genres.Update(storedGenre);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<Genre> DeleteAsync(long id)
        {
            Genre? storedGenre = await _dbContext.Genres.FirstOrDefaultAsync(x => x.Id == id);

            if (storedGenre is null)
                throw new GenreNotFoundException();

            storedGenre.IsDeleted = true;
            storedGenre.DeletedDateTime = DateTime.UtcNow;

            var entry = _dbContext.Update(storedGenre);

            //var entry = _dbContext.Remove(storedGenre);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<List<Genre>> SelectAllAsync(List<long> ids)
            => await _dbContext.Genres.Where(x => ids.Contains(x.Id)).ToListAsync();
    }
}
