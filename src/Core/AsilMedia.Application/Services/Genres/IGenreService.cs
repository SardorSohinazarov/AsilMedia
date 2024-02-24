using AsilMedia.Application.DataTransferObjects.Genres;
using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Services.Genres
{
    public interface IGenreService
    {
        public ValueTask<Genre> AddAsync(GenreCreationDTO genreDTO);
        public ValueTask<List<Genre>> RetrieveAllAsync();
        public ValueTask<Genre> RetrieveByIdAsync(long id);
        public ValueTask<Genre> ModifyAsync(long id, GenreModificationDTO genreDTO);
        public ValueTask<Genre> RemoveAsync(long id);
    }
}
