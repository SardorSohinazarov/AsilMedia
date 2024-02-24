using AsilMedia.Application.DataTransferObjects.Films;
using AsilMedia.Application.Services.Films;
using Microsoft.AspNetCore.Mvc;

namespace AsilMedia.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmService _filmService;

        public FilmsController(IFilmService filmService)
            => _filmService = filmService;

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] FilmCreationDTO film)
            => Ok(await _filmService.AddAsync(film));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _filmService.RetrieveAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] long id)
            => Ok(await _filmService.RetrieveByIdAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] FilmModificationDTO film, [FromRoute] long id)
            => Ok(await _filmService.ModifyAsync(id, film));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
            => Ok(await _filmService.RemoveAsync(id));
    }
}
