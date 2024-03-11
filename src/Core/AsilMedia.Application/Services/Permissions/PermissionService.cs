using AsilMedia.Application.Abstractions;
using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Services.Permissions
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
            => _permissionRepository = permissionRepository;

        public async Task<Permission> DeleteAsync(long id)
        {
            return await _permissionRepository.DeleteAsync(id);
        }

        public async Task<Permission> InsertAsync(string name)
        {
            var permission = await _permissionRepository.InsertAsync(new Permission { Name = name });

            return permission;
        }

        public Task<List<Permission>> SelectAllAsync()
        {
            return _permissionRepository.SelectAllAsync();
        }
    }
}
