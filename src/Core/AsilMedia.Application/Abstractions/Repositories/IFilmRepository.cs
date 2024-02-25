using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Abstractions.Repositories
{
    public interface IFilmRepository
    {
        public Task<Film> InsertAsync(Film film);
        public Task<Film> SelectByIdAsync(long id);
        public Task<List<Film>> SelectAllAsync();
        public Task<Film> UpdateAsync(Film film, long id);
        public Task<Film> DeleteAsync(long id);
    }
}
