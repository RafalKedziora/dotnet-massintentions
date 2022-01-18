using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(IAccountRepository accountRepository, IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var categories = _accountRepository.GetAll();
            return _mapper.Map<IEnumerable<UserDto>>(categories);
        }

        public void LoginUser(LoginUserDto dto)
        {
            throw new NotImplementedException();
        }

        public UserDto RegisterUser(RegisterUserDto dto)
        {
            var newUser = _mapper.Map<User>(dto);
            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.PasswordHash = hashedPassword;
            _accountRepository.Register(newUser);
            return _mapper.Map<UserDto>(newUser);
        }
    }
}
