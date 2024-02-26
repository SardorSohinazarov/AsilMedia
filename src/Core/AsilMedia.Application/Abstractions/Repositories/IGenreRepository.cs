using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Abstractions.Repositories
{
    public interface IGenreRepository
    {
        public Task<Genre> InsertAsync(Genre genre);
        public Task<Genre> SelectByIdAsync(long id);
        public Task<List<Genre>> SelectAllAsync();
        public Task<Genre> UpdateAsync(Genre genre, long id);
        public Task<Genre> DeleteAsync(long id);
    }
}
