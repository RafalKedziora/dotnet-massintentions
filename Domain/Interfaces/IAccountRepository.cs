namespace Domain.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<User> GetAll();
        User GetUser(User user);
        User Register(User user);
    }
}
