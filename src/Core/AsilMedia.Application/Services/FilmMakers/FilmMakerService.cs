using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Application.DataTransferObjects;
using AsilMedia.Domain.Entities;
using Mapster;

namespace AsilMedia.Application.Services.FilmMakers
{
    public class FilmMakerService : IFilmMakerService
    {
        private readonly IFilmMakerRepository _filmMakerRepository;

        public FilmMakerService(IFilmMakerRepository filmMakerRepository) 
            => _filmMakerRepository = filmMakerRepository;

        public async Task<FilmMaker> InsertAsync(FilmMakerDTO filmMakerDTO)
        {
            var filmMaker = filmMakerDTO.Adapt<FilmMaker>();

            var res = await _filmMakerRepository.InsertAsync(filmMaker);
            return res;
        }

        public async Task<List<FilmMaker>> SelectAllAsync()
            => await _filmMakerRepository.SelectAllAsync();


        public async Task<FilmMaker> SelectByIdAsync(long id)
            => await _filmMakerRepository.SelectByIdAsync(id);

        public Task<FilmMaker> UpdateAsync(FilmMakerDTO filmMakerDTO, long id)
        {
            var filmMaker = filmMakerDTO.Adapt<FilmMaker>();
            var res = _filmMakerRepository.UpdateAsync(filmMaker, id);
            return res;
        }
        public async Task<FilmMaker> DeleteAsync(long id)
            => await _filmMakerRepository.DeleteAsync(id);
    }
}
