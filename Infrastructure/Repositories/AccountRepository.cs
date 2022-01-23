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

        public User GetUser(User user)
        {
            var existingUser = _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == user.Email);
            return existingUser;
        }

        public User Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
