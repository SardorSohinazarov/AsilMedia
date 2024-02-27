using AsilMedia.Application.DataTransferObjects;
using AsilMedia.Application.Services.Films;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsilMedia.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService)
        {
            this._filmService = filmService;
        }
        [HttpPost]

        public async Task<IActionResult> PostAsync(FilmDTO filmDTO)
        {
            var film  = await _filmService.InsertAsync(filmDTO);
            return Ok(film);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var films = await _filmService.SelectAllAsync();
            return Ok(films);
        }
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var films = await _filmService.SelectByIdAsync(id);
            return Ok(films);
        }
        [HttpPut]
        public async Task<IActionResult> PutAsync(FilmDTO filmDTO, long id)
        {
            var films = await _filmService.UpdateAsync(filmDTO,id);
            return Ok(films);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var films = await _filmService.DeleteAsync(id);
            return Ok(films);
        }
    }
}
