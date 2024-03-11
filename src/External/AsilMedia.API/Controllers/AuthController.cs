using AsilMedia.Application.DataTransferObjects;
using AsilMedia.Application.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace AsilMedia.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
            => _authService = authService;

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            return Ok(await _authService.RegisterServiceAsync(registerDTO));
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            return Ok(await _authService.LoginServiceAsync(loginDTO));
        }
    }
}
