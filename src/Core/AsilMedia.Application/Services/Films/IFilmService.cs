using AsilMedia.Application.DataTransferObjects.Films;
using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Services.Films
{
    public interface IFilmService
    {
        public ValueTask<Film> AddAsync(FilmCreationDTO filmDTO);
        public ValueTask<List<Film>> RetrieveAllAsync();
        public ValueTask<Film> RetrieveByIdAsync(long id);
        public ValueTask<Film> ModifyAsync(long id, FilmModificationDTO filmDTO);
        public ValueTask<Film> RemoveAsync(long id);
    }
}
