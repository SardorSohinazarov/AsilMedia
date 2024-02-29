using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
            => _roleRepository = roleRepository;

        public Task<Role> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Role> InsertAsync(string name)
        {
            var role = new Role()
            {
                Name = name
            };

            role = await _roleRepository.InsertAsync(role);

            return role;
        }

        public async Task<List<Role>> SelectAllAsync()
            => await _roleRepository.SelectAllAsync();

        public async Task<Role> SelectByIdAsync(long id)
            => await _roleRepository.SelectByIdAsync(id);

        public Task<Role> UpdateAsync(string name, long id)
        {
            throw new NotImplementedException();
        }
    }
}
