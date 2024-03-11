using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Application.DataTransferObjects;
using AsilMedia.Application.Halpers.JWTServices;
using AsilMedia.Domain.Entities;
using AsilMedia.Domain.Exceptions.Users;

namespace AsilMedia.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IJWTService _JWTservice;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public AuthService(IJWTService jWTservice, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _JWTservice = jWTservice;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<string> LoginServiceAsync(LoginDTO loginDTO)
        {                                                             //hash
            var user = await _userRepository.SelectByIdAsync(loginDTO.Password, loginDTO.Email);

            if (user is null)
            {
                throw new UserNotFoundException();
            }

            var token = _JWTservice.GenerateAccessToken(user);

            return token;
        }

        public async Task<string> RegisterServiceAsync(RegisterDTO registerDTO)
        {
            var user = new User()
            {
                Name = registerDTO.Name,
                Email = registerDTO.Email,
                //hash
                PasswordHash = registerDTO.Password,
                RoleId = registerDTO.RoleId,
                RefreshToken = registerDTO.RefreshToken,
            };

            user = await _userRepository.InsertAsync(user);
            var role = await _roleRepository.SelectByIdAsync(user.RoleId);
            user.Role = role;

            var token = _JWTservice.GenerateAccessToken(user);

            return token;
        }
    }
}
