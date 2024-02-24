using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Abstractions.Repositories
{
    public interface IGenreRepository
    {
        public ValueTask<Genre> InsertGenreAsync(Genre genre);
        public ValueTask<List<Genre>> SelectAllGenresAsync();
        public ValueTask<List<Genre>> SelectAllGenresAsync(List<long> ids);
        public ValueTask<Genre> SelectGenreByIdAsync(long id);
        public ValueTask<Genre> UpdateGenreAsync(long id, Genre genre);
        public ValueTask<Genre> DeleteGenreAsync(long id);
    }
}
