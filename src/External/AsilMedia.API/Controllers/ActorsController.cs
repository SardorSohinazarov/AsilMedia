using AsilMedia.Application.DataTransferObjects;
using AsilMedia.Application.Services.Actors;
using Microsoft.AspNetCore.Mvc;

namespace AsilMedia.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorsController(IActorService actorService)
            => _actorService = actorService;

        [HttpPost]
        public async Task<IActionResult> PostAsync(ActorDTO actorDTO)
        {
            var actor = await _actorService.InsertAsync(actorDTO);

            return Ok(actor);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var actors = await _actorService.SelectAllAsync();

            return Ok(actors);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var actor = await _actorService.SelectByIdAsync(id);

            return Ok(actor);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(ActorDTO actorDTO, long id)
        {
            var actor = await _actorService.UpdateAsync(actorDTO, id);

            return Ok(actor);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var actor = await _actorService.DeleteAsync(id);

            return Ok(actor);
        }
    }
}
