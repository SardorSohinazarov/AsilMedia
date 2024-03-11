using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Services.Permissions
{
    public interface IPermissionService
    {
        public Task<Permission> InsertAsync(string name);
        public Task<List<Permission>> SelectAllAsync();
        public Task<Permission> DeleteAsync(long id);
    }
}
