using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Abstractions
{
    public interface IPermissionRepository
    {
        public Task<Permission> InsertAsync(Permission permission);
        public Task<List<Permission>> SelectAllAsync();
        public Task<List<Permission>> SelectAllAsync(List<long> ids);
        public Task<Permission> DeleteAsync(long id);
    }
}
