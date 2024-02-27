using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Application.DataTransferObjects;
using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Services.FilmMakers
{
    public class FilmMakerService : IFilmMakerService
    {
        private readonly IFilmMakerRepository _filmMakerRepository;

        public FilmMakerService(IFilmMakerRepository filmMakerRepository)
            => _filmMakerRepository = filmMakerRepository;

        public Task<FilmMaker> InsertAsync(FilmMakerDTO filmMakerDTO)
        {
            var filmMaker = new FilmMaker()
            {
                FirstName = filmMakerDTO.FirstName,
                LastName = filmMakerDTO.LastName,
                Description = filmMakerDTO.Description,
                Gender = filmMakerDTO.Gender,
                PhotoPath = filmMakerDTO.PhotoPath,
            };
            var res = _filmMakerRepository.InsertAsync(filmMaker);
            return res;
        }

public async Task<List<FilmMaker>> SelectAllAsync()
    => await _filmMakerRepository.SelectAllAsync();


        public async Task<FilmMaker> SelectByIdAsync(long id)
            => await _filmMakerRepository.SelectByIdAsync(id);

        public Task<FilmMaker> UpdateAsync(FilmMakerDTO filmMakerDTO, long id)
        {
            var filmMaker = new FilmMaker()
            {
                FirstName = filmMakerDTO.FirstName,
                LastName = filmMakerDTO.LastName,
                Description = filmMakerDTO.Description,
                Gender = filmMakerDTO.Gender,
                PhotoPath = filmMakerDTO.PhotoPath,
            };
            var res = _filmMakerRepository.UpdateAsync(filmMaker, id);
            return res;
        }
        public async Task<FilmMaker> DeleteAsync(long id)
            => await _filmMakerRepository.DeleteAsync(id);
    }
}
