using AsilMedia.Application.Abstractions;
using AsilMedia.Domain.Entities;
using AsilMedia.Infrastructure1;
using Microsoft.EntityFrameworkCore;

namespace AsilMedia.Infrastructure.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PermissionRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<Permission> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Permission> InsertAsync(Permission permission)
        {
            var entry = await _applicationDbContext.Permissions.AddAsync(permission);
            await _applicationDbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public Task<List<Permission>> SelectAllAsync()
        {
            return _applicationDbContext.Permissions.ToListAsync();
        }

        public async Task<List<Permission>> SelectAllAsync(List<long> ids)
            => await _applicationDbContext.Permissions.Where(x => ids.Contains(x.Id)).ToListAsync();
    }
}
