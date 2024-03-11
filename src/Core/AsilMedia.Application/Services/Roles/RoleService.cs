using AsilMedia.Application.Abstractions;
using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Application.DataTransferObjects;
using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IPermissionRepository _permissionRepository;

        public RoleService(IRoleRepository roleRepository, IPermissionRepository permissionRepository)
        {
            _roleRepository = roleRepository;
            _permissionRepository = permissionRepository;
        }

        public Task<Role> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Role> InsertAsync(RoleDTO roleDTO)
        {
            var permissions = await _permissionRepository.SelectAllAsync(roleDTO.Permissions);

            var role = new Role()
            {
                Name = roleDTO.Name,
                Permissions = permissions
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
