using AsilMedia.Application.DataTransferObjects;
using AsilMedia.Application.Services.Films;
using Microsoft.AspNetCore.Mvc;

namespace AsilMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
            => _filmService = filmService;

        [HttpPost]
        public async Task<IActionResult> FilmPostAsync(FilmDTO filmDTO)
        {
            var film = await _filmService.InsertAsync(filmDTO);

            return Ok(film);
        }

        [HttpGet]
        public async Task<IActionResult> FilmGetAllAsync()
        {
            var films = await _filmService.SelectAllAsync();

            return Ok(films);
        }

        [HttpGet]
        public async Task<IActionResult> FilmGetByIdAsync(int id)
        {
            var films = await _filmService.SelectByIdAsync(id);

            return Ok(films);
        }

        [HttpPut]
        public async Task<IActionResult> FilmUpdateAsync(FilmDTO filmDTO, int id = 0)
        {
            var films = await _filmService.UpdateAsync(filmDTO, id);
            return Ok(films);
        }

        [HttpDelete]
        public async Task<IActionResult> FilmDeleteAsync(int id)
        {
            var films = await _filmService.DeleteAsync(id);
            return Ok(films);
        }
    }
}
