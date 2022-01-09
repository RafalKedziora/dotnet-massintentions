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
            return _context.Intentions
                .Include(x => x.Detail)
                .Include(x => x.Category);
        }

        public Intention GetById(int id)
        {
            return _context.Intentions
                .Include(x => x.Detail)
                .Include(x => x.Category)
                .SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<Intention> GetByDate(DateTime date)
        {
            return _context.Intentions
                .Where(x => x.MassDate == date)
                .Include(x => x.Detail)
                .Include(x => x.Category);
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
