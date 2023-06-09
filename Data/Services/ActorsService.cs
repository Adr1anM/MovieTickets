
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Data.Services
{

    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _context;
        public ActorsService(AppDbContext context)
        {

            _context = context;

        }
        public void Add(Actor actor)
        {
            _context.Actors.Add(actor);
            _context.SaveChanges();
        }

        public void Delete(Actor actor)
        {
            _context.Actors.Remove(actor);
            _context.SaveChanges(); 
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var result = await _context.Actors.ToListAsync();
            return result;
        }

        public async Task<Actor> GetById(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            return result;

        }

        public async Task<Actor> Update(int id, Actor newActor)
        {
            _context.Update(newActor);
            await _context.SaveChangesAsync();
            return newActor;
        }

      
    }
   
}
