using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Halpers.JWTServices
{
    public interface IJWTService
    {
        public string GenerateAccessToken(User user);
    }
}
