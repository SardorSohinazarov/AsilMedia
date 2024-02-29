using AsilMedia.Domain.Entities;

namespace AsilMedia.Application.Abstractions.Repositories
{
    public interface IRoleRepository
    {
        public Task<Role> InsertAsync(Role role);
        public Task<Role> SelectByIdAsync(long id);
        public Task<List<Role>> SelectAllAsync();
        public Task<Role> UpdateAsync(Role role, long id);
        public Task<Role> DeleteAsync(long id);
    }
}
