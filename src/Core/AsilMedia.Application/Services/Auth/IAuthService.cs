using AsilMedia.Application.DataTransferObjects;

namespace AsilMedia.Application.Services.Auth
{
    public interface IAuthService
    {
        public Task<string> RegisterServiceAsync(RegisterDTO registerDTO);
        public Task<string> LoginServiceAsync(LoginDTO loginDTO);
    }
}
