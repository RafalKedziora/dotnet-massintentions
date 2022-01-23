namespace Domain.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<User> GetAll();
        User GetUserByEmail(string email);
        User GetUser(User user);
        User Register(User user);
    }
}
