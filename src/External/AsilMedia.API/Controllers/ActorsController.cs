using AsilMedia.Application.DataTransferObjects.Actors;
using AsilMedia.Application.Services.Actors;
using Microsoft.AspNetCore.Mvc;

namespace AsilMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorsController(IActorService actorService)
            => _actorService = actorService;

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ActorCreationDTO actor)
            => Ok(await _actorService.AddAsync(actor));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
            => Ok(await _actorService.RetrieveAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] long id)
            => Ok(await _actorService.RetrieveByIdAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] ActorModificationDTO actor, [FromRoute] long id)
            => Ok(await _actorService.ModifyAsync(id, actor));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
            => Ok(await _actorService.RemoveAsync(id));
    }
}
