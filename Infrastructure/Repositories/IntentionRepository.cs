using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class IntentionRepository : IIntentionRepository
    {
        private readonly MyIntentionsContext _context;
        public IntentionRepository(MyIntentionsContext context)
        {
            _context = context;
        }

        public IQueryable<Intention> GetAll()
        {
            return _context.Intentions;
        }

        public Intention GetById(int id)
        {
            return _context.Intentions.SingleOrDefault(x => x.Id == id);
        }

        public Intention Add(Intention intention)
        {
            _context.Intentions.Add(intention);
            _context.SaveChanges();
            return intention;
        }

        public void Update(Intention intention)
        {
            _context.Intentions.Update(intention);
            _context.SaveChanges();
        }

        public void Delete(Intention intention)
        {
            _context.Intentions.Remove(intention);
            _context.SaveChanges();
        }
    }
}
