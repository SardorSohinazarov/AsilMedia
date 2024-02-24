using AsilMedia.Application.DataTransferObjects.FilmMakers;
using AsilMedia.Application.Services.FilmMakers;
using Microsoft.AspNetCore.Mvc;

namespace AsilMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmMakersController : ControllerBase
    {
        private readonly IFilmMakerService _filmMakerService;

        public FilmMakersController(IFilmMakerService filmMakerService)
            => _filmMakerService = filmMakerService;

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] FilmMakerCreationDTO filmMaker)
            => Ok(await _filmMakerService.AddAsync(filmMaker));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _filmMakerService.RetrieveAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] long id)
            => Ok(await _filmMakerService.RetrieveByIdAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] FilmMakerModificationDTO filmMaker, [FromRoute] long id)
            => Ok(await _filmMakerService.ModifyAsync(id, filmMaker));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
            => Ok(await _filmMakerService.RemoveAsync(id));
    }
}
