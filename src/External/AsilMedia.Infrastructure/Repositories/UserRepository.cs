using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Domain.Entities;
using AsilMedia.Infrastructure1;
using Microsoft.EntityFrameworkCore;

namespace AsilMedia.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
            => _context = context;

        public Task<User> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> InsertAsync(User user)
        {
            var entry = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<List<User>> SelectAllAsync()
            => await _context.Users
                .Include(x => x.Role)
                .ToListAsync();

        public async Task<User> SelectByIdAsync(long id)
        {
            return await _context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> SelectByIdAsync(string passwordHash, string email)
            => await _context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.PasswordHash == passwordHash && x.Email == email);

        public Task<User> UpdateAsync(User user, long id)
        {
            throw new NotImplementedException();
        }
    }
}
