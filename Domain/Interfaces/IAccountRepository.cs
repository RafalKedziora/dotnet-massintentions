namespace Domain.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<User> GetAll();
        User Register(User user);
        User Login(User user);
    }
}
