using AsilMedia.Application.DataTransferObjects.FilmMakers;
using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Services.FilmMakers
{
    public interface IFilmMakerService
    {
        public ValueTask<FilmMaker> AddAsync(FilmMakerCreationDTO filmMakerDTO);
        public ValueTask<List<FilmMaker>> RetrieveAllAsync();
        public ValueTask<FilmMaker> RetrieveByIdAsync(long id);
        public ValueTask<FilmMaker> ModifyAsync(long id, FilmMakerModificationDTO filmMakerDTO);
        public ValueTask<FilmMaker> RemoveAsync(long id);
    }
}
