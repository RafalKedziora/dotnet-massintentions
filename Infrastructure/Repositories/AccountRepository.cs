namespace Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MyIntentionsContext _context;
        public AccountRepository(MyIntentionsContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User Login(User user)
        {
            return _context.Users.FirstOrDefault(u => u.Id == user.Id);
        }

        public User Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
