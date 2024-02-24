using AsilMedia.Application.Abstractions.Repositories;
using AsilMedia.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AsilMedia.Infrastructure.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly ApplicationDbContext _context;

        public ActorRepository(ApplicationDbContext context)
            => _context = context;

        public async ValueTask<Actor> InsertActorAsync(Actor actor)
        {
            var entry = await _context.AddAsync(actor);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public async ValueTask<Actor> SelectActorByIdAsync(long id)
        {
            var storedActor = await _context.Actors
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (storedActor == null)
                throw new Exception($"Actor {id} was not found.");

            return storedActor;
        }

        public async ValueTask<List<Actor>> SelectAllActorsAsync()
            => await _context.Actors
            .AsNoTracking()
            .ToListAsync();


        public async ValueTask<List<Actor>> SelectAllActorsAsync(List<long> ids)
            => await _context.Actors
            .Where(x => ids.Contains(x.Id))
            .ToListAsync();

        public async ValueTask<Actor> UpdateActorAsync(long id, Actor actor)
        {
            var storedActor = await _context.Actors
                .FirstOrDefaultAsync(x => x.Id == id);

            if (storedActor == null)
                throw new Exception($"Actor {id} was not found.");

            storedActor.Description = actor.Description;
            storedActor.FirstName = actor.FirstName;
            storedActor.LastName = actor.LastName;
            storedActor.Gender = actor.Gender;
            storedActor.PhotoPath = actor.PhotoPath;
            storedActor.UpdatedAt = DateTime.Now;

            var entry = _context.Update(storedActor);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public async ValueTask<Actor> DeleteActorAsync(long id)
        {
            var storedActor = await _context.Actors
                .FirstOrDefaultAsync(x => x.Id == id);

            if (storedActor == null)
                throw new Exception($"Actor {id} was not found.");

            var entry = _context.Remove(storedActor);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
