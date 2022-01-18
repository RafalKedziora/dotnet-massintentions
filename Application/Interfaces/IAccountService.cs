namespace Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<UserDto> GetAllUsers();
        public UserDto RegisterUser(RegisterUserDto dto);
        public void LoginUser(LoginUserDto dto);
    }
}
