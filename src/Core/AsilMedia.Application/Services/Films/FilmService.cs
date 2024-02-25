using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Application.DataTransferObjects;
using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Services.Films
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _filmRepository;

        public FilmService(IFilmRepository filmRepository)
            => _filmRepository = filmRepository;

        public async Task<Film> InsertAsync(FilmDTO filmDTO)
        {
            var film = new Film()
            {
                Title = filmDTO.Title,
                AgeRestriction = filmDTO.AgeRestriction,

                ///...
            };

            film = await _filmRepository.InsertAsync(film);

            return film;
        }

        public async Task<List<Film>> SelectAllAsync()
            => await _filmRepository.SelectAllAsync();

        public async Task<Film> SelectByIdAsync(long id)
            => await _filmRepository.SelectByIdAsync(id);

        public async Task<Film> UpdateAsync(FilmDTO filmDTO, long id)
        {
            var film = new Film()
            {
                Title = filmDTO.Title,
                AgeRestriction = filmDTO.AgeRestriction,

                ///...
            };

            return await _filmRepository.UpdateAsync(film, id);
        }

        public async Task<Film> DeleteAsync(long id)
            => await _filmRepository.DeleteAsync(id);
    }
}